using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tema2_2.Models;

namespace Tema2_2.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //private CartController cc = new CartController();
        Cart c;
        // GET: Products
        public ActionResult Index()
        {
            
            return View(db.Products.ToList());
        }

        public void ExportJson()
        {
            String prevPage = Request.UrlReferrer.ToString();
            Exporter e = Factory.GetFormat("json");
            List<Product> list = db.Products.ToList();
            e.Export(list);
            Response.Redirect(prevPage);
        }

        public void ExportCsv()
        {
            String prevPage = Request.UrlReferrer.ToString();
            Exporter e = Factory.GetFormat("csv");
            List<Product> list = db.Products.ToList();
            e.Export(list);
            Response.Redirect(prevPage);
        }
        

        //public ActionRezult Buy()
        public ActionResult Buy()
        {
            if (Session["cart"] == null)
            {
                c = new Cart();
                Session["cart"] = c;
            }
            //ViewBag.Message = cc.ShowCart();
            //String s = c.CartProducts();
            var cart = Session["cart"] as Cart;
            ViewBag.Message = cart.CartProducts();
            return View(); 
            //return cc.ShowCart();
        }

        public void AddToCart(int? id)
        {
            String prevPage = Request.UrlReferrer.ToString();
            if (Session["cart"] == null)
            {
                c = new Cart();
                Session["cart"] = c;
            }
            if (id == null)
            {
                throw new NullReferenceException();
            }
            var product = db.Products.Find(id);
           // Console.Write("Adaugare!\n");
            if (product != null && product.Quantity>0)
            {
                var cart = Session["cart"] as Cart;
                cart.AddToCart(product);
                Session["cart"] = cart;
                
            }
            //return this.Index();
            //Index();
            Response.Redirect(prevPage);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "ID,Name,Quantity,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "ID,Name,Quantity,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
