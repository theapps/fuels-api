﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api.Database;

namespace api.Migrations
{
    [DbContext(typeof(AppDb))]
    [Migration("20181002174424_CtxUpdated")]
    partial class CtxUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("api.Domain.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsBlocked");

                    b.Property<string>("Telephone");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("api.Domain.Fuel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments")
                        .HasMaxLength(4000);

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsPartial");

                    b.Property<decimal>("Kms");

                    b.Property<decimal>("Litres");

                    b.Property<decimal>("Price");

                    b.Property<int>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Fuel");
                });

            modelBuilder.Entity("api.Domain.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");

                    b.HasData(
                        new { Id = 1, Name = "Benzina" },
                        new { Id = 2, Name = "Diesel" },
                        new { Id = 3, Name = "GPL" },
                        new { Id = 4, Name = "Hybrid" }
                    );
                });

            modelBuilder.Entity("api.Domain.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<string>("Comments")
                        .HasMaxLength(4000);

                    b.Property<int>("FuelTypeId");

                    b.Property<string>("Model");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("FuelTypeId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("api.Domain.Fuel", b =>
                {
                    b.HasOne("api.Domain.Vehicle", "Vehicle")
                        .WithMany("Fuels")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api.Domain.Vehicle", b =>
                {
                    b.HasOne("api.Domain.Account", "Account")
                        .WithMany("Vehicles")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api.Domain.FuelType", "FuelType")
                        .WithMany()
                        .HasForeignKey("FuelTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
