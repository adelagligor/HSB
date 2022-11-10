using HairStyleBookingApp.Data;
using HairStyleBookingApp.Models;
using HairStyleBookingApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairStyleBookingApp.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepository employeeRepository;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            employeeRepository = new EmployeeRepository(dbContext);
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var list = employeeRepository.GetAllEmployees();
            return View(list);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = employeeRepository.GetEmployeeById(id);
            return View("Details", model);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new EmployeeModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    employeeRepository.InsertEmployee(model);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = employeeRepository.GetEmployeeById(id);
            return View("Edit", model);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {

                var model = new EmployeeModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    employeeRepository.UpdateEmployee(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit", id);
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = employeeRepository.GetEmployeeById(id);
            return View("Delete", model);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                employeeRepository.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete", id);
            }
        }
    }
}
