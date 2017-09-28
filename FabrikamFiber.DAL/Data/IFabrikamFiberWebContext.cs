namespace FabrikamFiber.Web.Data
{
    using System;
    using System.Data.Entity;
    using FabrikamFiber.Web.Models;

    public interface IFabrikamFiberWebContext
    {
        IDbSet<Alert> Alerts { get; set; }

        IDbSet<Customer> Customers { get; set; }

        IDbSet<Employee> Employees { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<ScheduleItem> ScheduleItems { get; set; }

        IDbSet<ServiceLogEntry> ServiceLogEntries { get; set; }

        IDbSet<ServiceTicket> ServiceTickets { get; set; }
    }
}
