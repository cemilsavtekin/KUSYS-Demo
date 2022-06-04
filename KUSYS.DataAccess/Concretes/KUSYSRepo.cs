using KUSYS.DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.DataAccess.Concretes
{
    public class KUSYSRepo : IRepository
    {
        private DbContext dbContext;

        public KUSYSRepo(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            dbContext.Add<T>(entity);
        }

        public void AddRange<T>(List<T> entities) where T : class
        {
            dbContext.AddRange(entities);
        }

        public T GetEntityObject<T>(int Id) where T : class, new()
        {
            return dbContext.Set<T>().Find(Id);
        }

        public T GetEntityObject<T>(Expression<Func<T, bool>> predicate) where T : class
        {            
            return dbContext.Set<T>().FirstOrDefault(predicate);
        }
            
        public IQueryable<T> GetIQueryableObject<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return dbContext.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetIQueryableObject<T>() where T : class
        {
            return dbContext.Set<T>(); 
        }

        public void Modify<T>(T entity) where T : class
        {
            var updatedEntity = dbContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
        }

        public void Remove<T>(T entity) where T : class
        {
           var deleted = dbContext.Remove(entity);
            deleted.State = EntityState.Deleted;
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
    }
}
