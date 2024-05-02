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
                    table.ForeignKey(
                        name: "fk_tblUserGame_GameId",
                        column: x => x.GameId,
                        principalTable: "tblGame",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblUserGame_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameBoard", "GameName", "GameState", "GameTime" },
                values: new object[,]
                {
                    { new Guid("96349c24-a518-4487-a6ff-a2429ecf2576"), "rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b", "Second Game", "o", new DateTime(2024, 3, 5, 23, 41, 29, 82, DateTimeKind.Local).AddTicks(5616) },
                    { new Guid("d5e0db1c-85a1-4160-9bb7-4c28db12bf11"), "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w", "First Game", "o", new DateTime(2024, 3, 5, 23, 41, 29, 82, DateTimeKind.Local).AddTicks(5573) },
                    { new Guid("fcd90fc6-ddf3-44d5-acda-c2c420e0a087"), "4K3/4p3/Bk1p4/b4rP1/2R3p1/P3PP2/P3N3/5r2 w", "Third Game", "o", new DateTime(2024, 3, 5, 23, 41, 29, 82, DateTimeKind.Local).AddTicks(5617) }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "IsComputer", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("1ce9a108-70e3-4c1c-a89c-4731713698a8"), "AI", true, "Robot", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", "Robot" },
                    { new Guid("4882ba82-2809-4f40-848d-5230a1d398de"), "Kaiden", false, "Brunke", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", "700233885" },
                    { new Guid("93c75571-43c9-4085-8736-e55b02df011b"), "Logan", false, "Vang", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", "500201348" }
                });

            migrationBuilder.InsertData(
                table: "tblUserGame",
                columns: new[] { "Id", "Color", "GameId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1f3db302-079f-424b-93aa-997b7d1ac96b"), "w", new Guid("fcd90fc6-ddf3-44d5-acda-c2c420e0a087"), new Guid("1ce9a108-70e3-4c1c-a89c-4731713698a8") },
                    { new Guid("212476c1-3fa4-4648-9d9c-1cdbb199f59a"), "b", new Guid("96349c24-a518-4487-a6ff-a2429ecf2576"), new Guid("4882ba82-2809-4f40-848d-5230a1d398de") },
                    { new Guid("76cbbef8-1d4b-45dd-a2a1-5b0d593c89a4"), "b", new Guid("d5e0db1c-85a1-4160-9bb7-4c28db12bf11"), new Guid("93c75571-43c9-4085-8736-e55b02df011b") },
                    { new Guid("8692bb05-83dd-4f0d-b2bf-8d1507690109"), "w", new Guid("d5e0db1c-85a1-4160-9bb7-4c28db12bf11"), new Guid("4882ba82-2809-4f40-848d-5230a1d398de") },
                    { new Guid("ad8f6a22-c3d7-41a9-8872-faf17e0415db"), "w", new Guid("96349c24-a518-4487-a6ff-a2429ecf2576"), new Guid("93c75571-43c9-4085-8736-e55b02df011b") },
                    { new Guid("c1602f17-23a9-4ef9-9461-c2eb7cd9a912"), "b", new Guid("fcd90fc6-ddf3-44d5-acda-c2c420e0a087"), new Guid("4882ba82-2809-4f40-848d-5230a1d398de") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblUserGame_GameId",
                table: "tblUserGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserGame_UserId",
                table: "tblUserGame",
                column: "UserId"); 
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[spGetOpenGames]
                AS
                    select * from tblGame
                    where id in (select distinct gameid as Id
                    from tblusergame
                    group by gameid
                    having count(color) = 1);
                RETURN 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblUserGame");

            migrationBuilder.DropTable(
                name: "tblGame");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
