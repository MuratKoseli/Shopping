using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri

        MvcDboStokEntities db= new MvcDboStokEntities();
        public ActionResult Index()
        {
            var deger = db.TBL_MUSTERILER.ToList();
            return View(deger);
        }
        
        [HttpGet]
    public ActionResult MusteriEkle()
        {
            
            return View();
        }
        
        [HttpPost]
        public ActionResult MusteriEkle(TBL_MUSTERILER p2)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriEkle");
            }
            db.TBL_MUSTERILER.Add(p2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var musterı= db.TBL_MUSTERILER.Find(id);
            db.TBL_MUSTERILER.Remove(musterı);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusterıGetır(int id)
        {
            var mstr = db.TBL_MUSTERILER.Find(id);
            return View("MusterıGetır", mstr);
        }

        public ActionResult Guncelle(TBL_MUSTERILER p1)
        {
            var msr = db.TBL_MUSTERILER.Find(p1.MUSTERIID);
            msr.MUSTERIAD=p1.MUSTERIAD;
            msr.MUSTERISOYAD=p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}