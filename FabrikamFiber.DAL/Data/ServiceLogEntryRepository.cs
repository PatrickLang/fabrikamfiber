namespace FabrikamFiber.DAL.Data
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using FabrikamFiber.DAL.Models;

    public interface IServiceLogEntryRepository
    {
        IQueryable<ServiceLogEntry> All { get; }

        IQueryable<ServiceLogEntry> AllIncluding(params Expression<Func<ServiceLogEntry, object>>[] includeProperties);

        ServiceLogEntry Find(int id);

        void InsertOrUpdate(ServiceLogEntry servicelogentry);

        void Delete(int id);

        void Save();
    }

    public class ServiceLogEntryRepository : IServiceLogEntryRepository
    {
        private readonly FabrikamFiberWebContext context = new FabrikamFiberWebContext();

        public IQueryable<ServiceLogEntry> All
        {
            get { return this.context.ServiceLogEntries; }
        }

        public IQueryable<ServiceLogEntry> AllIncluding(params Expression<Func<ServiceLogEntry, object>>[] includeProperties)
        {
            IQueryable<ServiceLogEntry> query = this.context.ServiceLogEntries;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public ServiceLogEntry Find(int id)
        {
            return this.context.ServiceLogEntries.Find(id);
        }

        public void InsertOrUpdate(ServiceLogEntry servicelogentry)
        {
            if (servicelogentry.ID == default(int))
            {
                this.context.ServiceLogEntries.Add(servicelogentry);
            }
            else
            {
                this.context.Entry(servicelogentry).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var servicelogentry = this.context.ServiceLogEntries.Find(id);
            this.context.ServiceLogEntries.Remove(servicelogentry);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}