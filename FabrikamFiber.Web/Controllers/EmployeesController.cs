namespace FabrikamFiber.Web.Controllers
{
    using System.Web.Mvc;

    using FabrikamFiber.DAL.Data;
    using FabrikamFiber.DAL.Models;

    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            //comment
            this.employeeRepository = employeeRepository;
        }

        public ViewResult Index()
        {
            return View(this.employeeRepository.All);
        }

        public ViewResult Details(int id)
        {
            return View(this.employeeRepository.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                this.employeeRepository.InsertOrUpdate(employee);
                this.employeeRepository.Save();
                return RedirectToAction("Index");
            }
            
            return this.View();
        }

        public ActionResult Edit(int id)
        {
            return View(this.employeeRepository.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                this.employeeRepository.InsertOrUpdate(employee);
                this.employeeRepository.Save();
                return RedirectToAction("Index");
            }
            
            return this.View();
        }

        public ActionResult Delete(int id)
        {
            return View(this.employeeRepository.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.employeeRepository.Delete(id);
            this.employeeRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

