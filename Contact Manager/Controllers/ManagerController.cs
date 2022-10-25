using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Contact_Manager.Models;
using System;
using Microsoft.EntityFrameworkCore;



namespace Contact_Manager.Controllers
{
    public class ManagerController : Controller
    {
        private ContactContext context { get; set; }

        public ManagerController(ContactContext ctx)
        {
            context = ctx;
        }

        public IActionResult Details(int id)
        {
            var manager = context.Managers.Include(m => m.Category).FirstOrDefault(manager => manager.ManagerId == id);
            return View(manager);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
            return View("Edit", new Manager());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
            var managers = context.Managers.Include(m => m.Category).FirstOrDefault(managers => managers.ManagerId == id);
            return View(managers);
        }

        [HttpPost]
        public IActionResult Edit(Manager manager)
        {
            string action = (manager.ManagerId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    context.Managers.Add(manager);
                }
                else
                {
                    context.Managers.Update(manager);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
                return View(manager);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var manager = context.Managers.Include(m => m.Category).FirstOrDefault(m => m.ManagerId == id);
            return View(manager);
        }

        [HttpPost]
        public IActionResult Delete(Manager manager)
        {
            context.Managers.Remove(manager);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
