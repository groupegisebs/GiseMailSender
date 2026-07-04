namespace SecureMailGateway.Services;

/// <summary>
/// Single source of truth for the transactional-email <c>{{Variable}}</c> catalog.
/// Every consumer (sanitizer whitelist, controller normalization/fallback samples,
/// AI prompt allowed list, editor palette chips, and test-data samples) must derive
/// its list from here so the catalog stays consistent across the whole application.
/// </summary>
public static class TemplateVariableCatalog
{
    public sealed record TemplateVariable(string Name, Func<string> Sample);

    public sealed record TemplateVariableGroup(string Label, IReadOnlyList<TemplateVariable> Variables);

    private static string Today() => DateTime.Today.ToString("yyyy-MM-dd");
    private static string InDays(int days) => DateTime.Today.AddDays(days).ToString("yyyy-MM-dd");
    private static string CurrentYear() => DateTime.Today.Year.ToString();

    private static TemplateVariable Var(string name, string sample) => new(name, () => sample);
    private static TemplateVariable Var(string name, Func<string> sample) => new(name, sample);

    /// <summary>
    /// Ordered, grouped catalog. Existing variable names (FirstName, LastName, CompanyName,
    /// Email, ResetLink, OrderId, Amount, InvoiceDate, Message, Title) are preserved so that
    /// templates created before the catalog was expanded keep working.
    /// </summary>
    public static IReadOnlyList<TemplateVariableGroup> Groups { get; } =
    [
        new("Identité / Compte",
        [
            Var("FirstName", "Jean"),
            Var("LastName", "Dupont"),
            Var("FullName", "Jean Dupont"),
            Var("UserName", "jdupont"),
            Var("Email", "client@example.com"),
            Var("PhoneNumber", "+33 6 12 34 56 78"),
            Var("AccountId", "ACC-100294"),
            Var("CompanyName", "GiseDoc"),
        ]),
        new("Authentification / Sécurité",
        [
            Var("ResetLink", "https://example.com/reset?token=abc123"),
            Var("ConfirmLink", "https://example.com/confirm?token=abc123"),
            Var("VerificationCode", "482913"),
            Var("LoginLink", "https://example.com/login"),
            Var("ExpiryTime", "30 minutes"),
            Var("IpAddress", "192.0.2.10"),
            Var("DeviceInfo", "Chrome sur Windows"),
            Var("SupportEmail", "support@example.com"),
        ]),
        new("Abonnement",
        [
            Var("SubscriptionName", "Abonnement Pro"),
            Var("PlanName", "Plan Premium"),
            Var("TrialEndDate", () => InDays(14)),
            Var("RenewalDate", () => InDays(30)),
            Var("SubscriptionStatus", "Actif"),
            Var("BillingCycle", "Mensuel"),
            Var("ManageSubscriptionLink", "https://example.com/account/subscription"),
            Var("CancelLink", "https://example.com/account/cancel"),
        ]),
        new("Commandes (e-commerce)",
        [
            Var("OrderId", "ORD-2026-001"),
            Var("OrderNumber", "2026-000145"),
            Var("OrderDate", Today),
            Var("OrderStatus", "Confirmée"),
            Var("OrderLink", "https://example.com/orders/2026-000145"),
            Var("OrderTotal", "129,00 $"),
            Var("Currency", "CAD"),
            Var("Subtotal", "110,00 $"),
            Var("ShippingCost", "9,00 $"),
            Var("TaxAmount", "10,00 $"),
            Var("DiscountAmount", "-15,00 $"),
            Var("PromoCode", "BIENVENUE15"),
        ]),
        new("Produits / Article",
        [
            Var("ProductName", "Casque audio sans fil"),
            Var("ProductLink", "https://example.com/products/casque-audio"),
            Var("Quantity", "2"),
        ]),
        new("Livraison",
        [
            Var("TrackingNumber", "1Z999AA10123456784"),
            Var("TrackingLink", "https://example.com/track/1Z999AA10123456784"),
            Var("Carrier", "Postes Canada"),
            Var("EstimatedDelivery", () => InDays(5)),
            Var("ShippingAddress", "123 rue Principale, Montréal, QC H2X 1Y6"),
            Var("DeliveryDate", () => InDays(5)),
        ]),
        new("Facturation / Facture",
        [
            Var("InvoiceId", "INV-2026-001"),
            Var("InvoiceNumber", "2026-000145"),
            Var("InvoiceDate", Today),
            Var("InvoiceLink", "https://example.com/invoices/2026-000145"),
            Var("Amount", "29,00 $"),
            Var("DueDate", () => InDays(15)),
            Var("PaymentMethod", "Visa se terminant par 4242"),
            Var("PaymentStatus", "Payée"),
            Var("ReceiptLink", "https://example.com/receipts/2026-000145"),
        ]),
        new("Boutique / Marque / Générique",
        [
            Var("StoreName", "Boutique Gise"),
            Var("StoreLink", "https://example.com"),
            Var("WebsiteUrl", "https://example.com"),
            Var("LogoUrl", "https://example.com/logo.png"),
            Var("UnsubscribeLink", "https://example.com/unsubscribe"),
            Var("PrivacyPolicyLink", "https://example.com/privacy"),
            Var("Year", CurrentYear),
            Var("Message", "Votre demande a bien été prise en compte."),
            Var("Title", "Bienvenue"),
            Var("CtaLink", "https://example.com/action"),
            Var("CtaLabel", "Voir mon compte"),
        ]),
    ];

    private static readonly IReadOnlyList<TemplateVariable> AllVariables =
        Groups.SelectMany(g => g.Variables).ToArray();

    /// <summary>All variable names in catalog order (grouped).</summary>
    public static IReadOnlyList<string> Names { get; } =
        AllVariables.Select(v => v.Name).ToArray();

    /// <summary>Case-insensitive lookup set used for whitelist/validation checks.</summary>
    public static IReadOnlyCollection<string> NameSet { get; } =
        new HashSet<string>(Names, StringComparer.OrdinalIgnoreCase);

    /// <summary>Builds a fresh sample-data dictionary (date-based samples are recomputed).</summary>
    public static Dictionary<string, string> BuildSampleData()
    {
        var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var variable in AllVariables)
        {
            data[variable.Name] = variable.Sample();
        }
        return data;
    }

    /// <summary>Returns a realistic sample value for a known variable, or a generic fallback.</summary>
    public static string GetSampleValue(string variableName)
    {
        var match = AllVariables.FirstOrDefault(v =>
            string.Equals(v.Name, variableName, StringComparison.OrdinalIgnoreCase));
        return match?.Sample() ?? "Exemple";
    }
}
