namespace FabrikamFiber.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using FabrikamFiber.DAL.Data;
    using FabrikamFiber.Web.ViewModels;

    public class ReportsController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IServiceTicketRepository serviceTicketRepository;

        public ReportsController(IEmployeeRepository employeeRepository, IServiceTicketRepository serviceTicketRepository)
        {
            this.employeeRepository = employeeRepository;
            this.serviceTicketRepository = serviceTicketRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employees()
        {
            var employees = this.employeeRepository.All.Select(e => new EmployeeSummary { Employee = e }).ToList();
            foreach (var summary in employees)
            {
                var tickets = this.serviceTicketRepository.AllIncluding(t => t.Customer).Where(t => t.AssignedToID == summary.Employee.ID).ToList();
                summary.AssignedTickets = tickets.Count();

                var firstTicket = tickets.FirstOrDefault();
                summary.CurrentCustomer = firstTicket == null ? null : firstTicket.Customer;
            }

            return View(new EmployeeReportViewModel { Employees = employees });
        }
        
        public ActionResult Tickets()
        {
            var report = this.serviceTicketRepository.AllForReport(
                serviceticket => serviceticket.Customer,
                serviceticket => serviceticket.CreatedBy,
                serviceticket => serviceticket.AssignedTo);

            return View();
        }
    }
}
