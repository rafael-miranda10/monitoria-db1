using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoria.Infra.Data.Migrations.PetCare
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PetCare");

            migrationBuilder.CreateTable(
                name: "PetServices",
                schema: "PetCare",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    Category = table.Column<int>(nullable: false),
                    CheckList = table.Column<string>(maxLength: 200, nullable: false),
                    ServiceValue = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professional",
                schema: "PetCare",
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
                    AddressZipCode = table.Column<string>(maxLength: 8, nullable: false),
                    JobPosition = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professional", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RowAnimalCare",
                schema: "PetCare",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ValueTotal = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowAnimalCare", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalPetCare",
                schema: "PetCare",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Specie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalPetCare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalPetCare_RowAnimalCare_Id",
                        column: x => x.Id,
                        principalSchema: "PetCare",
                        principalTable: "RowAnimalCare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalServicesAnimal",
                schema: "PetCare",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    professionalId = table.Column<Guid>(nullable: false),
                    PetServiceId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(maxLength: 150, nullable: false),
                    RowAnimalCareId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalServicesAnimal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalServicesAnimal_PetServices_PetServiceId",
                        column: x => x.PetServiceId,
                        principalSchema: "PetCare",
                        principalTable: "PetServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessionalServicesAnimal_RowAnimalCare_RowAnimalCareId",
                        column: x => x.RowAnimalCareId,
                        principalSchema: "PetCare",
                        principalTable: "RowAnimalCare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessionalServicesAnimal_Professional_professionalId",
                        column: x => x.professionalId,
                        principalSchema: "PetCare",
                        principalTable: "Professional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalServicesAnimal_PetServiceId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "PetServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalServicesAnimal_RowAnimalCareId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "RowAnimalCareId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalServicesAnimal_professionalId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "professionalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalPetCare",
                schema: "PetCare");

            migrationBuilder.DropTable(
                name: "ProfessionalServicesAnimal",
                schema: "PetCare");

            migrationBuilder.DropTable(
                name: "PetServices",
                schema: "PetCare");

            migrationBuilder.DropTable(
                name: "RowAnimalCare",
                schema: "PetCare");

            migrationBuilder.DropTable(
                name: "Professional",
                schema: "PetCare");
        }
    }
}
