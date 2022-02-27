using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebQLDONDatHang.Controllers
{
    public class DonDatHangController : Controller
    {
        // GET: DonDatHang
        private Models.ModelDonDatHang dc = new Models.ModelDonDatHang();
        public ActionResult Index()
        {
            return View(dc.hoadons.ToList());
        }
        public ActionResult XemChiTietDonDatHang(string id)
        {
            Models.hoadon hd = dc.hoadons.Find(id);
            return View(hd);
        }
    }
}