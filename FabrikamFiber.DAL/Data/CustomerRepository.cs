namespace FabrikamFiber.DAL.Data
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using FabrikamFiber.DAL.Models;

    public interface ICustomerRepository
    {
        IQueryable<Customer> All { get; }

        IQueryable<Customer> AllIncluding(params Expression<Func<Customer, object>>[] includeProperties);

        Customer Find(int id);

        void InsertOrUpdate(Customer customer);

        void Delete(int id);

        void Save();
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly FabrikamFiberWebContext context = new FabrikamFiberWebContext();

        public IQueryable<Customer> All
        {
            get { return this.context.Customers; }
        }

        public IQueryable<Customer> AllIncluding(params Expression<Func<Customer, object>>[] includeProperties)
        {
            IQueryable<Customer> query = this.context.Customers;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public Customer Find(int id)
        {
            return this.context.Customers.Find(id);
        }

        public void InsertOrUpdate(Customer customer)
        {
            if (customer.ID == default(int))
            {
                this.context.Customers.Add(customer);
            }
            else
            {
                this.context.Entry(customer).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var customer = this.context.Customers.Find(id);
            this.context.Customers.Remove(customer);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}