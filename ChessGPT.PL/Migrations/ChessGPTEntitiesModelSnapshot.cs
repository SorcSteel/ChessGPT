﻿// <auto-generated />
using System;
using ChessGPT.PL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChessGPT.PL.Migrations
{
    [DbContext(typeof(ChessGPTEntities))]
    partial class ChessGPTEntitiesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChessGPT.PL.Entities.spGetOpenGames", b =>
                {
                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable("spGetOpenGames");
                });

            modelBuilder.Entity("ChessGPT.PL.Entities.tblGame", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GameBoard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameState")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("GameTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("PK_tblGame_Id");

                    b.ToTable("tblGame", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("337c82f3-bed7-4322-ae47-1bf720613b9b"),
                            GameBoard = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w",
                            GameName = "First Game",
                            GameState = "o",
                            GameTime = new DateTime(2024, 4, 30, 2, 12, 17, 912, DateTimeKind.Local).AddTicks(6731)
                        },
                        new
                        {
                            Id = new Guid("4f18cc52-d321-4ad9-9a3b-39b159852f59"),
                            GameBoard = "rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b",
                            GameName = "Second Game",
                            GameState = "o",
                            GameTime = new DateTime(2024, 4, 30, 2, 12, 17, 912, DateTimeKind.Local).AddTicks(6778)
                        },
                        new
                        {
                            Id = new Guid("9c2c0e5f-5828-4d46-af00-6b41bfd14c06"),
                            GameBoard = "4K3/4p3/Bk1p4/b4rP1/2R3p1/P3PP2/P3N3/5r2 w",
                            GameName = "Third Game",
                            GameState = "o",
                            GameTime = new DateTime(2024, 4, 30, 2, 12, 17, 912, DateTimeKind.Local).AddTicks(6781)
                        });
                });

            modelBuilder.Entity("ChessGPT.PL.Entities.tblUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsComputer")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_tblUser_Id");

                    b.ToTable("tblUser", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("271695df-c291-49ab-8953-242bdf83a40e"),
                            FirstName = "Kaiden",
                            IsComputer = false,
                            LastName = "Brunke",
                            Password = "W6ph5Mm5Pz8GgiULbPgzG37mj9g=",
                            UserName = "700233885"
                        },
                        new
                        {
                            Id = new Guid("e96b63e5-75fa-40f4-8ae7-e5aa3ff8227d"),
                            FirstName = "Logan",
                            IsComputer = false,
                            LastName = "Vang",
                            Password = "W6ph5Mm5Pz8GgiULbPgzG37mj9g=",
                            UserName = "500201348"
                        },
                        new
                        {
                            Id = new Guid("fc9b03e0-432c-4f5e-8604-423c1a90d03d"),
                            FirstName = "AI",
                            IsComputer = true,
                            LastName = "Robot",
                            Password = "W6ph5Mm5Pz8GgiULbPgzG37mj9g=",
                            UserName = "Robot"
                        });
                });

            modelBuilder.Entity("ChessGPT.PL.Entities.tblUserGame", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_tblUserGame_Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("tblUserGame", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ed7371bc-5dea-41e5-a944-089d872bca28"),
                            Color = "w",
                            GameId = new Guid("337c82f3-bed7-4322-ae47-1bf720613b9b"),
                            UserId = new Guid("271695df-c291-49ab-8953-242bdf83a40e")
                        },
                        new
                        {
                            Id = new Guid("76270a90-78b1-4101-bbcb-67c5fadcce64"),
                            Color = "b",
                            GameId = new Guid("337c82f3-bed7-4322-ae47-1bf720613b9b"),
                            UserId = new Guid("e96b63e5-75fa-40f4-8ae7-e5aa3ff8227d")
                        },
                        new
                        {
                            Id = new Guid("41f09a0b-7f4c-4258-808f-3929ec929556"),
                            Color = "b",
                            GameId = new Guid("4f18cc52-d321-4ad9-9a3b-39b159852f59"),
                            UserId = new Guid("271695df-c291-49ab-8953-242bdf83a40e")
                        },
                        new
                        {
                            Id = new Guid("6799f611-d3a9-4e59-acd0-4e8e1a6ce4db"),
                            Color = "w",
                            GameId = new Guid("4f18cc52-d321-4ad9-9a3b-39b159852f59"),
                            UserId = new Guid("e96b63e5-75fa-40f4-8ae7-e5aa3ff8227d")
                        },
                        new
                        {
                            Id = new Guid("a3c5158b-942b-49a4-aed5-50a65c4cdd0d"),
                            Color = "w",
                            GameId = new Guid("9c2c0e5f-5828-4d46-af00-6b41bfd14c06"),
                            UserId = new Guid("fc9b03e0-432c-4f5e-8604-423c1a90d03d")
                        },
                        new
                        {
                            Id = new Guid("d1c3bae6-08ed-4003-9913-cfe8a1a9d2ba"),
                            Color = "b",
                            GameId = new Guid("9c2c0e5f-5828-4d46-af00-6b41bfd14c06"),
                            UserId = new Guid("271695df-c291-49ab-8953-242bdf83a40e")
                        });
                });

            modelBuilder.Entity("ChessGPT.PL.Entities.tblUserGame", b =>
                {
                    b.HasOne("ChessGPT.PL.Entities.tblGame", "Game")
                        .WithMany("UserGames")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("fk_tblUserGame_GameId");

                    b.HasOne("ChessGPT.PL.Entities.tblUser", "User")
                        .WithMany("UserGames")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("fk_tblUserGame_UserId");

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChessGPT.PL.Entities.tblGame", b =>
                {
                    b.Navigation("UserGames");
                });

            modelBuilder.Entity("ChessGPT.PL.Entities.tblUser", b =>
                {
                    b.Navigation("UserGames");
                });
#pragma warning restore 612, 618
        }
    }
}
