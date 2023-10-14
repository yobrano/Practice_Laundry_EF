using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laundry.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTicketDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetail_LaundryService_ServiceId",
                table: "TicketDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetail_Ticket_TicketNoId",
                table: "TicketDetail");

            migrationBuilder.RenameColumn(
                name: "TicketNoId",
                table: "TicketDetail",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "TicketDetail",
                newName: "LaundryServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketDetail_TicketNoId",
                table: "TicketDetail",
                newName: "IX_TicketDetail_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketDetail_ServiceId",
                table: "TicketDetail",
                newName: "IX_TicketDetail_LaundryServiceId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "TicketDetail",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "TicketDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetail_Index_TicketId",
                table: "TicketDetail",
                columns: new[] { "Index", "TicketId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetail_LaundryService_LaundryServiceId",
                table: "TicketDetail",
                column: "LaundryServiceId",
                principalTable: "LaundryService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetail_Ticket_TicketId",
                table: "TicketDetail",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetail_LaundryService_LaundryServiceId",
                table: "TicketDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetail_Ticket_TicketId",
                table: "TicketDetail");

            migrationBuilder.DropIndex(
                name: "IX_TicketDetail_Index_TicketId",
                table: "TicketDetail");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "TicketDetail");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "TicketDetail",
                newName: "TicketNoId");

            migrationBuilder.RenameColumn(
                name: "LaundryServiceId",
                table: "TicketDetail",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketDetail_TicketId",
                table: "TicketDetail",
                newName: "IX_TicketDetail_TicketNoId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketDetail_LaundryServiceId",
                table: "TicketDetail",
                newName: "IX_TicketDetail_ServiceId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "TicketDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetail_LaundryService_ServiceId",
                table: "TicketDetail",
                column: "ServiceId",
                principalTable: "LaundryService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetail_Ticket_TicketNoId",
                table: "TicketDetail",
                column: "TicketNoId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
