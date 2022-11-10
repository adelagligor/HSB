using HairStyleBookingApp.Data;
using HairStyleBookingApp.Models;
using HairStyleBookingApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairStyleBookingApp.Controllers
{
    public class AppointmentController : Controller
    {
        private AppointmentRepository appointmentRepository;
        private EmployeeRepository employeeRepository;
        private ServiceRepository serviceRepository;

        public AppointmentController(ApplicationDbContext dbContext)
        {
            appointmentRepository = new AppointmentRepository(dbContext);   
        }
        // GET: AppointmentController
        public ActionResult Index()
        {
            var list = appointmentRepository.GetAllAppointments();
            return View(list);
        }

        // GET: AppointmentController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = appointmentRepository.GetAppointmentById(id);
            return View("Details", model);
        }

        // GET: AppointmentController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new AppointmentModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    appointmentRepository.InsertAppointment(model);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        // GET: AppointmentController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = appointmentRepository.GetAppointmentById(id);
            return View("Edit", model);
        }

        // POST: AppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {

            try
            {
                var model = new AppointmentModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    appointmentRepository.UpdateAppointment(model);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Index", id);
                }
            }
            catch
            {
                return RedirectToAction("Index", id);
            }
        }

        // GET: AppointmentController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = appointmentRepository.GetAppointmentById(id);
            return View("Delete", model);
        }

        // POST: AppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                appointmentRepository.DeleteAppointment(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete", id);
            }
        }
    }
}
