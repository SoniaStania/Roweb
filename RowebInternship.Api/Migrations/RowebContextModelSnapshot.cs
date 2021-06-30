﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RowebInternship.Api.Data;

namespace RowebInternship.Api.Migrations
{
    [DbContext(typeof(RowebContext))]
    partial class RowebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RowebInternship.Api.Domain.Category", b =>
                {
                    b.Property<long>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1L,
                            Description = "Superstar",
                            Name = "Adidas"
                        },
                        new
                        {
                            CategoryID = 2L,
                            Description = "AirForce1",
                            Name = "Nike"
                        },
                        new
                        {
                            CategoryID = 3L,
                            Description = "Running",
                            Name = "Puma"
                        });
                });

            modelBuilder.Entity("RowebInternship.Api.Domain.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BasePrice")
                        .HasColumnType("int");

                    b.Property<long>("CategoryID")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1L,
                            BasePrice = 550,
                            CategoryID = 1L,
                            Description = "Superstar",
                            Image = "superstar.jpg",
                            Name = "Adidas",
                            Price = 400
                        },
                        new
                        {
                            ProductId = 2L,
                            BasePrice = 600,
                            CategoryID = 2L,
                            Description = "AF1",
                            Image = "af1.jpg",
                            Name = "Nike",
                            Price = 500
                        },
                        new
                        {
                            ProductId = 3L,
                            BasePrice = 550,
                            CategoryID = 3L,
                            Description = "Running",
                            Image = "puma.jpg",
                            Name = "Puma",
                            Price = 400
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
