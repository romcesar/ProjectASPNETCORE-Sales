using Microsoft.AspNetCore.Mvc;
using SalesWeb.ASPNETCORE.Models.Entities;
using SalesWeb.ASPNETCORE.Models.ViewModel;
using SalesWeb.ASPNETCORE.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SalesWeb.ASPNETCORE.Service.Exceptions;
using SalesWeb.ASPNETCORE.Models;
using System.Diagnostics;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            var list = await _sellersService.FindAllAsync();

            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var departaments = await _departamentsService.FindAllAsync();
            var viewModel = new SellersFormViewModel { Departaments = departaments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sellers sellers)
        {
            if (!ModelState.IsValid)
            {
                var departaments =  await _departamentsService.FindAllAsync();
                var viewModel = new SellersFormViewModel { Departaments = departaments };

                return View(viewModel);
            }
            await _sellersService.InsertAsync(sellers);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var obj = await _sellersService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return View("Error");
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
           await _sellersService.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return View("Error");
            }

            var obj = await _sellersService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return View("Error");
            }

            return View(obj);
        } 

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }
            var obj = await _sellersService.FindByIdAsync(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            List<Departaments> departaments = await _departamentsService.FindAllAsync();

            var viewModel = new SellersFormViewModel { Departaments = departaments, Sellers = obj };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Sellers sellers)
        {
            if(id != sellers.id)
            {
                return BadRequest();
            }

            try
            {
               await _sellersService.UpdateAsync(sellers);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel 
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                
            };

            return View(viewModel);
        }

    }
}
