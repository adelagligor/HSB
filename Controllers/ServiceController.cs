using HairStyleBookingApp.Data;
using HairStyleBookingApp.Models;
using HairStyleBookingApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairStyleBookingApp.Controllers
{
    public class ServiceController : Controller
    {
        private ServiceRepository serviceRepository;

        public ServiceController(ApplicationDbContext dbContext)
        {
            serviceRepository = new ServiceRepository(dbContext);
        }
        // GET: ServiceController
        public ActionResult Index()
        {
            var list = serviceRepository.GetAllServices();
            return View(list);
        }

        // GET: ServiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new ServiceModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    serviceRepository.InsertService(model);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        // GET: ServiceController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = serviceRepository.GetServiceById(id);
            return View("Edit", model);
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new ServiceModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    serviceRepository.UpdateService(model);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Index", id);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = serviceRepository.GetServiceById(id);
            return View("Delete", model);
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                serviceRepository.DeleteService(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete", id);
            }
        }
    }
}
