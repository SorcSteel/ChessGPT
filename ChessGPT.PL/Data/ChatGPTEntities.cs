using ChessGPT.PL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace ChessGPT.PL.Data
{
    public class ChatGPTEntities : DbContext
    {
        Guid[] userId = new Guid[2];
        Guid[] gameId = new Guid[2];
        Guid[] userGameId = new Guid[5];

        public DbSet<tblUser> tblUsers {  get; set; }
        public DbSet<tblGame> tblGames { get; set; }
        public DbSet<tblUserGame> tblUserGames { get; set; }

        public ChatGPTEntities(DbContextOptions<ChatGPTEntities> options) : base(options)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public ChatGPTEntities()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            CreateUsers(modelBuilder);
            CreateGames(modelBuilder);
            CreateUserGames(modelBuilder);
        }

        private void CreateUsers(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < userId.Length; i++)
                userId[i] = Guid.NewGuid();


            modelBuilder.Entity<tblUser>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblUser_Id");

                entity.ToTable("tblUser");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.FirstName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.UserName);
                entity.Property(e => e.Password);
                entity.Property(e => e.IsComputer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            List<tblUser> Users = new List<tblUser>
            {
                new tblUser {Id = userId[0], FirstName = "Kaiden", LastName = "Brunke", UserName = "700233885", Password = "password", IsComputer = false},

                new tblUser {Id = userId[1], FirstName = "Logan", LastName = "Vang", UserName = "500201348", Password = "password", IsComputer = false},

                new tblUser {Id = userId[2], FirstName = "AI", LastName = "Robot", UserName = "Robot", Password = "password", IsComputer = true},
            };
            modelBuilder.Entity<tblUser>().HasData(Users);
        }

        private void CreateGames(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < userId.Length; i++)
                userId[i] = Guid.NewGuid();


            modelBuilder.Entity<tblGame>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblGame_Id");

                entity.ToTable("tblGame");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.GameName);
                entity.Property(e => e.GameTime);
                entity.Property(e => e.GameBoard);
                entity.Property(e => e.GameState)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            List<tblGame> Games = new List<tblGame>
            {
                new tblGame {Id = gameId[0], GameName = "First Game", GameTime = DateTime.Now, GameBoard = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w", GameState = 'o'},

                new tblGame {Id = gameId[1], GameName = "Second Game", GameTime = DateTime.Now, GameBoard = "rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b", GameState = 'o'},

                new tblGame {Id = gameId[2], GameName = "Third Game", GameTime = DateTime.Now, GameBoard = "4K3/4p3/Bk1p4/b4rP1/2R3p1/P3PP2/P3N3/5r2 w", GameState = 'o'},
            };
            modelBuilder.Entity<tblGame>().HasData(Games);
        }

        private void CreateUserGames(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < userGameId.Length; i++)
                userGameId[i] = Guid.NewGuid();


            modelBuilder.Entity<tblUserGame>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblUserGame_Id");

                entity.ToTable("tblUserGame");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.UserId);
                entity.Property(e => e.GameId);
                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                  .WithMany(p => p.UserGames)
                  .HasForeignKey(d => d.UserId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("fk_tblUserGame_UserId");

                entity.HasOne(d => d.Game)
                  .WithMany(p => p.UserGames)
                  .HasForeignKey(d => d.GameId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("fk_tblUserGame_GameId");
            });

            List<tblUserGame> UserGames = new List<tblUserGame>
            {
                new tblUserGame {Id = userGameId[0], UserId = userId[0], GameId = gameId[0], Color = 'w'},

                new tblUserGame {Id = userGameId[1], UserId = userId[1], GameId = gameId[0], Color = 'b'},

                new tblUserGame {Id = userGameId[2], UserId = userId[0], GameId = gameId[1], Color = 'b'},

                new tblUserGame {Id = userGameId[3], UserId = userId[1], GameId = gameId[1], Color = 'w'},

                new tblUserGame {Id = userGameId[4], UserId = userId[2], GameId = gameId[2], Color = 'w'},

                new tblUserGame {Id = userGameId[5], UserId = userId[0], GameId = gameId[2], Color = 'w'},
            };
            modelBuilder.Entity<tblUserGame>().HasData(UserGames);
        }

        private static string GetHash(string Password)
        {
            using (var hasher = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }
    }
}
