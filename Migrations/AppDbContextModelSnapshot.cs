﻿// <auto-generated />
using System;
using Grocery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Grocery.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Grocery.Models.ProductBrand", b =>
                {
                    b.Property<long>("ProdBrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BigInt")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProdBrandDesc")
                        .HasColumnType("nVarChar(70)")
                        .HasMaxLength(70);

                    b.Property<int>("ProdBrandIndex")
                        .HasColumnType("Int")
                        .HasMaxLength(4);

                    b.Property<string>("ProdBrandName")
                        .IsRequired()
                        .HasColumnType("nVarChar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ProdBrandID");

                    b.ToTable("ProductBrand");
                });

            modelBuilder.Entity("Grocery.Models.ProductCategory", b =>
                {
                    b.Property<long>("ProdCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BigInt")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProdCategoryDesc")
                        .HasColumnType("nVarChar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("ProdCategoryIndex")
                        .HasColumnType("Int")
                        .HasMaxLength(3);

                    b.Property<string>("ProdCategoryName")
                        .IsRequired()
                        .HasColumnType("nVarChar(30)")
                        .HasMaxLength(30);

                    b.HasKey("ProdCategoryID");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("Grocery.Models.Products", b =>
                {
                    b.Property<long>("ProdID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BigInt")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ProdBrandID")
                        .HasColumnType("bigint");

                    b.Property<long>("ProdCategoryID")
                        .HasColumnType("bigint");

                    b.Property<string>("ProdDesc")
                        .IsRequired()
                        .HasColumnType("nVarChar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ProdImageName")
                        .HasColumnType("nVarChar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ProdName")
                        .IsRequired()
                        .HasColumnType("nVarChar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ProdNotes")
                        .HasColumnType("nVarChar(512)")
                        .HasMaxLength(512);

                    b.Property<string>("ProdNum")
                        .IsRequired()
                        .HasColumnType("nVarChar(20)")
                        .HasMaxLength(20);

                    b.Property<long?>("ProductBrandProdBrandID")
                        .HasColumnType("BigInt");

                    b.Property<long?>("ProductCategoryProdCategoryID")
                        .HasColumnType("BigInt");

                    b.Property<long>("UOMID")
                        .HasColumnType("bigint");

                    b.Property<long?>("UnitsOfMeasurementUOMID")
                        .HasColumnType("BigInt");

                    b.HasKey("ProdID");

                    b.HasIndex("ProductBrandProdBrandID");

                    b.HasIndex("ProductCategoryProdCategoryID");

                    b.HasIndex("UnitsOfMeasurementUOMID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Grocery.Models.UnitsOfMeasurement", b =>
                {
                    b.Property<long>("UOMID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BigInt")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UOMDesc")
                        .HasColumnType("nVarChar(40)")
                        .HasMaxLength(40);

                    b.Property<int>("UOMIndex")
                        .HasColumnType("Int")
                        .HasMaxLength(2);

                    b.Property<string>("UOMName")
                        .IsRequired()
                        .HasColumnType("nVarChar(10)")
                        .HasMaxLength(10);

                    b.HasKey("UOMID");

                    b.ToTable("UnitsOfMeasurement");
                });

            modelBuilder.Entity("Grocery.Models.Products", b =>
                {
                    b.HasOne("Grocery.Models.ProductBrand", "ProductBrand")
                        .WithMany()
                        .HasForeignKey("ProductBrandProdBrandID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Grocery.Models.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryProdCategoryID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Grocery.Models.UnitsOfMeasurement", "UnitsOfMeasurement")
                        .WithMany()
                        .HasForeignKey("UnitsOfMeasurementUOMID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
