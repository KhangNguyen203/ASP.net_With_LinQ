using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    public class ProductController : Controller
    {
        NorWidDataContext da = new NorWidDataContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product
        public ActionResult ListProducts()
        {
            List<Product> ds = da.Products.Select(s => s).ToList();
            return View(ds);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            //Lấy thông tin sản phẩm theo id truyền vào
            Product p = da.Products.Where(s => s.ProductID == id).FirstOrDefault();
            return View(p);
        }

        //hiển thị giao diện thêm sp 
        // GET: Product/Create
        public ActionResult Create()
        {
            ViewData["NCC"] = new SelectList(da.Suppliers, "SupplierID", "CompanyName");
            ViewData["LoaiSP"] = new SelectList(da.Categories, "CategoryID", "CategoryName");
            return View();
        }

        //lấy sản phẩm mới từ giao diện thêm vào db 
        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product, FormCollection collection)
        {
            try
            {
                //Tạo mới 1 đối tượng sản phẩm
                Product p = new Product();
                //Gán sản phẩm ngta chuyền vào sp vauwf tạo
                p = product;

                p.CategoryID = int.Parse(collection["LoaiSP"]);
                p.SupplierID = int.Parse(collection["NCC"]);

                //Thêm sp vào bảng product
                da.Products.InsertOnSubmit(p);
                //Lưu xuống db
                da.SubmitChanges();
                //Gọi lại trang listProducts
                return RedirectToAction("ListProducts");
            }
            catch
            {
                return View();
            }
        }

        //Hiển thị view Sửa
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = da.Products.FirstOrDefault(s => s.ProductID == id);

            ViewData["NCC"] = new SelectList(da.Suppliers, "SupplierID", "CompanyName");
            ViewData["LoaiSP"] = new SelectList(da.Categories, "CategoryID", "CategoryName");
            return View(p);
        }

        //Thực hiện sửa
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product, FormCollection collection)
        {
            try
            {
                //Xác định sản phẩm cần sửa
                Product p = da.Products.First(s => s.ProductID == id);

                p.CategoryID = int.Parse(collection["LoaiSP"]);
                p.SupplierID = int.Parse(collection["NCC"]);

                //Thực hiện sửa
                p.ProductName = product.ProductName;
                p.UnitPrice = product.UnitPrice;
                p.UnitsInStock = product.UnitsInStock;
                p.CategoryID = product.CategoryID;
                p.SupplierID = product.SupplierID;
                //Lưu xuống db
                da.SubmitChanges();
                //Gọi lại trang listProducts
                return RedirectToAction("ListProducts");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product p = da.Products.First(s => s.ProductID == id);
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Product p = da.Products.First(s => s.ProductID == id);
                da.Products.DeleteOnSubmit(p);
                da.SubmitChanges();
                return RedirectToAction("ListProducts");
            }
            catch
            {
                return View();
            }
        }
    }
}
