using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Contact_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Contact_Manager.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context { get; set; }

        public HomeController(ContactContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var managers = context.Managers
                .Include(m => m.Category)
                .OrderBy(m => m.FirstName)
                .ToList();
            return View(managers);
        }
    }
}
