using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class CartController : Controller
    {
        private List<CartModel> GetListCarts()
        {
            List<CartModel> carts = Session["CartModel"] as List<CartModel>;
            if (carts == null)//chua co sp nao trong gio hang
            {
                carts = new List<CartModel>();
                Session["CartModel"] = carts;
            }
            return carts;
        }
        // GET: lấy DSSp có tromg giỏ hàng
        public ActionResult ListCarts()
        {
            List<CartModel> carts = GetListCarts();


            return View(carts);
        }

        public ActionResult AddCart(int id)
        {
            //lấy DSSP co trong gio hang
            List<CartModel> carts = GetListCarts();


            CartModel c = carts.Find(s => s.ProductID == id);
            if (c == null)
            {
                c = new CartModel(id);
                carts.Add(c);
            }
            else
            {
                c.Quantity++;
            }

            return RedirectToAction("ListCarts");
        }



        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
