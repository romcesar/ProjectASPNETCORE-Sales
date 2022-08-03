using Microsoft.AspNetCore.Mvc;
using SalesWeb.ASPNETCORE.Models.Entities;
using SalesWeb.ASPNETCORE.Service;

namespace SalesWeb.ASPNETCORE.Controllers
{
	public class SellersController : Controller
	{
		private readonly SellersService _sellersService;

		public SellersController(SellersService sellers)
		{
			_sellersService = sellers;
		}
		public IActionResult Index()
		{
			var list = _sellersService.FindAll();

			return View(list);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Sellers sellers)
		{
			_sellersService.Insert(sellers);
			return RedirectToAction(nameof(Index));
		}
	}
}
