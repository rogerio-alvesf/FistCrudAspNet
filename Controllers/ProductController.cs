using FistCrudAspNet.Models;
using FistCrudAspNet.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace FistCrudAspNet.Controllers
{
    public class ProductController : Controller
    {
        private readonly UnitOfWorkApp _uow;
        public ProductController(UnitOfWorkApp uow)
        {
            _uow = uow;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(_uow.ProductRepository.FindAll());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(_uow.ProductRepository.FindById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                _uow.ProductRepository.Add(product);
                _uow.ProductRepository.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_uow.ProductRepository.FindById(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                _uow.ProductRepository.Edit(product);
                _uow.ProductRepository.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_uow.ProductRepository.FindById(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                _uow.ProductRepository.Remove(_uow.ProductRepository.FindById(id));
                _uow.ProductRepository.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
