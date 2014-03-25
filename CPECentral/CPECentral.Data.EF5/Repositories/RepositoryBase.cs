#region Using directives

using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public abstract class RepositoryBase<T> where T : class, IEntity
    {
        protected readonly UnitOfWork UnitOfWork;

        protected RepositoryBase(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual T GetById(int id)
        {
            return GetSet().FirstOrDefault(e => e.Id == id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return GetSet().ToList();
        }

        public virtual void Add(T entity)
        {
            UnitOfWork.Entities.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            Attach(entity, EntityState.Modified);

            // add to list of entities to detach to enable future updates
            UnitOfWork.EntitiesToDetach.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            Attach(entity, EntityState.Deleted);
        }

        private void Attach<TEntity>(TEntity entity, EntityState attachState) where TEntity : class, IEntity
        {
            UnitOfWork.Entities.Set<TEntity>().Attach(entity);

            var entry = UnitOfWork.Entities.Entry(entity);

            entry.State = attachState;
        }

        protected DbQuery<T> GetSet()
        {
            return UnitOfWork.Entities.Set<T>().AsNoTracking();
        }
    }
}