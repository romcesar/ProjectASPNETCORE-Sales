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
            var viewModel = new SellersFormViewModel { Departaments = departaments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sellers sellers)
        {
            _sellersService.Insert(sellers);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var obj = _sellersService
                .
                
                FindById(id.Value);

            if (obj == null)
            {
                return View("Error");
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellersService.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return View("Error");
            }

            var obj = _sellersService.FindById(id.Value);

            if (obj == null)
            {
                return View("Error");
            }

            return View(obj);
        } 

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }
            var obj = _sellersService.FindById(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            List<Departaments> departaments = _departamentsService.FindAll();

            var viewModel = new SellersFormViewModel { Departaments = departaments, Sellers = obj };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, Sellers sellers)
        {
            if(id != sellers.id)
            {
                return BadRequest();
            }

            try
            {
                _sellersService.Update(sellers);

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
