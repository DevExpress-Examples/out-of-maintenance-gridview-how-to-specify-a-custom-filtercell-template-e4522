using System;
using System.Web.Mvc;

namespace DXWebApplication1.Controllers {
    public class HomeController: Controller {
        public ActionResult Index() {
            return View();
        }
        public ActionResult GridViewPartial() {
            return PartialView(DataProvider.GetDemoModel());
        }
        public ActionResult ComboBoxPartial() {
            return PartialView(DataProvider.GetDemoModel());
        }
    }
}