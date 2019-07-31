using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoria.Infra.Data.Migrations.PetCare
{
    public partial class MapeamentoAnimalRefeito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalPetCare",
                schema: "PetCare");

            migrationBuilder.RenameColumn(
                name: "AnimalPetCareId",
                schema: "PetCare",
                table: "RowAnimalCare",
                newName: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnimalId",
                schema: "PetCare",
                table: "RowAnimalCare",
                newName: "AnimalPetCareId");

            migrationBuilder.CreateTable(
                name: "AnimalPetCare",
                schema: "PetCare",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
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
        }
    }
}
