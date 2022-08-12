
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Context;
using ProductsApp.Models;
using System.Linq;
using System.Net;
using System.Web;
namespace ProductsApp.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext db = new ProductContext();
        // GET: ProductController
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int? Id)
        {
            if (Id == null)
                return StatusCode(400);
            Product product = db.Products.Find(Id);
            if (product == null)
                return StatusCode(400);
            return View(product);
        }

        // GET: ProductController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        

        // GET: ProductController/Edit/5
        public ActionResult Edit(int? Id)
        {
            if(Id == null)
            {
                return StatusCode(400);
            }

            Product product = db.Products.Find(Id);
            if(product == null)
            {
                return StatusCode(404);
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return StatusCode(400);
            }
            Product product = db.Products.Find(Id);
            if (product == null)
            {
                return StatusCode(404);
            }
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? Id, Product prod)
        {
            try
            {
                Product product = new Product();
                if (ModelState.IsValid)
                {
                    if(Id == null)
                    {
                        return StatusCode(400);
                    }

                    product = db.Products.Find(Id);
                    if (product == null)
                    {
                        return StatusCode(404);
                    }

                    db.Products.Remove(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }
    }
}
