using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProducerVerification.Web.DAL;
using ProducerVerification.Web.Models;
using System.Web.Mail;
using System.Net.Mail;
using System.Configuration;
using System.Web.Services.Description;
using ProducerVerification.Web.Helpers;
using System.Text.RegularExpressions;

namespace ProducerVerification.Web.Controllers
{
    public class ProducerUserInfoController : Controller
    {
        private ProducerVerificationDbContext db = new ProducerVerificationDbContext();

        // GET: ProducerUserInfo
        public ActionResult Index(int? done)
        {
            if(done == 1)
            {
                TempData["error"] = "Thank you for your time.";
            }
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ProducerUserInfo model)
        {
            if (model.ProducerCode == null)
            {
                TempData["error"] = "The Producer Code you entered is not valid.";
                return RedirectToAction("Index", "ProducerUserInfo");
            }

            model.ProducerCode = model.ProducerCode.Trim();
            model.AuthorizationCode = model.AuthorizationCode.Trim();

            ProducerInfo producerInfo = db.Producers
                .Where(p => p.ProducerCode == model.ProducerCode)
                .FirstOrDefault();

            if (producerInfo == null)
            {
                TempData["error"] = "The Producer Code you entered is not valid.";
                return RedirectToAction("Index", "ProducerUserInfo");
            }

            bool isAuthorized = AuthenticationCodes.VerifyAuthCode(db, model.ProducerCode, model.AuthorizationCode);

            if (!isAuthorized)
            {
                TempData["error"] = "The Authorization Code you entered is not valid.";
                return RedirectToAction("Index", "ProducerUserInfo");
            }

            //if you want users to have a unique email address 
            //int uniqueEmail = db.ProducerUserInfoes.Count(e => e.UserCode == model.UserCode);

            //if (uniqueEmail > 0)
            //{
            //    TempData["error"] = "The email address you entered already exists. Please use another.";
            //    return RedirectToAction("Index", "ProducerUserInfo");
            //}

            if (model.ConfirmUserCode != model.UserCode)
            {
                TempData["error"] = "The Confirm Email Address and Email Address must match.";
                return RedirectToAction("Index", "ProducerUserInfo");
            }

            var emailUrl = "https://" + Request.Url.Authority.ToString();

            if (ModelState.IsValid)
            {
                db.ProducerUserInfoes.Add(model);
                db.SaveChanges();
                SendEmail(emailUrl, model.RecID, model.UserCode);
                TempData["error"] = "A confirmation email has been sent to you. Please refer to it for next steps.";
                return RedirectToAction("Index", "ProducerUserInfo");
            }

            return View(model);
        }

        // GET: ProducerUserInfo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            byte[] eID = Convert.FromBase64String(id);
            int rID = BitConverter.ToInt32(eID, 0);
            var verify = 0;

            ProducerUserInfo producerUserInfo = db.ProducerUserInfoes.Find(rID);

            if (producerUserInfo == null)
            {
                return RedirectToAction("Edit", "ProducerUserInfo", TempData["error"] = "The Producer Code you entered is not valid.");
            }
            else
            {
                verify = 1;
            }

            ProducerInfo producerInfo = db.Producers
            .Where(p => p.ProducerCode == producerUserInfo.ProducerCode)
            .FirstOrDefault();

            producerUserInfo.BusinessName = producerInfo.BusinessName;
            producerUserInfo.Address1 = producerInfo.MailingStreet;
            producerUserInfo.City = producerInfo.MailingCity;
            producerUserInfo.State = producerInfo.MailingState;
            producerUserInfo.ZipCode = producerInfo.MailingZipCode;

            if (verify == 1)
            {
                producerUserInfo.EmailVerified = true;
            } else
            {
                producerUserInfo.EmailVerified = false;
            }

            return View(producerUserInfo);
        }

        // POST: ProducerUserInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecID,ProducerCode,UserCode,FirstName,LastName,Address1,Address2,City,State,ZipCode,PrimaryPhoneType,PrimaryPhoneNumber,SecondaryPhoneType,SecondaryPhoneNumber,FaxNumber,EmailVerified")] ProducerUserInfo producerUserInfo)
        {
            byte[] bytes = BitConverter.GetBytes(producerUserInfo.RecID);
            string s = Convert.ToBase64String(bytes);

            if (ModelState.IsValid)
            {
                db.Entry(producerUserInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = s });
            } 
            return View(producerUserInfo);
        }
        
        // GET: ProducerUserInfo/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            byte[] eID = Convert.FromBase64String(id);
            int rID = BitConverter.ToInt32(eID, 0);
            ViewBag.id = id;

            ProducerUserInfo producerUserInfo = db.ProducerUserInfoes.Find(rID);

            if (producerUserInfo == null)
            {
                return HttpNotFound();
            }

            ProducerInfo producerInfo = db.Producers
            .Where(p => p.ProducerCode == producerUserInfo.ProducerCode)
            .FirstOrDefault();

            producerUserInfo.BusinessName = producerInfo.BusinessName;

            return View(producerUserInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public static void SendEmail(string urlFormat, int recID, string userCode)
        {
            byte[] bytes = BitConverter.GetBytes(recID);
            string s = Convert.ToBase64String(bytes);
            var confirmLink = string.Format(urlFormat + "/ProducerUserInfo/Edit/" + s);
            var bodyBuilder = new System.Text.StringBuilder();
            bodyBuilder.Append("Hello, <br/><br/>");
            bodyBuilder.Append("<a href=\"");
            bodyBuilder.Append(confirmLink);
            bodyBuilder.Append("\">");
            bodyBuilder.Append("Click here ");
            bodyBuilder.Append("</a>");
            bodyBuilder.Append("to verify your email address and continue to next steps. <br/><br/>");
            bodyBuilder.Append("NCJUA");

            var mail = new System.Net.Mail.MailMessage();
            mail.From = new MailAddress(ConfigurationManager.AppSettings["SmtpUser"]);
            mail.Subject = "NCJUA-NCIUA Producer Data Collection Confirmation Email Address";
            mail.Body = bodyBuilder.ToString();
            mail.IsBodyHtml = true;

            mail.To.Add(new MailAddress(userCode));

            var client = new SmtpClient()
            {
                Host = ConfigurationManager.AppSettings["SmtpHost"],
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };            

            client.Send(mail);
        }

    }
}
