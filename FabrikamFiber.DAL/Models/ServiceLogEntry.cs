namespace FabrikamFiber.DAL.Models
{
    using System;

    public class ServiceLogEntry
    {
        public int ID { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Description { get; set; }

        public Employee CreatedBy { get; set; }

        public int? CreatedByID { get; set; }

        public ServiceTicket ServiceTicket { get; set; }

        public int ServiceTicketID { get; set; }
    }
}
