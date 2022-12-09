using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartPark.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLogFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ActionTaked",
                table: "CameraLogs",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "PlateNumber",
                table: "CameraLogs",
                type: "character varying(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionTaked",
                table: "CameraLogs");

            migrationBuilder.DropColumn(
                name: "PlateNumber",
                table: "CameraLogs");
        }
    }
}
