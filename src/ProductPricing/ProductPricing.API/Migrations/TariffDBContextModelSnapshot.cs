﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;
using ProductPricing.API.Entities;

#nullable disable

namespace ProductPricing.API.Migrations
{
    [DbContext(typeof(TariffDBContext))]
    partial class TariffDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProductPricing.API.Entities.CurrentTariff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PricePerHour")
                        .HasColumnType("integer");

                    b.Property<NpgsqlRange<DateTime>>("PriceSince")
                        .HasColumnType("daterange");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CurrentTariffs");
                });

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
                });

            modelBuilder.Entity("ProductPricing.API.Entities.TriggerLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ActionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TriggerLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
