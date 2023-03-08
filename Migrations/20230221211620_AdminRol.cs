using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasMVC.Migrations
{
    /// <inheritdoc />
    public partial class AdminRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF NOT EXISTS(SELECT Id FROM AspNetRoles WHERE Id  = '99a6296f-3d0f-45c4-b632-84f3e558e173')
                BEGIN
                    INSERT AspNetRoles (Id, [Name], [NormalizedName])
                    VALUES ('99a6296f-3d0f-45c4-b632-84f3e558e173', 'admin', 'ADMIN')
                END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE AspNetRoles Where Id = '99a6296f-3d0f-45c4-b632-84f3e558e173'");
        }
    }
}
