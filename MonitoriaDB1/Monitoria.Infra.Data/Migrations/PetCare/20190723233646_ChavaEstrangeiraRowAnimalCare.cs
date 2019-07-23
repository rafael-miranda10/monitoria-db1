using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoria.Infra.Data.Migrations.PetCare
{
    public partial class ChavaEstrangeiraRowAnimalCare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AnimalPetCareId",
                schema: "PetCare",
                table: "RowAnimalCare",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalPetCareId",
                schema: "PetCare",
                table: "RowAnimalCare");
        }
    }
}
