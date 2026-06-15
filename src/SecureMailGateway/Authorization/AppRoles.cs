namespace SecureMailGateway.Authorization;

public static class AppRoles
{
    public const string Admin = "Admin";
    public const string Developer = "Developer";
    public const string Viewer = "Viewer";

    public static readonly string[] All = [Admin, Developer, Viewer];
}
