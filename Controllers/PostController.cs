using HairStyleBookingApp.Data;
using HairStyleBookingApp.Models;
using HairStyleBookingApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairStyleBookingApp.Controllers
{
    
    public class PostController : Controller
    {
        private PostRepository postRepository;
        private EmployeeRepository employeeRepository;

        public PostController(ApplicationDbContext dbContext)
        {
            employeeRepository = new EmployeeRepository(dbContext);
            postRepository = new PostRepository(dbContext);
        }
        // GET: PostController
        public ActionResult Index()
        {
            var list = postRepository.GetAllPosts();
            return View(list);
        }

        // GET: PostController/Details/5
        public ActionResult Details(Guid id)
        {
            var model=postRepository.GetPostById(id);
            return View("Details",model);
        }

        // GET: PostController/Create
        [Authorize(Roles = "Employee,Admin")]
        public ActionResult Create()
        {
            var employees = employeeRepository.GetAllEmployees();
            var employeeList = employees.Select(x => new SelectListItem(x.Name, x.IdEmployee.ToString()));
            ViewBag.EmployeeList = employeeList;
            return View("Create");
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee,Admin")]
        public ActionResult Create(IFormCollection collection)
        {
            
                try
                {
                    var model = new PostModel();
                    var task = TryUpdateModelAsync(model);
                    task.Wait();
                    if (task.Result)
                    {
                        postRepository.InsertPost(model);

                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Create");
                }
           
        }

        // GET: PostController/Edit/5
        [Authorize(Roles = "Employee,Admin")]
        public ActionResult Edit(Guid id)
        {
           var model= postRepository.GetPostById(id);
            return View("Edit", model);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee,Admin")]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model=new PostModel();
                var task= TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    postRepository.UpdatePost(model);
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

        // GET: PostController/Delete/5
        [Authorize(Roles ="Admin")]
        public ActionResult Delete(Guid id)
        {
            var model = postRepository.GetPostById(id);
            return View("Delete",model);
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                postRepository.DeletePost(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete", id);
            }
        }
    }
}
