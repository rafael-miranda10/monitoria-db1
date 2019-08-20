using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoria.Infra.Data.Migrations.PetCare
{
    public partial class AjusteRelacionamento2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalServicesAnimal_PetServices_PetServiceId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalServicesAnimal_Professional_ProfessionalId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalServicesAnimal_PetServiceId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalServicesAnimal_ProfessionalId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalServicesAnimal_PetServiceId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "PetServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalServicesAnimal_ProfessionalId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "ProfessionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalServicesAnimal_PetServices_PetServiceId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "PetServiceId",
                principalSchema: "PetCare",
                principalTable: "PetServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalServicesAnimal_Professional_ProfessionalId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "ProfessionalId",
                principalSchema: "PetCare",
                principalTable: "Professional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
