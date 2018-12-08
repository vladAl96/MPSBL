using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MPSBL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Centers",
                columns: table => new
                {
                    DonationCenterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centers", x => x.DonationCenterId);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    DonationRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Doctor = table.Column<string>(nullable: true),
                    Pacient = table.Column<string>(nullable: true),
                    DateIssued = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CenterName = table.Column<string>(nullable: true),
                    DonationCenterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.DonationRequestId);
                    table.ForeignKey(
                        name: "FK_Requests_Centers_DonationCenterId",
                        column: x => x.DonationCenterId,
                        principalTable: "Centers",
                        principalColumn: "DonationCenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DonationCenterId",
                table: "Requests",
                column: "DonationCenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Centers");
        }
    }
}
