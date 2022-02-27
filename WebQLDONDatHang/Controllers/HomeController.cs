using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebQLDONDatHang.Controllers
{
    public class HomeController : Controller
    {
        private Models.ModelDonDatHang dc = new Models.ModelDonDatHang();
        // GET: Home
        public ActionResult Index()
        {
            return View(dc.hanghoas.ToList());
        }
        [HttpPost]
        public ActionResult ChonMua(string mahang,int soluong)
        {
            Models.hoadon ddh = Session["DonDatHang"] as Models.hoadon;
            Models.chitiethoadon ct = new Models.chitiethoadon();
            ct.mahang = mahang;
            
            ct.soluong = soluong;

            ct.hanghoa = dc.hanghoas.Find(mahang);
            ct.dongia = ct.hanghoa.dongia;
            ddh.chitiethoadons.Add(ct);

            return View("GioHang",ddh);
        }
        public ActionResult GioHang()
        {
            Models.hoadon ddh = Session["DonDatHang"] as Models.hoadon;
            return View("GioHang", ddh);
        }
        public ActionResult XoaHangHoa(string id)
        {
            Models.hoadon ddh = Session["DonDatHang"] as Models.hoadon;
            foreach(var a in ddh.chitiethoadons.Where(x=>x.mahang==id))
            {
                ddh.chitiethoadons.Remove(a);
                break;
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult LapDonDatHang(Models.hoadon x)
        { if(ModelState.IsValid)
            {
                Models.hoadon ddh = Session["DonDatHang"] as Models.hoadon;
                foreach(var item in ddh.chitiethoadons)
                {
                    Models.chitiethoadon ct = new Models.chitiethoadon();
                    ct.mahang = item.mahang;
                    ct.sohd = x.sohd;
                    ct.dongia = item.dongia;
                    ct.soluong = item.soluong;
                    x.chitiethoadons.Add(ct);
                }
                dc.hoadons.Add(x);
                dc.SaveChanges();
                ddh.chitiethoadons.Clear();
            }
          
            
            return RedirectToAction("Index","DonDatHang");
        }
    }
}