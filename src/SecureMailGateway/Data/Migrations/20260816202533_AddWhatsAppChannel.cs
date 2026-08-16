using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SecureMailGateway.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWhatsAppChannel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WhatsAppCodeSequences",
                columns: table => new
                {
                    Year = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatsAppCodeSequences", x => x.Year);
                });

            migrationBuilder.CreateTable(
                name: "WhatsAppConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProviderName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhoneNumberId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    BusinessAccountId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    DisplayPhoneNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    AccessTokenEncrypted = table.Column<string>(type: "text", nullable: true),
                    AppSecretEncrypted = table.Column<string>(type: "text", nullable: true),
                    WebhookVerifyToken = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    ApiVersion = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    DefaultCountryCode = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatsAppConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhatsAppInboundMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FromPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ProfileName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ProviderMessageId = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    PhoneNumberId = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    MessageType = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Text = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    RawJson = table.Column<string>(type: "text", nullable: true),
                    ReceivedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatsAppInboundMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhatsAppMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageCode = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: false),
                    ClientApplicationId = table.Column<Guid>(type: "uuid", nullable: false),
                    TemplateCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MetaTemplateName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Language = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    ToPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    BodyPreview = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    PayloadJson = table.Column<string>(type: "text", nullable: false),
                    ProviderMessageId = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    RecipientWaId = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    RetryCount = table.Column<int>(type: "integer", nullable: false),
                    CallbackUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ErrorMessage = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    ErrorCode = table.Column<int>(type: "integer", nullable: true),
                    ProviderResponse = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    QueuedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    SendingAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    SentAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeliveredAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ReadAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    FailedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatsAppMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhatsAppMessages_ClientApplications_ClientApplicationId",
                        column: x => x.ClientApplicationId,
                        principalTable: "ClientApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WhatsAppTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TemplateCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Language = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    ClientApplicationId = table.Column<Guid>(type: "uuid", nullable: true),
                    MetaTemplateName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    MetaLanguageCode = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    BodyParameters = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    HeaderParameters = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ButtonUrlParameter = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PreviewText = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatsAppTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhatsAppTemplates_ClientApplications_ClientApplicationId",
                        column: x => x.ClientApplicationId,
                        principalTable: "ClientApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WhatsAppSendLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WhatsAppMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Details = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatsAppSendLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhatsAppSendLogs_WhatsAppMessages_WhatsAppMessageId",
                        column: x => x.WhatsAppMessageId,
                        principalTable: "WhatsAppMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppConfigurations_IsDefault",
                table: "WhatsAppConfigurations",
                column: "IsDefault");

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppInboundMessages_FromPhone_ReceivedAt",
                table: "WhatsAppInboundMessages",
                columns: new[] { "FromPhone", "ReceivedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppInboundMessages_ProviderMessageId",
                table: "WhatsAppInboundMessages",
                column: "ProviderMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppMessages_ClientApplicationId",
                table: "WhatsAppMessages",
                column: "ClientApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppMessages_MessageCode",
                table: "WhatsAppMessages",
                column: "MessageCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppMessages_ProviderMessageId",
                table: "WhatsAppMessages",
                column: "ProviderMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppMessages_QueuedAt",
                table: "WhatsAppMessages",
                column: "QueuedAt");

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppMessages_Status",
                table: "WhatsAppMessages",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppSendLogs_WhatsAppMessageId",
                table: "WhatsAppSendLogs",
                column: "WhatsAppMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppTemplates_ClientApplicationId",
                table: "WhatsAppTemplates",
                column: "ClientApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppTemplates_TemplateCode_Language_ClientApplicationId",
                table: "WhatsAppTemplates",
                columns: new[] { "TemplateCode", "Language", "ClientApplicationId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WhatsAppCodeSequences");

            migrationBuilder.DropTable(
                name: "WhatsAppConfigurations");

            migrationBuilder.DropTable(
                name: "WhatsAppInboundMessages");

            migrationBuilder.DropTable(
                name: "WhatsAppSendLogs");

            migrationBuilder.DropTable(
                name: "WhatsAppTemplates");

            migrationBuilder.DropTable(
                name: "WhatsAppMessages");
        }
    }
}
