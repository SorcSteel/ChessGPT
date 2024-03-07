using ChessGPT.BL.Models;
using ChessGPT.PL.Data;
using ChessGPT.PL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ChessGPT.BL
{
    public class UserManager : GenericManager<tblUser>
    {
        public UserManager(DbContextOptions<ChessGPTEntities> options) : base(options) { }

        private string GetHash(string Password)
        {
            using (var hasher = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }

        public List<User> Load()
        {
            try
            {
                List<User> users = new List<User>();

                base.Load()
                    .ForEach(u => users
                    .Add(new User
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        UserName = u.UserName,
                        Password = u.Password,
                        IsComputer = u.IsComputer,
                    }));

                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User LoadById(Guid id)
        {
            try
            {
                tblUser row = base.LoadById(id);

                if (row != null)
                {
                    User user = new User
                    {
                        Id = row.Id,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        UserName = row.UserName,
                        Password = row.Password,
                        IsComputer = row.IsComputer,
                    };

                    return user;
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(User user, bool rollback = false)
        {
            try
            {
                tblUser row = new tblUser { FirstName = user.FirstName, LastName = user.LastName, UserName = user.UserName, Password = user.Password, IsComputer = user.IsComputer };
                user.Id = row.Id;
                return base.Insert(row, rollback);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(User user, bool rollback = false)
        { 

            try
            {
                int results = base.Update(new tblUser
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Password = user.Password,
                    IsComputer = user.IsComputer,
                }, rollback);
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return base.Delete(id, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

