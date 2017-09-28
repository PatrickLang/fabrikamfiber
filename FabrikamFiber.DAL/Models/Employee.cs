namespace FabrikamFiber.DAL.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public class Employee
    {
        public int ID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public Address Address { get; set; }

        public IEnumerable<Phone> Phone { get; set; }

        public string Identity { get; set; }
        
        [DisplayName("Service Areas")]
        public string ServiceAreas { get; set; }
        
        [DisplayName("Full Name")]
        public string FullName
        {
            get { return string.Format("{0} {1}", this.FirstName, this.LastName); }
        }
    }
}
