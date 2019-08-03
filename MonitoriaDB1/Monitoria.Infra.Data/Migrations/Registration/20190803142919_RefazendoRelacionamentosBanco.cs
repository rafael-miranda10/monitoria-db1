using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoria.Infra.Data.Migrations.Registration
{
    public partial class RefazendoRelacionamentosBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Registration");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Registration",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DocNumber = table.Column<string>(maxLength: 50, nullable: false),
                    DocType = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 60, nullable: false),
                    AddressStreet = table.Column<string>(maxLength: 50, nullable: false),
                    AddressNumber = table.Column<string>(nullable: false),
                    AddressNeighborhood = table.Column<string>(maxLength: 50, nullable: false),
                    AddressCity = table.Column<string>(maxLength: 50, nullable: false),
                    AddressState = table.Column<string>(maxLength: 50, nullable: false),
                    AddressCountry = table.Column<string>(maxLength: 50, nullable: false),
                    AddressZipCode = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                schema: "Registration",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Specie = table.Column<int>(nullable: false),
                    IsAlive = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Registration",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_CustomerId",
                schema: "Registration",
                table: "Animal",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal",
                schema: "Registration");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Registration");
        }
    }
}
