using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoria.Infra.Data.Migrations.PetCare
{
    public partial class AlteracaoAnimalPetCare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                schema: "PetCare",
                table: "AnimalPetCare",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "PetCare",
                table: "AnimalPetCare");
        }
    }
}
