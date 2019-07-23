using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoria.Infra.Data.Migrations.PetCare
{
    public partial class NovomapeamentoProfessionalServicesAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionalServicesAnimal",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalServicesAnimal_PetServiceId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalServicesAnimal_professionalId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionalServicesAnimal",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                columns: new[] { "Id", "PetServiceId", "professionalId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalServicesAnimal_PetServiceId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "PetServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalServicesAnimal_professionalId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "professionalId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionalServicesAnimal",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalServicesAnimal_PetServiceId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalServicesAnimal_professionalId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionalServicesAnimal",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalServicesAnimal_PetServiceId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "PetServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalServicesAnimal_professionalId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "professionalId");
        }
    }
}
