using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_reservation_car_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_DropOffpLocationID",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "DropOffpLocationID",
                table: "Reservations",
                newName: "DropOffLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_DropOffpLocationID",
                table: "Reservations",
                newName: "IX_Reservations_DropOffLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarID",
                table: "Reservations",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Cars_CarID",
                table: "Reservations",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_DropOffLocationID",
                table: "Reservations",
                column: "DropOffLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Cars_CarID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_DropOffLocationID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CarID",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "DropOffLocationID",
                table: "Reservations",
                newName: "DropOffpLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_DropOffLocationID",
                table: "Reservations",
                newName: "IX_Reservations_DropOffpLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_DropOffpLocationID",
                table: "Reservations",
                column: "DropOffpLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID");
        }
    }
}
