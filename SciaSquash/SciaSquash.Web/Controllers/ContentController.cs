using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using MVCHelp.Concrete;

namespace SciaSquash.Web.Controllers
{
    public class ContentController : ContentControllerBase
    {
        public ContentController()
        {
            DeveloperLogo = "LebsoftLogo_64.png";
        }

        //public string GetSciaSquashLogo()
        //{
        //    return View();
        //}

        //public ActionResult Image(string id)
        //{
        //    var dir = Server.MapPath("/Images");
        //    var path = Path.Combine(dir, id + ".jpg");
        //    return base.File(path, "image/jpeg");
        //}
    }
}