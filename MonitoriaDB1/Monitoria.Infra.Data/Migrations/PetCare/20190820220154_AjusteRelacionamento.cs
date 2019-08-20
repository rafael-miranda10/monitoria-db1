using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoria.Infra.Data.Migrations.PetCare
{
    public partial class AjusteRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetServices_ProfessionalServicesAnimal_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServi~",
                schema: "PetCare",
                table: "PetServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Professional_ProfessionalServicesAnimal_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServ~",
                schema: "PetCare",
                table: "Professional");

            migrationBuilder.DropIndex(
                name: "IX_Professional_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServicesAnimalProfessionalId",
                schema: "PetCare",
                table: "Professional");

            migrationBuilder.DropIndex(
                name: "IX_PetServices_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServicesAnimalProfessionalId",
                schema: "PetCare",
                table: "PetServices");

            migrationBuilder.DropColumn(
                name: "ProfessionalServicesAnimalId",
                schema: "PetCare",
                table: "Professional");

            migrationBuilder.DropColumn(
                name: "ProfessionalServicesAnimalPetServiceId",
                schema: "PetCare",
                table: "Professional");

            migrationBuilder.DropColumn(
                name: "ProfessionalServicesAnimalProfessionalId",
                schema: "PetCare",
                table: "Professional");

            migrationBuilder.DropColumn(
                name: "ProfessionalServicesAnimalId",
                schema: "PetCare",
                table: "PetServices");

            migrationBuilder.DropColumn(
                name: "ProfessionalServicesAnimalPetServiceId",
                schema: "PetCare",
                table: "PetServices");

            migrationBuilder.DropColumn(
                name: "ProfessionalServicesAnimalProfessionalId",
                schema: "PetCare",
                table: "PetServices");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalServicesAnimalId",
                schema: "PetCare",
                table: "Professional",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalServicesAnimalPetServiceId",
                schema: "PetCare",
                table: "Professional",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalServicesAnimalProfessionalId",
                schema: "PetCare",
                table: "Professional",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalServicesAnimalId",
                schema: "PetCare",
                table: "PetServices",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalServicesAnimalPetServiceId",
                schema: "PetCare",
                table: "PetServices",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalServicesAnimalProfessionalId",
                schema: "PetCare",
                table: "PetServices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professional_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServicesAnimalProfessionalId",
                schema: "PetCare",
                table: "Professional",
                columns: new[] { "ProfessionalServicesAnimalId", "ProfessionalServicesAnimalPetServiceId", "ProfessionalServicesAnimalProfessionalId" });

            migrationBuilder.CreateIndex(
                name: "IX_PetServices_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServicesAnimalProfessionalId",
                schema: "PetCare",
                table: "PetServices",
                columns: new[] { "ProfessionalServicesAnimalId", "ProfessionalServicesAnimalPetServiceId", "ProfessionalServicesAnimalProfessionalId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PetServices_ProfessionalServicesAnimal_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServi~",
                schema: "PetCare",
                table: "PetServices",
                columns: new[] { "ProfessionalServicesAnimalId", "ProfessionalServicesAnimalPetServiceId", "ProfessionalServicesAnimalProfessionalId" },
                principalSchema: "PetCare",
                principalTable: "ProfessionalServicesAnimal",
                principalColumns: new[] { "Id", "PetServiceId", "ProfessionalId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Professional_ProfessionalServicesAnimal_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServ~",
                schema: "PetCare",
                table: "Professional",
                columns: new[] { "ProfessionalServicesAnimalId", "ProfessionalServicesAnimalPetServiceId", "ProfessionalServicesAnimalProfessionalId" },
                principalSchema: "PetCare",
                principalTable: "ProfessionalServicesAnimal",
                principalColumns: new[] { "Id", "PetServiceId", "ProfessionalId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
