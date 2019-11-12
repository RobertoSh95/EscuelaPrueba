using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly EscuelaPruebaEntities Context = null;
        private DbSet<TEntity> EntitySet
        {
            get
            {
                //nos permite accesar al entity actual
                return Context.Set<TEntity>();
            }
        }

        public TEntity Create(TEntity toCreate)
        {
            TEntity result = null;
            try
            {
                EntitySet.Add(toCreate);
                Context.SaveChanges();
                result = toCreate;           
            }
            catch(Exception e)
            {

            }
            return result;
        }

        public bool Delete(TEntity toDelete)
        {
            bool result = false;
            try
            {
                EntitySet.Attach(toDelete);
                EntitySet.Remove(toDelete);
                result = Context.SaveChanges() > 0;
            }catch
            {

            }
            return result;
        }

        public void Dispose()
        {
            if(Context != null)
            {
                Context.Dispose();
            }
        }

        public List<TEntity> Filter(Expression<Func<TEntity, bool>> criteria)
        {
            List<TEntity> result = new List<TEntity>();
            try
            {
                result = EntitySet.Where(criteria).ToList();
            }
            catch
            {

            }
            return result;
        }

        public TEntity Retrieve(Expression<Func<TEntity, bool>> criteria)
        {
            TEntity result = null;
            try
            {
                result = EntitySet.FirstOrDefault(criteria);
            }catch
            {

            }
            return result;
        }

        public List<TEntity> RetrieveAllOrder(Expression<Func<TEntity, string>> criteria)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.OrderBy(criteria).ToList();
            }
            catch 
            {

            }
            return Result;
        }

        public bool Update(TEntity toUpdate)
        {
            bool result = false;
            try
            {
                EntitySet.Attach(toUpdate);
                Context.Entry<TEntity>(toUpdate).State = EntityState.Modified;
                result = Context.SaveChanges() > 0;
            }catch
            {

            }
            return result;
        }
    }
}
