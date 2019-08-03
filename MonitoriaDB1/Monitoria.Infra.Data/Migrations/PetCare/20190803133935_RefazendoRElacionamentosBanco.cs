using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoria.Infra.Data.Migrations.PetCare
{
    public partial class RefazendoRElacionamentosBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalServicesAnimal_PetServices_PetServiceId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalServicesAnimal_RowAnimalCare_RowAnimalCareId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalServicesAnimal_Professional_professionalId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalServicesAnimal_PetServiceId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalServicesAnimal_RowAnimalCareId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalServicesAnimal_professionalId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.RenameColumn(
                name: "professionalId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                newName: "ProfessionalId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<Guid>(
                name: "RowAnimalCareRepModelId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                nullable: true);

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
                name: "IX_ProfessionalServicesAnimal_RowAnimalCareRepModelId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "RowAnimalCareRepModelId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalServicesAnimal_RowAnimalCare_RowAnimalCareRepModelId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "RowAnimalCareRepModelId",
                principalSchema: "PetCare",
                principalTable: "RowAnimalCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetServices_ProfessionalServicesAnimal_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServi~",
                schema: "PetCare",
                table: "PetServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Professional_ProfessionalServicesAnimal_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServ~",
                schema: "PetCare",
                table: "Professional");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalServicesAnimal_RowAnimalCare_RowAnimalCareRepModelId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalServicesAnimal_RowAnimalCareRepModelId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

            migrationBuilder.DropIndex(
                name: "IX_Professional_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServicesAnimalProfessionalId",
                schema: "PetCare",
                table: "Professional");

            migrationBuilder.DropIndex(
                name: "IX_PetServices_ProfessionalServicesAnimalId_ProfessionalServicesAnimalPetServiceId_ProfessionalServicesAnimalProfessionalId",
                schema: "PetCare",
                table: "PetServices");

            migrationBuilder.DropColumn(
                name: "RowAnimalCareRepModelId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal");

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

            migrationBuilder.RenameColumn(
                name: "ProfessionalId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                newName: "professionalId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalServicesAnimal_PetServiceId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "PetServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalServicesAnimal_RowAnimalCareId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "RowAnimalCareId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalServicesAnimal_professionalId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "professionalId",
                unique: true);

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
                name: "FK_ProfessionalServicesAnimal_RowAnimalCare_RowAnimalCareId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "RowAnimalCareId",
                principalSchema: "PetCare",
                principalTable: "RowAnimalCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalServicesAnimal_Professional_professionalId",
                schema: "PetCare",
                table: "ProfessionalServicesAnimal",
                column: "professionalId",
                principalSchema: "PetCare",
                principalTable: "Professional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
