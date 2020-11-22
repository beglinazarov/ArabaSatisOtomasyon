using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArabaSatisOtomasyon.Data;
using ArabaSatisOtomasyon.Entities;
using Microsoft.Owin.Security;

namespace ArabaSatisOtomasyon.Controllers
{
    public class ArabasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Arabas
        public ActionResult Index()
        {
            return View(db.Araba.ToList());
        }

        // GET: Arabas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araba araba = db.Araba.Find(id);
            if (araba == null)
            {
                return HttpNotFound();
            }
            return View(araba);
        }

        public ActionResult Tanim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Tanim(VitesTurleri vitesturu)
        {
            db.VitesTurleris.Add(vitesturu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YakitTanim ()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult YakitTanim(YakitTurleri yakitturu)
        //{
        //    db.YakitTurleris.Add(yakitturu);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        // GET: Arabas/Create
        public ActionResult Create()
        {
            ViewBag.VitesTurleri = db.VitesTurleris.ToList();
            return View();
        }

        // POST: Arabas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Marka,Seri,Yakit,Vites,KM,MotorHacmi,HP,IlanTarihi")] Araba araba)
        {
            if (ModelState.IsValid)
            {
                db.Araba.Add(araba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(araba);
        }

        // GET: Arabas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araba araba = db.Araba.Find(id);
            if (araba == null)
            {
                return HttpNotFound();
            }
            return View(araba);
        }

        // POST: Arabas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Marka,Seri,Yakit,Vites,KM,MotorHacmi,HP,IlanTarihi")] Araba araba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(araba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(araba);
        }

        // GET: Arabas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araba araba = db.Araba.Find(id);
            if (araba == null)
            {
                return HttpNotFound();
            }
            return View(araba);
        }

        // POST: Arabas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Araba araba = db.Araba.Find(id);
            db.Araba.Remove(araba);
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
