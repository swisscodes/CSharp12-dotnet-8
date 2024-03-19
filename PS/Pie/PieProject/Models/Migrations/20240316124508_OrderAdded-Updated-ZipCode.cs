using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PieProject.models.Migrations
{
    /// <inheritdoc />
    public partial class OrderAddedUpdatedZipCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "Orders",
                newName: "ZipCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Orders",
                newName: "Zipcode");
        }
    }
}
