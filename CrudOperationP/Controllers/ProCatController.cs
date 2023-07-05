using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CrudOperationP.Models;
using PagedList;

namespace CrudOperationP.Controllers
{
    public class ProCatController : Controller
    {
        // GET: ProCat
        public ActionResult Index(int? page)
        {
            using (CategEntities db=new CategEntities())
            {
                int pagesize = 10,  pageindex = 1;

                pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
                var list = db.Categories.OrderBy(x => x.ProductId).ToList();
                IPagedList<Category> sd = list.ToPagedList(pageindex, pagesize);
               //List<Category> categories = (from data in db.Categories select data).ToList();
                return View(sd);
            }
        }

        // GET: ProCat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProCat/Create
        public ActionResult Create()
        {
            return View(new Category());
        }

        // POST: ProCat/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                // TODO: Add insert logic here
                using (CategEntities db=new CategEntities())
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProCat/Edit/5
        public ActionResult Edit(int id)
        {
            using (CategEntities db=new CategEntities())
            {
                //Category category = (from data in db.Categories
                //                     where data.ProductId == id
                //                     select data).Single();
                Category category = db.Categories.Find(id);

                return View(category);
            }
        }

        // POST: ProCat/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                // TODO: Add update logic here
                using (CategEntities db=new CategEntities())
                {
                    Category sd = db.Categories.Find(category.ProductId);
                    sd.ProductName = category.ProductName;
                    sd.CategoryId = category.CategoryId;
                    sd.CategoryName = category.CategoryName;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProCat/Delete/5
        public ActionResult Delete(int id)
        {
            using (CategEntities db=new CategEntities())
            {
                db.Categories.Remove(db.Categories.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // POST: ProCat/Delete/5
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
