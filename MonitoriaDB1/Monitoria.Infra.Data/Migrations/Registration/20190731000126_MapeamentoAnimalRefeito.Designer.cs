﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monitoria.Infra.Data.Contexts;

namespace Monitoria.Infra.Data.Migrations.Registration
{
    [DbContext(typeof(RegistrationContext))]
    [Migration("20190731000126_MapeamentoAnimalRefeito")]
    partial class MapeamentoAnimalRefeito
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Registration")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Monitoria.Infra.RepoModels.Registration.Models.AnimalRepModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age")
                        .HasColumnName("Age");

                    b.Property<Guid>("CustomerId");

                    b.Property<bool>("IsAlive")
                        .HasColumnName("IsAlive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(40);

                    b.Property<int>("Specie")
                        .HasColumnName("Specie");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("Monitoria.Infra.RepoModels.Registration.Models.CustomerRepModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Monitoria.Infra.RepoModels.Registration.Models.AnimalRepModel", b =>
                {
                    b.HasOne("Monitoria.Infra.RepoModels.Registration.Models.CustomerRepModel", "Customer")
                        .WithMany("Animails")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoria.Infra.RepoModels.Registration.Models.CustomerRepModel", b =>
                {
                    b.OwnsOne("Monitoria.Infra.RepModels.Shared.ValueObjects.AddressRepModel", "Address", b1 =>
                        {
                            b1.Property<Guid>("CustomerRepModelId");

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

                            b1.HasKey("CustomerRepModelId");

                            b1.ToTable("Customer","Registration");

                            b1.HasOne("Monitoria.Infra.RepoModels.Registration.Models.CustomerRepModel")
                                .WithOne("Address")
                                .HasForeignKey("Monitoria.Infra.RepModels.Shared.ValueObjects.AddressRepModel", "CustomerRepModelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Monitoria.Infra.RepModels.Shared.ValueObjects.DocumentRepModel", "Document", b1 =>
                        {
                            b1.Property<Guid>("CustomerRepModelId");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnName("DocNumber")
                                .HasMaxLength(50);

                            b1.Property<int>("Type")
                                .HasColumnName("DocType");

                            b1.HasKey("CustomerRepModelId");

                            b1.ToTable("Customer","Registration");

                            b1.HasOne("Monitoria.Infra.RepoModels.Registration.Models.CustomerRepModel")
                                .WithOne("Document")
                                .HasForeignKey("Monitoria.Infra.RepModels.Shared.ValueObjects.DocumentRepModel", "CustomerRepModelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Monitoria.Infra.RepModels.Shared.ValueObjects.EmailRepModel", "Email", b1 =>
                        {
                            b1.Property<Guid>("CustomerRepModelId");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnName("EmailAddress")
                                .HasMaxLength(60);

                            b1.HasKey("CustomerRepModelId");

                            b1.ToTable("Customer","Registration");

                            b1.HasOne("Monitoria.Infra.RepoModels.Registration.Models.CustomerRepModel")
                                .WithOne("Email")
                                .HasForeignKey("Monitoria.Infra.RepModels.Shared.ValueObjects.EmailRepModel", "CustomerRepModelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Monitoria.Infra.RepModels.Shared.ValueObjects.NameRepModel", "Name", b1 =>
                        {
                            b1.Property<Guid>("CustomerRepModelId");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnName("FirstName")
                                .HasMaxLength(50);

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnName("LastName")
                                .HasMaxLength(50);

                            b1.HasKey("CustomerRepModelId");

                            b1.ToTable("Customer","Registration");

                            b1.HasOne("Monitoria.Infra.RepoModels.Registration.Models.CustomerRepModel")
                                .WithOne("Name")
                                .HasForeignKey("Monitoria.Infra.RepModels.Shared.ValueObjects.NameRepModel", "CustomerRepModelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
