using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laundry.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTicketLoctions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryLocation",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "DropoffLocation",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PickupLocation",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DropoffLocation",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "PickupLocation",
                table: "Ticket");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryLocation",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
