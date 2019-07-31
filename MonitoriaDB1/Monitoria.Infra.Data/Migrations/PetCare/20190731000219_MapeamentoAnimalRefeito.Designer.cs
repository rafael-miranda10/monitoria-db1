﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monitoria.Infra.Data.Contexts;

namespace Monitoria.Infra.Data.Migrations.PetCare
{
    [DbContext(typeof(PetCareContext))]
    [Migration("20190731000219_MapeamentoAnimalRefeito")]
    partial class MapeamentoAnimalRefeito
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("PetCare")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Monitoria.Infra.RepoModels.PetCare.Models.PetServicesRepModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .HasColumnName("Active");

                    b.Property<int>("Category")
                        .HasColumnName("Category");

                    b.Property<string>("CheckList")
                        .IsRequired()
                        .HasColumnName("CheckList")
                        .HasMaxLength(200);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasMaxLength(50);

                    b.Property<decimal>("ServiceValue")
                        .HasColumnName("ServiceValue")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("PetServices");
                });

            modelBuilder.Entity("Monitoria.Infra.RepoModels.PetCare.Models.ProfessionalRepModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("JobPosition")
                        .HasColumnName("JobPosition");

                    b.HasKey("Id");

                    b.ToTable("Professional");
                });

            modelBuilder.Entity("Monitoria.Infra.RepoModels.PetCare.Models.ProfessionalServicesAnimalRepModel", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("PetServiceId");

                    b.Property<Guid>("professionalId");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("ExecutionOrder");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnName("Note")
                        .HasMaxLength(150);

                    b.Property<Guid>("RowAnimalCareId");

                    b.Property<DateTime>("StartDate")
                        .HasColumnName("StartDate");

                    b.HasKey("Id", "PetServiceId", "professionalId");

                    b.HasIndex("PetServiceId")
                        .IsUnique();

                    b.HasIndex("RowAnimalCareId");

                    b.HasIndex("professionalId")
                        .IsUnique();

                    b.ToTable("ProfessionalServicesAnimal");
                });

            modelBuilder.Entity("Monitoria.Infra.RepoModels.PetCare.Models.RowAnimalCareRepModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AnimalId");

                    b.Property<decimal>("ValueTotal")
                        .HasColumnName("ValueTotal")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("RowAnimalCare");
                });

            modelBuilder.Entity("Monitoria.Infra.RepoModels.PetCare.Models.ProfessionalRepModel", b =>
                {
                    b.OwnsOne("Monitoria.Infra.RepModels.Shared.ValueObjects.AddressRepModel", "Address", b1 =>
                        {
                            b1.Property<Guid>("ProfessionalRepModelId");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnName("AddressCity")
                                .HasMaxLength(50);

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnName("AddressCountry")
                                .HasMaxLength(50);

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasColumnName("AddressNeighborhood")
                                .HasMaxLength(50);

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnName("AddressNumber");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnName("AddressState")
                                .HasMaxLength(50);

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnName("AddressStreet")
                                .HasMaxLength(50);

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnName("AddressZipCode")
                                .HasMaxLength(8);

                            b1.HasKey("ProfessionalRepModelId");

                            b1.ToTable("Professional","PetCare");

                            b1.HasOne("Monitoria.Infra.RepoModels.PetCare.Models.ProfessionalRepModel")
                                .WithOne("Address")
                                .HasForeignKey("Monitoria.Infra.RepModels.Shared.ValueObjects.AddressRepModel", "ProfessionalRepModelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Monitoria.Infra.RepModels.Shared.ValueObjects.DocumentRepModel", "Document", b1 =>
                        {
                            b1.Property<Guid>("ProfessionalRepModelId");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnName("DocNumber")
                                .HasMaxLength(50);

                            b1.Property<int>("Type")
                                .HasColumnName("DocType");

                            b1.HasKey("ProfessionalRepModelId");

                            b1.ToTable("Professional","PetCare");

                            b1.HasOne("Monitoria.Infra.RepoModels.PetCare.Models.ProfessionalRepModel")
                                .WithOne("Document")
                                .HasForeignKey("Monitoria.Infra.RepModels.Shared.ValueObjects.DocumentRepModel", "ProfessionalRepModelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Monitoria.Infra.RepModels.Shared.ValueObjects.EmailRepModel", "Email", b1 =>
                        {
                            b1.Property<Guid>("ProfessionalRepModelId");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnName("EmailAddress")
                                .HasMaxLength(60);

                            b1.HasKey("ProfessionalRepModelId");

                            b1.ToTable("Professional","PetCare");

                            b1.HasOne("Monitoria.Infra.RepoModels.PetCare.Models.ProfessionalRepModel")
                                .WithOne("Email")
                                .HasForeignKey("Monitoria.Infra.RepModels.Shared.ValueObjects.EmailRepModel", "ProfessionalRepModelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Monitoria.Infra.RepModels.Shared.ValueObjects.NameRepModel", "Name", b1 =>
                        {
                            b1.Property<Guid>("ProfessionalRepModelId");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnName("FirstName")
                                .HasMaxLength(50);

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnName("LastName")
                                .HasMaxLength(50);

                            b1.HasKey("ProfessionalRepModelId");

                            b1.ToTable("Professional","PetCare");

                            b1.HasOne("Monitoria.Infra.RepoModels.PetCare.Models.ProfessionalRepModel")
                                .WithOne("Name")
                                .HasForeignKey("Monitoria.Infra.RepModels.Shared.ValueObjects.NameRepModel", "ProfessionalRepModelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Monitoria.Infra.RepoModels.PetCare.Models.ProfessionalServicesAnimalRepModel", b =>
                {
                    b.HasOne("Monitoria.Infra.RepoModels.PetCare.Models.PetServicesRepModel", "PetService")
                        .WithOne("ProfessionalServicesAnimal")
                        .HasForeignKey("Monitoria.Infra.RepoModels.PetCare.Models.ProfessionalServicesAnimalRepModel", "PetServiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Monitoria.Infra.RepoModels.PetCare.Models.RowAnimalCareRepModel", "RowAnimalCare")
                        .WithMany("AnimailServices")
                        .HasForeignKey("RowAnimalCareId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Monitoria.Infra.RepoModels.PetCare.Models.ProfessionalRepModel", "Professional")
                        .WithOne("ProfessionalServicesAnimal")
                        .HasForeignKey("Monitoria.Infra.RepoModels.PetCare.Models.ProfessionalServicesAnimalRepModel", "professionalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
