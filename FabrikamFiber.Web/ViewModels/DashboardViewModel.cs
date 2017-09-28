namespace FabrikamFiber.Web.ViewModels
{
    using System.Collections.Generic;

    using FabrikamFiber.DAL.Models;

    public class DashboardViewModel
    {
        public IEnumerable<ServiceTicket> Tickets { get; set; }

        public IEnumerable<Message> Messages { get; set; }

        public IEnumerable<Alert> Alerts { get; set; }

        public IEnumerable<ScheduleItem> ScheduleItems { get; set; }
    }
}