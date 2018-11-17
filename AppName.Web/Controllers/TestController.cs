using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AppName.Web.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Log()
        {
            var path = "~/App_Data/logs/2018-10-27.log";

            var realPath = Server.MapPath(path);

            if (System.IO.File.Exists(realPath) == false)
            {
                return HttpNotFound();
            }

            return File(realPath, "text/plain");
        }

        public ActionResult Context()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Request.QueryString}");
            sb.AppendLine($"{Request.RequestType}");
            sb.AppendLine($"{Request.UserAgent}");
            sb.AppendLine($"{Request.UserHostAddress}");

            return Content(sb.ToString());
        }

        private const string _cookieName = "MyCookie";

        public ActionResult SaveCookie()
        {
            string value = "Wartość pliku cookie";

            HttpCookie cookie = new HttpCookie(_cookieName);

            cookie.Value = value;

            Response.Cookies.Add(cookie);

            return RedirectToAction("ReadCookie");
        }

        public ActionResult ReadCookie()
        {
            var cookie = Request.Cookies[_cookieName];

            var value = cookie != null ? cookie.Value : "Nie ma cookie";

            return this.Content(value);
        }

        public ActionResult DeleteCookie()
        {
            var cookie = Request.Cookies[_cookieName];

            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            return RedirectToAction("ReadCookie");
        }

        private const string _sessionKey = "key";
        public ActionResult SaveToSession()
        {
            Session[_sessionKey] = DateTime.Now;

            return RedirectToAction("ReadFromSession");
        }

        public ActionResult ReadFromSession()
        {
            var value = Session[_sessionKey];

            var date = value as DateTime?;

            if (date.HasValue)
            {
                return Content(date.ToString());
            }

            return Content("");
        }
    }
}