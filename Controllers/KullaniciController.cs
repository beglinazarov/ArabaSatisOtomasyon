﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArabaSatisOtomasyon.Data;
using ArabaSatisOtomasyon.Models;

namespace ArabaSatisOtomasyon.Controllers
{
    public class KullaniciController : Controller
    {
        private ApplicationDbContext db;
        private ApplicationUserManager _userManager;
        public KullaniciController()
        {

        }
        //public KullaniciController(
        //    ApplicationDbContext dbContext,
        //    ApplicationUserManager userManager)
        //{
        //    db = dbContext;
        //    _userManager = userManager;
        //}

        // GET: Kullanici
        public ActionResult Index()
        {
            var kullanicilar = new List<ApplicationUser>();

            kullanicilar.Add(new ApplicationUser {  Adi = "Emre", Soyadi ="blabalbal"} );
            kullanicilar.Add(new ApplicationUser { Adi = "veli", Soyadi = "zibbma" });

            return View(kullanicilar);
        }

        // GET: Kullanici/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = new ApplicationUser();//await _userManager.FindByIdAsync(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: Kullanici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kullanici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,PhoneNumber,Yas,Adi,Soyadi,KullaniciKayitTarihi,Adres,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                //db.ApplicationUsers.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: Kullanici/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = new ApplicationUser();// db.ApplicationUsers.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Kullanici/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,PhoneNumber,Yas,Adi,Soyadi,KullaniciKayitTarihi,Adres,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: Kullanici/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            //if (applicationUser == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Kullanici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            //ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            //db.ApplicationUsers.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}