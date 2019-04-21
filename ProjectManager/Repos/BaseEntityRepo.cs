using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectManager.Repos
{
    public class BaseEntityRepo<Entity>
        where Entity : BaseEntity
    {
        private PMDbContext Context { get; set; }
        private DbSet<Entity> Items { get; set; }

        public BaseEntityRepo()
        {
            Context = new PMDbContext();
            Items = Context.Set<Entity>();
        }

        // I. Get (Read, Retrieve)
        // 1. GetById
        public Entity GetById(int id)
        {
            return Items
                    .Where(i => i.Id == id)
                    .FirstOrDefault();
        }

        // 2. GetFirstOrDefault (by filter)
        public Entity GetFirstOrDefault(
            Expression<Func<Entity, bool>> filter
            )
        {
            return Items
                    .Where(filter)
                    .FirstOrDefault();
        }

        // 3. GetAll
        public List<Entity> GetAll(
            Expression<Func<Entity, bool>> filter = null,
            int page = 1,
            int itemsPerPage = int.MaxValue)
        {
            IQueryable<Entity> query = Items;

            // Applying filter.
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Page number validation.
            if (page <= 0)
            {
                page = 1;
            }

            // Items per page validation.
            if (itemsPerPage <= 0)
            {
                itemsPerPage = 10;
            }

            // Sorting the results and extracting those to be shown,
            // considering the chosen page and items per page.
            query = query
                    .OrderBy(i => i.Id)
                    .Skip((page - 1) * itemsPerPage)
                    .Take(itemsPerPage);

            return query.ToList();
        }

        // II. Count (with or without filter)
        public int Count(
            Expression<Func<Entity, bool>> filter = null
            )
        {
            IQueryable<Entity> query = Items;
            
            if (filter != null)
            {
                query = query.Where(filter);
            }
            
            return query.Count();
        }

        // III. A. Helping methods for Save (i.e. Create & Update)

        // Insert (Create)
        private void Insert(Entity item)
        {
            Items.Add(item);
            Context.SaveChanges();
        }

        // Update
        private void Update(Entity item)
        {
            Context.Entry(item).State = EntityState.Modified;
            Context.SaveChanges();
        }

        // III. B. Save (Create & Update)
        public void Save(Entity item)
        {
            // If the item does not exist, is being inserted.
            if (item.Id <= 0)
            {
                Insert(item);
            }

            // If the item already exists, is being updated.
            else
            {
                Update(item);
            }
        }

        // IV. Delete
        public void Delete(Entity item)
        {
            Items.Remove(item);
            Context.SaveChanges();
        }
    }
}