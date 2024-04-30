using ChessGPT.BL.Models;
using ChessGPT.PL.Data;
using ChessGPT.PL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace ChessGPT.BL
{
    public abstract class GenericManager<T> where T : class, IEntity
    {
        protected DbContextOptions<ChessGPTEntities> options;

        protected readonly ILogger logger;
        public GenericManager(DbContextOptions<ChessGPTEntities> options)
        {
            this.options = options;
        }
        public GenericManager(ILogger logger,
                              DbContextOptions<ChessGPTEntities> options)
        {
            this.options = options;
            this.logger = logger;
        }


        public GenericManager() { }

        public List<T> Load()
        {
            try
            {
                if (logger != null) logger.LogWarning($"Getting {typeof(T).Name}s");
                return new ChessGPTEntities(options)
                    .Set<T>()
                    .ToList<T>();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T> Load(string storedproc)
        {
            try
            {
                return new ChessGPTEntities(options)
                    .Set<T>()
                    .FromSqlRaw($"exec {storedproc}")
                    .ToList<T>()
                    .OrderBy(x => x.Id)
                    .ToList<T>();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public T LoadById(Guid id)
        {
            try
            {
                var row = new ChessGPTEntities(options).Set<T>().Where(t => t.Id == id).FirstOrDefault();
                if (logger != null) logger.LogWarning("Cannot Insert or Row Already Exists");
                return row;
            }
            catch (Exception)
            {

                if (logger != null) logger.LogWarning("Row doesn't exist");
                throw;
            }
        }
        public int Insert(T entity, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ChessGPTEntities dc = new ChessGPTEntities(options))
                {

                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    entity.Id = Guid.NewGuid();

                    dc.Set<T>().Add(entity);
                    results = dc.SaveChanges();

                    if (logger != null) logger.LogWarning("Inserted Row");
                    if (rollback) dbTransaction.Rollback();

                }

                return results;
            }
            catch (Exception)
            {
                if (logger != null) logger.LogWarning("Cannot insert or row already exists");
                throw;
            }
        }

        public int Update(T entity, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ChessGPTEntities dc = new ChessGPTEntities(options))
                {
                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    dc.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    results = dc.SaveChanges();

                    if (logger != null) logger.LogWarning("Updated Row");
                    if (rollback) dbTransaction.Rollback();

                }

                return results;
            }
            catch (Exception)
            {
                if (logger != null) logger.LogWarning("Cannot update or row doesnt exist");
                throw;
            }
        }
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ChessGPTEntities dc = new ChessGPTEntities(options))
                {
                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    T row = dc.Set<T>().FirstOrDefault(t => t.Id == id);

                    if (row != null)
                    {
                        dc.Set<T>().Remove(row);
                        results = dc.SaveChanges();
                        if (logger != null) logger.LogWarning("Deleting row");
                        if (rollback) dbTransaction.Rollback();
                    }
                    else
                    {
                        if (logger != null) logger.LogWarning("Row does not exist");
                        throw new Exception("Row does not exist.");
                    }

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}
