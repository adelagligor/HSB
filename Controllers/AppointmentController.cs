using HairStyleBookingApp.Data;
using HairStyleBookingApp.Models;
using HairStyleBookingApp.Repository;
using HairStyleBookingApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Data;

namespace HairStyleBookingApp.Controllers
{
    public class AppointmentController : Controller
    {
        private AppointmentRepository appointmentRepository;
        
        private ServiceRepository serviceRepository;
        private ClientRepository clientRepository;
        private EmployeeRepository employeeRepository;

        public AppointmentController(ApplicationDbContext dbContext)
        {
            appointmentRepository = new AppointmentRepository(dbContext);
            employeeRepository = new EmployeeRepository(dbContext);
            serviceRepository = new ServiceRepository(dbContext);
            clientRepository = new ClientRepository(dbContext);
        }
        // GET: AppointmentController
        [Authorize(Roles = "Employee,Admin,User")]
        public ActionResult Index()
        {
            var list = appointmentRepository.GetAllAppointments();
            var viewModelList = new List<AppointmentViewModel>();
            foreach(var appointment in list)
            {
                viewModelList.Add(new AppointmentViewModel(appointment, clientRepository,
                    serviceRepository, employeeRepository));
            }
            return View(viewModelList);
        }

        // GET: AppointmentController/Details/5
        public ActionResult Details(Guid id)
        {

            var model = appointmentRepository.GetAppointmentById(id);
            var viewModelDetails = new AppointmentViewModel(model, clientRepository, serviceRepository, employeeRepository);

            return View("Details", viewModelDetails);
        }

        // GET: AppointmentController/Create
        [Authorize(Roles = "Employee,Admin,User")]
        public ActionResult Create()
        {
            //var clients = clientRepository.GetAllClients();
            //var clientList = clients.Select(x => new SelectListItem(x.Name, x.IdClient.ToString()));
            //ViewBag.ClientList = clientList;

            //var services = serviceRepository.GetAllServices();
            //var serviceList = services.Select(x => new SelectListItem(x.ServiceName, x.IdService.ToString()));
            //ViewBag.ServiceList = serviceList;

            //var employees = employeeRepository.GetAllEmployees();
            //var employeeList = employees.Select(x => new SelectListItem(x.Name, x.IdEmployee.ToString()));
            //ViewBag.EmployeeList = employeeList;

            //return View("Create");
            var viewmodel = new AppointmentViewModel(new AppointmentModel(),clientRepository, serviceRepository, employeeRepository);
            return View("Create", viewmodel);
        }

        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee,Admin,User")]
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
        [Authorize(Roles = "Employee,Admin")]
        public ActionResult Edit(Guid id)
        {
            var model = appointmentRepository.GetAppointmentById(id);
            var viewModelEdit = new AppointmentViewModel(model, clientRepository, serviceRepository, employeeRepository);

            return View("Edit", viewModelEdit);


        }

        // POST: AppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee,Admin")]
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
        [Authorize(Roles = "Employee,Admin,User")]
        public ActionResult Delete(Guid id)
        {
            var model = appointmentRepository.GetAppointmentById(id);
            var viewModelDelete = new AppointmentViewModel(model, clientRepository, serviceRepository, employeeRepository);

            return View("Delete", viewModelDelete);
        }

        // POST: AppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee,Admin,User")]
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
