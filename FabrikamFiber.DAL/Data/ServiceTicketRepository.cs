namespace FabrikamFiber.DAL.Data
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using FabrikamFiber.DAL.Models;

    public interface IServiceTicketRepository
    {
        IQueryable<ServiceTicket> All { get; }

        IQueryable<ServiceTicket> AllIncluding(params Expression<Func<ServiceTicket, object>>[] includeProperties);

        ServiceTicket Find(int id);

        ServiceTicket FindIncluding(int id, params Expression<Func<ServiceTicket, object>>[] includeProperties);

        void InsertOrUpdate(ServiceTicket serviceticket);

        void Delete(int id);

        void Save();

        IQueryable<ServiceTicket> AllForReport(params Expression<Func<ServiceTicket, object>>[] includeProperties);
    }

    public class ServiceTicketRepository : IServiceTicketRepository
    {
        private readonly FabrikamFiberWebContext context = new FabrikamFiberWebContext();

        public IQueryable<ServiceTicket> All
        {
            get { return this.context.ServiceTickets; }
        }

        public IQueryable<ServiceTicket> AllIncluding(params Expression<Func<ServiceTicket, object>>[] includeProperties)
        {
            IQueryable<ServiceTicket> query = this.context.ServiceTickets;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public ServiceTicket Find(int id)
        {
            return this.context.ServiceTickets.Find(id);
        }

        public ServiceTicket FindIncluding(int id, params Expression<Func<ServiceTicket, object>>[] includeProperties)
        {
            IQueryable<ServiceTicket> query = this.context.ServiceTickets;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(t => t.ID == id).FirstOrDefault();
        }

        public void InsertOrUpdate(ServiceTicket serviceticket)
        {
            if (serviceticket.ID == default(int))
            {
                this.context.ServiceTickets.Add(serviceticket);
            }
            else
            {
                this.context.Entry(serviceticket).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var serviceticket = this.context.ServiceTickets.Find(id);
            this.context.ServiceTickets.Remove(serviceticket);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public IQueryable<ServiceTicket> AllForReport(params Expression<Func<ServiceTicket, object>>[] includeProperties)
        {
            var warehouseContext = new FabrikamFiberWebContext("FabrikamFiber-DataWarehouse");
            IQueryable<ServiceTicket> query = warehouseContext.ServiceTickets;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }
    }
}