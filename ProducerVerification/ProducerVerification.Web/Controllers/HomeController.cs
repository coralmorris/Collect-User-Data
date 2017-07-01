using ProducerVerification.Web.DAL;
using ProducerVerification.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProducerVerification.Web.Controllers
{
    public class HomeController : Controller
    {
        private ProducerVerificationDbContext db = new ProducerVerificationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home(ProducerUserInfo model)
        {
            if (model.ProducerCode == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            model.ProducerCode = model.ProducerCode.Trim();
            model.AuthorizationCode = model.AuthorizationCode.Trim();

            ProducerInfo producerInfo = db.Producers
                .Where(p => p.ProducerCode == model.ProducerCode)
                .FirstOrDefault();

            if (producerInfo == null)
            {
                return HttpNotFound();
            }

            bool isAuthorized = AuthenticationCodes.VerifyAuthCode(db, model.ProducerCode, model.AuthorizationCode);

            if (!isAuthorized)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return RedirectToAction("Upload", model);
        }

        public ActionResult Upload(ProducerUserInfo model)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase fileUpload, ProducerUserInfo model)
        {
            if( fileUpload != null && fileUpload.ContentLength > 0)
            {
                var name = model.ProducerCode + Path.GetFileName(fileUpload.FileName);
                //var path = Path.Combine(Server.MapPath("~App_Data/uploads"), name);
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "/App_Data/uploads/", name);

                var ext = Path.GetExtension(name);

                if (ext != ".xlsm")
                {
                    TempData["error"] = "Please select a valid file.";
                    return View();
                }

                fileUpload.SaveAs(path);
                TempData["error"] = "Thank you for your time.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Please select a valid file.";
            }
            return View();
        }

        public FilePathResult Download()
        {
            var name = ConfigurationManager.AppSettings["ExcelDownload"];
            //var path = Path.Combine(Server.MapPath("~App_Data/downloads"), name);
            //var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), name);

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "/App_Data/downloads/", name);
            return File(path, "application/octet-stream", name);
        }

    }
}