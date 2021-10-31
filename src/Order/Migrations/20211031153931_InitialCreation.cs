using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Services.Order.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TotalSpent = table.Column<double>(type: "REAL", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "TotalSpent", "UserId" },
                values: new object[] { new Guid("e2047c0a-a775-4225-87d2-0a9fe976b14d"), 10.0, new Guid("220e7528-3cd7-493b-9ab3-d7f369bdb3dc") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "TotalSpent", "UserId" },
                values: new object[] { new Guid("b6371129-2e33-4e05-8783-2c9a500759b2"), 20.0, new Guid("220e7528-3cd7-493b-9ab3-d7f369bdb3dc") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "TotalSpent", "UserId" },
                values: new object[] { new Guid("e458af4f-9403-4d52-a10d-4154e0a1ecf6"), 30.0, new Guid("220e7528-3cd7-493b-9ab3-d7f369bdb3dc") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "TotalSpent", "UserId" },
                values: new object[] { new Guid("c57effb0-808c-4275-aaa1-528d0f79786b"), 150.0, new Guid("b8b55a7b-c18a-4ee4-964b-f8f22bf93663") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "TotalSpent", "UserId" },
                values: new object[] { new Guid("4d3b8e1c-3c51-4c54-82c7-84950240d9a8"), 250.0, new Guid("b8b55a7b-c18a-4ee4-964b-f8f22bf93663") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "TotalSpent", "UserId" },
                values: new object[] { new Guid("5180c8f8-f0d8-4250-aa48-d0205afc0d21"), 13.0, new Guid("8fcf47f5-b08b-4f3c-a78f-38b0ffedc822") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "TotalSpent", "UserId" },
                values: new object[] { new Guid("5bc66b5f-9712-46aa-889d-174c601b4d75"), 7.0, new Guid("f3a5e45f-c627-4588-8c76-9ce908c44fd8") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "TotalSpent", "UserId" },
                values: new object[] { new Guid("9cb0962e-4f2d-463f-a3e4-98f64c112175"), 30.0, new Guid("f3a5e45f-c627-4588-8c76-9ce908c44fd8") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "TotalSpent", "UserId" },
                values: new object[] { new Guid("880bf22f-3668-448c-85f0-f26b0e804c10"), 1000.0, new Guid("d131e104-6ddc-4470-8bdf-cf43833e216f") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "TotalSpent", "UserId" },
                values: new object[] { new Guid("9f01df01-a347-43e6-bab0-ccd37aabe638"), 250.0, new Guid("d131e104-6ddc-4470-8bdf-cf43833e216f") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "TotalSpent", "UserId" },
                values: new object[] { new Guid("ee7b949f-f01f-4a30-8057-ebe8166d1060"), 250.0, new Guid("d131e104-6ddc-4470-8bdf-cf43833e216f") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "TotalSpent", "UserId" },
                values: new object[] { new Guid("c876e2d0-f748-4994-b21a-c3b3c1c1f7cc"), 23.0, new Guid("d131e104-6ddc-4470-8bdf-cf43833e216f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
