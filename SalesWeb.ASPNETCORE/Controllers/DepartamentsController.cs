using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SalesWeb.ASPNETCORE.Models.Entities;

namespace SalesWeb.ASPNETCORE.Controllers
{
    public class DepartamentsController : Controller
    {
        public IActionResult Index()
        {
            List<Departaments> list = new List<Departaments>();
            list.Add(new Departaments { id = 2, name = "Eletronics" });
            list.Add(new Departaments { id = 2, name = "Fashion" });

            return View(list.ToString());
        }
    }
}
