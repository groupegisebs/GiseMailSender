using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecureMailGateway.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmailTemplateUniqueByCodeAndLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmailTemplates_TemplateCode",
                table: "EmailTemplates");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_TemplateCode_Language",
                table: "EmailTemplates",
                columns: new[] { "TemplateCode", "Language" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmailTemplates_TemplateCode_Language",
                table: "EmailTemplates");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_TemplateCode",
                table: "EmailTemplates",
                column: "TemplateCode",
                unique: true);
        }
    }
}
