namespace FabrikamFiber.DAL.Data
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using FabrikamFiber.DAL.Models;

    public interface IEmployeeRepository
    {
        IQueryable<Employee> All { get; }

        IQueryable<Employee> AllIncluding(params Expression<Func<Employee, object>>[] includeProperties);

        Employee Find(int id);

        void InsertOrUpdate(Employee employee);

        void Delete(int id);

        void Save();

        Employee ReportFind(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly FabrikamFiberWebContext context = new FabrikamFiberWebContext();

        public IQueryable<Employee> All
        {
            get { return this.context.Employees; }
        }

        public IQueryable<Employee> AllIncluding(params Expression<Func<Employee, object>>[] includeProperties)
        {
            IQueryable<Employee> query = this.context.Employees;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public Employee Find(int id)
        {
            return this.context.Employees.Find(id);
        }

        public void InsertOrUpdate(Employee employee)
        {
            if (employee.ID == default(int))
            {
                this.context.Employees.Add(employee);
            }
            else
            {
                this.context.Entry(employee).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var employee = this.context.Employees.Find(id);
            this.context.Employees.Remove(employee);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public Employee ReportFind(int id)
        {
            // if (id == 2) return null;
            return this.context.Employees.Find(id);
        }
    }
}