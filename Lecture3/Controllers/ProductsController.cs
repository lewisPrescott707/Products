using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lecture3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lecture3.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _repoProduct;

        public ProductsController(IProductsRepository repoProduct)
        {
            _repoProduct = repoProduct;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repoProduct.GetAllAsyn());
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var product = await _repoProduct.GetAsync(id);
            if (product == null)
            {
                return View("NotFound");
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,price,Id,AddedDate,ModifiedDate,IPAddress")] Product product)
        {
            if (ModelState.IsValid)
            {
                _repoProduct.Add(product);
                await _repoProduct.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repoProduct.GetAsync(id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _repoProduct.GetAsync(id);
            await _repoProduct.DeleteAsyn(product);
            await _repoProduct.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}