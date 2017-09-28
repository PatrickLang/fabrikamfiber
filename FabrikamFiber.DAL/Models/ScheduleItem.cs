namespace FabrikamFiber.DAL.Models
{
    using System;

    public class ScheduleItem
    {
        public int ID { get; set; }

        public int EmployeeID { get; set; }

        public Employee Employee { get; set; }

        public int ServiceTicketID { get; set; }

        public ServiceTicket ServiceTicket { get; set; }

        public DateTime Start { get; set; }

        public int WorkHours { get; set; }

        public DateTime? AssignedOn { get; set; }
    }
}