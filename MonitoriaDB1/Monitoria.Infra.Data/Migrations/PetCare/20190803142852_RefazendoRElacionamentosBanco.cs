using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoria.Infra.Data.Migrations.PetCare
{
    public partial class RefazendoRElacionamentosBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PetCare");

            migrationBuilder.CreateTable(
                name: "RowAnimalCare",
                schema: "PetCare",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnimalId = table.Column<Guid>(nullable: false),
                    ValueTotal = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowAnimalCare", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalServicesAnimal",
                schema: "PetCare",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProfessionalId = table.Column<Guid>(nullable: false),
                    PetServiceId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(maxLength: 200, nullable: true),
                    ExecutionOrder = table.Column<int>(nullable: false),
                    RowAnimalCareId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalServicesAnimal", x => new { x.Id, x.PetServiceId, x.ProfessionalId });
                    table.ForeignKey(
                        name: "FK_ProfessionalServicesAnimal_RowAnimalCare_RowAnimalCareId",
                        column: x => x.RowAnimalCareId,
                        principalSchema: "PetCare",
                        principalTable: "RowAnimalCare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    Active = table.Column<bool>(nullable: false),
                    ProfessionalServicesAnimalId = table.Column<Guid>(nullable: true),
                    ProfessionalServicesAnimalPetServiceId = table.Column<Guid>(nullable: true),
                    ProfessionalServicesAnimalProfessionalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetServices_ProfessionalServicesAnimal_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServi~",
                        columns: x => new { x.ProfessionalServicesAnimalId, x.ProfessionalServicesAnimalPetServiceId, x.ProfessionalServicesAnimalProfessionalId },
                        principalSchema: "PetCare",
                        principalTable: "ProfessionalServicesAnimal",
                        principalColumns: new[] { "Id", "PetServiceId", "ProfessionalId" },
                        onDelete: ReferentialAction.Restrict);
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
                    JobPosition = table.Column<int>(nullable: false),
                    ProfessionalServicesAnimalId = table.Column<Guid>(nullable: true),
                    ProfessionalServicesAnimalPetServiceId = table.Column<Guid>(nullable: true),
                    ProfessionalServicesAnimalProfessionalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professional_ProfessionalServicesAnimal_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServ~",
                        columns: x => new { x.ProfessionalServicesAnimalId, x.ProfessionalServicesAnimalPetServiceId, x.ProfessionalServicesAnimalProfessionalId },
                        principalSchema: "PetCare",
                        principalTable: "ProfessionalServicesAnimal",
                        principalColumns: new[] { "Id", "PetServiceId", "ProfessionalId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetServices_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServicesAnimalProfessionalId",
                schema: "PetCare",
                table: "PetServices",
                columns: new[] { "ProfessionalServicesAnimalId", "ProfessionalServicesAnimalPetServiceId", "ProfessionalServicesAnimalProfessionalId" });

            migrationBuilder.CreateIndex(
                name: "IX_Professional_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServicesAnimalProfessionalId",
                schema: "PetCare",
                table: "Professional",
                columns: new[] { "ProfessionalServicesAnimalId", "ProfessionalServicesAnimalPetServiceId", "ProfessionalServicesAnimalProfessionalId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalServicesAnimal_RowAnimalCareId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "RowAnimalCareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetServices",
                schema: "PetCare");

            migrationBuilder.DropTable(
                name: "Professional",
                schema: "PetCare");

            migrationBuilder.DropTable(
                name: "ProfessionalServicesAnimal",
                schema: "PetCare");

            migrationBuilder.DropTable(
                name: "RowAnimalCare",
                schema: "PetCare");
        }
    }
}
