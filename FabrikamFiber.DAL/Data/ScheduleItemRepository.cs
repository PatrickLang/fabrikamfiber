namespace FabrikamFiber.DAL.Data
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using FabrikamFiber.DAL.Models;

    public interface IScheduleItemRepository
    {
        IQueryable<ScheduleItem> All { get; }

        IQueryable<ScheduleItem> AllIncluding(params Expression<Func<ScheduleItem, object>>[] includeProperties);

        ScheduleItem Find(int id);

        void InsertOrUpdate(ScheduleItem scheduleitem);

        void Delete(int id);

        void Save();
    }

    public class ScheduleItemRepository : IScheduleItemRepository
    {
        private readonly FabrikamFiberWebContext context = new FabrikamFiberWebContext();

        public IQueryable<ScheduleItem> All
        {
            get { return this.context.ScheduleItems; }
        }

        public IQueryable<ScheduleItem> AllIncluding(params Expression<Func<ScheduleItem, object>>[] includeProperties)
        {
            IQueryable<ScheduleItem> query = this.context.ScheduleItems;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public ScheduleItem Find(int id)
        {
            return this.context.ScheduleItems.Find(id);
        }

        public void InsertOrUpdate(ScheduleItem scheduleitem)
        {
            if (scheduleitem.ID == default(int))
            {
                // New entity
                this.context.ScheduleItems.Add(scheduleitem);
            }
            else
            {
                // Existing entity
                this.context.Entry(scheduleitem).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var scheduleitem = this.context.ScheduleItems.Find(id);
            this.context.ScheduleItems.Remove(scheduleitem);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}