namespace FabrikamFiber.DAL.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public class Customer
    {
        public int ID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public Address Address { get; set; }

        public IEnumerable<Phone> Phone { get; set; }

        [DisplayName("Requested Tickets")]
        public IEnumerable<ServiceTicket> RequestedTickets { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", this.FirstName, this.LastName); }
        }
    }
}