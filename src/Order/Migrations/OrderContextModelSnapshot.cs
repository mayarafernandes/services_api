﻿// <auto-generated />
using System;
using Company.Services.Order.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Company.Services.Order.Migrations
{
    [DbContext(typeof(OrderContext))]
    partial class OrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Company.Services.Model.Order.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalSpent")
                        .HasColumnType("REAL");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e2047c0a-a775-4225-87d2-0a9fe976b14d"),
                            TotalSpent = 10.0,
                            UserId = new Guid("220e7528-3cd7-493b-9ab3-d7f369bdb3dc")
                        },
                        new
                        {
                            Id = new Guid("b6371129-2e33-4e05-8783-2c9a500759b2"),
                            TotalSpent = 20.0,
                            UserId = new Guid("220e7528-3cd7-493b-9ab3-d7f369bdb3dc")
                        },
                        new
                        {
                            Id = new Guid("e458af4f-9403-4d52-a10d-4154e0a1ecf6"),
                            TotalSpent = 30.0,
                            UserId = new Guid("220e7528-3cd7-493b-9ab3-d7f369bdb3dc")
                        },
                        new
                        {
                            Id = new Guid("c57effb0-808c-4275-aaa1-528d0f79786b"),
                            TotalSpent = 150.0,
                            UserId = new Guid("b8b55a7b-c18a-4ee4-964b-f8f22bf93663")
                        },
                        new
                        {
                            Id = new Guid("4d3b8e1c-3c51-4c54-82c7-84950240d9a8"),
                            TotalSpent = 250.0,
                            UserId = new Guid("b8b55a7b-c18a-4ee4-964b-f8f22bf93663")
                        },
                        new
                        {
                            Id = new Guid("5180c8f8-f0d8-4250-aa48-d0205afc0d21"),
                            TotalSpent = 13.0,
                            UserId = new Guid("8fcf47f5-b08b-4f3c-a78f-38b0ffedc822")
                        },
                        new
                        {
                            Id = new Guid("5bc66b5f-9712-46aa-889d-174c601b4d75"),
                            TotalSpent = 7.0,
                            UserId = new Guid("f3a5e45f-c627-4588-8c76-9ce908c44fd8")
                        },
                        new
                        {
                            Id = new Guid("9cb0962e-4f2d-463f-a3e4-98f64c112175"),
                            TotalSpent = 30.0,
                            UserId = new Guid("f3a5e45f-c627-4588-8c76-9ce908c44fd8")
                        },
                        new
                        {
                            Id = new Guid("880bf22f-3668-448c-85f0-f26b0e804c10"),
                            TotalSpent = 1000.0,
                            UserId = new Guid("d131e104-6ddc-4470-8bdf-cf43833e216f")
                        },
                        new
                        {
                            Id = new Guid("9f01df01-a347-43e6-bab0-ccd37aabe638"),
                            TotalSpent = 250.0,
                            UserId = new Guid("d131e104-6ddc-4470-8bdf-cf43833e216f")
                        },
                        new
                        {
                            Id = new Guid("ee7b949f-f01f-4a30-8057-ebe8166d1060"),
                            TotalSpent = 250.0,
                            UserId = new Guid("d131e104-6ddc-4470-8bdf-cf43833e216f")
                        },
                        new
                        {
                            Id = new Guid("c876e2d0-f748-4994-b21a-c3b3c1c1f7cc"),
                            TotalSpent = 23.0,
                            UserId = new Guid("d131e104-6ddc-4470-8bdf-cf43833e216f")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
