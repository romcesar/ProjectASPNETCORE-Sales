using Microsoft.AspNetCore.Mvc;
using SalesWeb.ASPNETCORE.Models.Entities;
using SalesWeb.ASPNETCORE.Models.ViewModel;
using SalesWeb.ASPNETCORE.Service;

namespace SalesWeb.ASPNETCORE.Controllers
{
	public class SellersController : Controller
	{
		private readonly SellersService _sellersService;
		private readonly DepartamentsService _departamentsService;

		public SellersController(SellersService sellers, DepartamentsService departamentsService)
		{
			_sellersService = sellers;
			_departamentsService = departamentsService;
		}
		public IActionResult Index()
		{
			var list = _sellersService.FindAll();

			return View(list);
		}
		[HttpGet]
		public IActionResult Create()
		{
			var departaments = _departamentsService.FindAll();
			var viewModel = new SellerFormViewModel { Departaments = departaments };

			return View(viewModel);
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
