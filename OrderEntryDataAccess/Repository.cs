using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrderEntryEngine;

namespace OrderEntryDataAccess
{
    public class Repository<T> : IRepository
        where T : class, IEntity
    {
        private DbSet<T> dataset;

        public Repository(DbSet<T> dataset)
        {
            this.dataset = dataset;
        }

        public event EventHandler<EntityEventArgs<T>> EntityAdded;

        public event EventHandler<EntityEventArgs<T>> EntityRemoved;

        public void AddEntity(T entity)
        {
            if (!this.ContainsEntity(entity))
            {
                this.dataset.Add(entity);

                if (this.EntityAdded != null)
                {
                    this.EntityAdded(this, new EntityEventArgs<T>(entity));
                }
            }
        }

        public bool ContainsEntity(T entity)
        {
            return this.GetEntity(entity.Id) != null;
        }

        public T GetEntity(int id)
        {
            T entity = this.dataset.Find(id);
            return this.dataset.Find(id);
        }

        public List<T> GetEntities()
        {
            return this.dataset.Where(e => !e.IsArchived).ToList();
        }

        public void RemoveEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entity.IsArchived = true;

            if (this.EntityRemoved != null)
            {
                this.EntityRemoved(this, new EntityEventArgs<T>(entity));
            }
        }

        public void SaveToDatabase()
        {
            RepositoryManager.Context.SaveChanges();
        }
    }
}