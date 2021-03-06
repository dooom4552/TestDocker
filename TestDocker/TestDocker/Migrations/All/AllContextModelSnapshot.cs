﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestDocker.Data;

namespace TestDocker.Migrations.All
{
    [DbContext(typeof(AllContext))]
    partial class AllContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TestDocker.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fratelli Barri"
                        });
                });

            modelBuilder.Entity("TestDocker.Models.BrandCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("BrandCollections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            Name = "Florence"
                        });
                });

            modelBuilder.Entity("TestDocker.Models.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("TestDocker.Models.Finishing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Finishings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CollectionId = 1,
                            Name = "Silver "
                        });
                });

            modelBuilder.Entity("TestDocker.Models.FurnitureName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("FurnitureNames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CollectionId = 1,
                            Name = "Side Table"
                        });
                });

            modelBuilder.Entity("TestDocker.Models.FurnitureType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("FurnitureTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Стол"
                        });
                });

            modelBuilder.Entity("TestDocker.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountantNameId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("BuyerName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ComeDataTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ComeDocumentName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("ComePrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("ContractGiveOutName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("FinishingId")
                        .HasColumnType("int");

                    b.Property<int>("FurnitureNameId")
                        .HasColumnType("int");

                    b.Property<int>("FurnitureTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("GiveOutDataTime")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("GiveOutPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("ManagerNameId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ProductListId")
                        .HasColumnType("int");

                    b.Property<string>("ScoreGiveOutName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("StorekeeperComeNameId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("StorekeeperGiveOutNameId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TestDocker.Models.ProductList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<int>("FinishingId")
                        .HasColumnType("int");

                    b.Property<int>("FurnitureNameId")
                        .HasColumnType("int");

                    b.Property<int>("FurnitureTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductLists");
                });
#pragma warning restore 612, 618
        }
    }
}
