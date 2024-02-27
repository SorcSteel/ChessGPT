using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChessGPT.PL.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameBoard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameState = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGame_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsComputer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUserGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserGame_Id", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameBoard", "GameName", "GameState", "GameTime" },
                values: new object[,]
                {
                    { new Guid("3ba2a104-25c2-408f-ab57-306137019512"), "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w", "First Game", "o", new DateTime(2024, 2, 26, 17, 46, 37, 834, DateTimeKind.Local).AddTicks(7727) },
                    { new Guid("5fab0ecc-8d69-4958-8ccb-540198d5c73c"), "rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b", "Second Game", "o", new DateTime(2024, 2, 26, 17, 46, 37, 834, DateTimeKind.Local).AddTicks(7772) },
                    { new Guid("8a9068dd-8e12-4203-819f-a21943fb0deb"), "4K3/4p3/Bk1p4/b4rP1/2R3p1/P3PP2/P3N3/5r2 w", "Third Game", "o", new DateTime(2024, 2, 26, 17, 46, 37, 834, DateTimeKind.Local).AddTicks(7774) }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "IsComputer", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("3bfd9f6f-0f8e-4050-be90-77bbd01fff59"), "Logan", false, "Vang", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", "500201348" },
                    { new Guid("8c2cca4b-4a90-4f52-9275-1ee96c77f6ab"), "Kaiden", false, "Brunke", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", "700233885" },
                    { new Guid("c1cb0628-b919-4297-a5bd-f86d1d9e3160"), "AI", true, "Robot", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", "Robot" }
                });

            migrationBuilder.InsertData(
                table: "tblUserGame",
                columns: new[] { "Id", "Color", "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0a3d230b-e8f2-4c32-bdc9-ef1d223fd0ce"), "b", new Guid("3ba2a104-25c2-408f-ab57-306137019512"), new Guid("3bfd9f6f-0f8e-4050-be90-77bbd01fff59") },
                    { new Guid("4cbde8b9-24ec-49a9-97c9-7f770982c03b"), "b", new Guid("5fab0ecc-8d69-4958-8ccb-540198d5c73c"), new Guid("8c2cca4b-4a90-4f52-9275-1ee96c77f6ab") },
                    { new Guid("6ea4a8b8-2540-4640-89bb-dbcd9f6b3745"), "b", new Guid("8a9068dd-8e12-4203-819f-a21943fb0deb"), new Guid("8c2cca4b-4a90-4f52-9275-1ee96c77f6ab") },
                    { new Guid("7e7a85e0-5b9d-4582-8e27-29878a91ee4d"), "w", new Guid("8a9068dd-8e12-4203-819f-a21943fb0deb"), new Guid("c1cb0628-b919-4297-a5bd-f86d1d9e3160") },
                    { new Guid("97dab6a7-4072-40ec-8654-a02f76d020a4"), "w", new Guid("5fab0ecc-8d69-4958-8ccb-540198d5c73c"), new Guid("3bfd9f6f-0f8e-4050-be90-77bbd01fff59") },
                    { new Guid("d03b2de2-b2ad-4df1-8ed0-936c967ea1bf"), "w", new Guid("3ba2a104-25c2-408f-ab57-306137019512"), new Guid("8c2cca4b-4a90-4f52-9275-1ee96c77f6ab") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblGame");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblUserGame");
        }
    }
}
