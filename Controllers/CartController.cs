using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tema2_2.Models;

namespace Tema2_2.Controllers
{
    public class CartController : Controller
    {
        Cart c = new Cart();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public void Add(Product product)
        {
            c.AddToCart(product);
            //Console.Write(c.CartProducts()+"\n");
            //return View(product);

        }

        public String ShowCart()
        {
            String s = c.CartProducts();
            //String s = "CART BLA BLA BLA!!!!";
            //ViewBag.Message = s;
            //for(int i=0; i<)
            //return View();
            return s;
        }
    }
}