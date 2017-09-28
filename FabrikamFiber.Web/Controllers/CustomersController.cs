namespace FabrikamFiber.Web.Controllers
{
    using System.Web.Mvc;

    using DAL.Data;
    using DAL.Models;

    public class CustomersController : Controller
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public ViewResult Index()
        {
            return View(this.customerRepository.All);
        }

        public ViewResult Details(int id)
        {
            return View(this.customerRepository.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            //check model state
            if (ModelState.IsValid)
            {
                this.customerRepository.InsertOrUpdate(customer);
                this.customerRepository.Save();
                return RedirectToAction("Index");
            }
            
            return this.View();
        }

        public ActionResult Edit(int id)
        {
            return View(this.customerRepository.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                this.customerRepository.InsertOrUpdate(customer);
                this.customerRepository.Save();
                return RedirectToAction("Index");
            }
            
            return this.View();
        }

        public ActionResult Delete(int id)
        {
            return View(this.customerRepository.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.customerRepository.Delete(id);
            this.customerRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

