using HairStyleBookingApp.Data;
using HairStyleBookingApp.Models;
using HairStyleBookingApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairStyleBookingApp.Controllers
{
    public class ClientController : Controller
    {
        private ClientRepository clientRepository;

        public ClientController(ApplicationDbContext dbContext)
        {
            clientRepository = new ClientRepository(dbContext);
        }
        // GET: ClientController
        public ActionResult Index()
        {
            var list = clientRepository.GetAllClients();
            return View(list);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(Guid id)
        {
            var model= clientRepository.GetClientById(id);
            return View("Details", model);

        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new ClientModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    clientRepository.InsertClient(model);
                    TempData["success"] = "Client created sucessfully";

                }

                
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = clientRepository.GetClientById(id);
            return View("Edit", model);
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new ClientModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    clientRepository.UpdateClient(model);
                    TempData["success"] = "Client updated sucessfully";
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

        // GET: ClientController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = clientRepository.GetClientById(id);
            
            return View("Delete", model);
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                clientRepository.DeleteClient(id);
                TempData["success"] = "Client deleted sucessfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete", id);
            }
        }
    }
}
