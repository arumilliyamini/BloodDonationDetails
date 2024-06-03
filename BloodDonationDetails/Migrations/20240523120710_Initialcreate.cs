using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationDetails.Migrations
{
    public partial class Initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "candidateDetails",
                columns: table => new
                {
                    DonatedpersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidateDetails", x => x.DonatedpersonID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidateDetails");
        }
    }
}
