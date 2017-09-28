namespace FabrikamFiber.Web.ViewModels
{
    using FabrikamFiber.DAL.Models;

    public class EmployeeSummary
    {
        public Employee Employee { get; set; }

        public Customer CurrentCustomer { get; set; }

        public int AssignedTickets { get; set; }
    }
}