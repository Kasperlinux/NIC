using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NIC.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Preference_Id",
                table: "preference_MBBS",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ScreeningCentre",
                table: "Applicants_MBBS",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_preference_MBBS",
                table: "preference_MBBS",
                column: "Preference_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_preference_MBBS",
                table: "preference_MBBS");

            migrationBuilder.DropColumn(
                name: "Preference_Id",
                table: "preference_MBBS");

            migrationBuilder.DropColumn(
                name: "ScreeningCentre",
                table: "Applicants_MBBS");
        }
    }
}
