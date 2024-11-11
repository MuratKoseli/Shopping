using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;


namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        MvcDboStokEntities db = new MvcDboStokEntities();
        // GET: Urun
        public ActionResult Index()
        {
            var degerler = db.TBL_URUNLER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler= (from i in db.TBL_KATEGORILER.ToList()
                                            select new SelectListItem
                                            {
                                                Text  =   i.KATEGORIAD,
                                                Value =  i.KATEGORIID.ToString()
                                            }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]

        public ActionResult UrunEkle(TBL_URUNLER p3)
        {
            //for (!ModelState.IsValid)
            //{
            //    return View("UrunEkle");
            //}
            var ktg = db.TBL_KATEGORILER.Where(m => m.KATEGORIID == p3.TBL_KATEGORILER.KATEGORIID).FirstOrDefault();
            p3.TBL_KATEGORILER = ktg;
            db.TBL_URUNLER.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var urun= db.TBL_URUNLER.Find(id);
            db.TBL_URUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urn = db.TBL_URUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBL_KATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("UrunGetir",  urn);
        }
    }
}