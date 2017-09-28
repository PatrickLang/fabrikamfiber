namespace FabrikamFiber.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class ServiceTicket
    {
        public int ID { get; set; }
        
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public Status Status 
        {
            get { return (Status)this.StatusValue; }
            set { this.StatusValue = (int)value; }
        }

        public int StatusValue { get; set; }

        [DisplayName("Escalation Level")]
        public int EscalationLevel { get; set; }

        public DateTime? Opened { get; set; }

        public DateTime? Closed { get; set; }
        
        public Customer Customer { get; set; }

        public int? CustomerID { get; set; }

        [DisplayName("Created By")]
        public Employee CreatedBy { get; set; }

        public int? CreatedByID { get; set; }

        [DisplayName("Assigned To")]
        public Employee AssignedTo { get; set; }

        public int? AssignedToID { get; set; }

        public ICollection<ServiceLogEntry> Log { get; set; }

        public string TimeOpen
        {
            get
            {
                if (Status == Status.Closed)
                {
                    return "Closed";
                }

                var span = DateTime.Now.Subtract(this.Opened.GetValueOrDefault(DateTime.Now));

                if (span.Days > 0)
                {
                    return string.Format("{0} Days", span.Days);
                }

                if (span.Hours > 0)
                {
                    return string.Format("{0} Hours", span.Hours);
                }

                if (span.Minutes > 0)
                {
                    return string.Format("{0} Minutes", span.Minutes);
                }

                return "New";
            }
        }
    }
}