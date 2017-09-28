namespace FabrikamFiber.Web.ViewModels
{
    using System.Linq;

    using FabrikamFiber.DAL.Models;

    public class ScheduleViewModel
    {
        public ServiceTicket ServiceTicket { get; set; }

        public Employee Employee { get; set; }

        public IQueryable<ScheduleItem> ScheduleItems { get; set; }
    }
}