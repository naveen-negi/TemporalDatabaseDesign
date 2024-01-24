﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProductPricing.API.Entities;

#nullable disable

namespace ProductPricing.API.Migrations
{
    [DbContext(typeof(TariffDBContext))]
    [Migration("20240123103222_InitialDBSchema")]
    partial class InitialDBSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProductPricing.API.Entities.Tariff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PricePerHour")
                        .HasColumnType("integer");

                    b.Property<int>("TaxBasisPoints")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Tariffs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("81789ace-8456-47fb-8d74-0609c939b927"),
                            LocationId = "1234",
                            PricePerHour = 2,
                            TaxBasisPoints = 1900,
                            ValidFrom = new DateTime(2023, 1, 23, 10, 32, 22, 743, DateTimeKind.Utc).AddTicks(3860),
                            ValidTo = new DateTime(2025, 1, 22, 10, 32, 22, 743, DateTimeKind.Utc).AddTicks(3920)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
