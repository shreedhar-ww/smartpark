using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SmartPark.Entity;
using SmartPark.Data;
using SmartPark.Helper;
using System.Globalization;
using System.Configuration;
using SmartPark.MSMQ;
using System.Net.Mail;



namespace SmartPark.Controllers
{

    public class AccountController : Controller
    {

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //  [ValidateAntiForgeryToken]
        public ActionResult LogIn(User model, string returnUrl)
        {
            if (ModelState.IsValid && Membership.ValidateUser(model.UserName, model.Password))
            {
                DBCustMembership objDalCustMem = new DBCustMembership();
                DBCustRoleProvider objDalRole = new DBCustRoleProvider();
                string SystemUserRole = objDalRole.getUserRolesByUserID(model.UserName);
                if (SystemUserRole == "Inactive ServiceProvider")
                {
                    ModelState.AddModelError("UsrnamePassword", "The Username or password you entered is incorrect.");
                    model.Password = "";
                    return View(model);
                }
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                switch (SystemUserRole)
                {
                    case "Back Office Agent":
                        if (!(bool)HttpContext.Items["AllowBackOffice"])
                        {
                            ModelState.AddModelError("UsrnamePassword", "Check with your Administrator.");
                            model.Password = "";
                            return View(model);

                        }

                        break;
                    case "Client Agent":
                        if (!(bool)HttpContext.Items["AllowAgentKiosk"])
                        {
                            ModelState.AddModelError("UsrnamePassword", "Check with your Administrator.");
                            model.Password = "";
                            return View(model);
                        }
                        break;
                }




                //Change password for first time login.
                if (!(bool)HttpContext.Items["IsPasswordReset"])
                {
                    return RedirectToAction("ResetPassword", "Account");
                }
                else
                {
                    //Navigat to Cliest list page for Admin Client
                    return RedirectToLocal(SystemUserRole);
                }

            }

            // If we got this far, something failed, redisplay form
            //  ModelState.AddModelError("", "The user name or password provided is incorrect.");
            ModelState.AddModelError("UsrnamePassword", "The Username or password you entered is incorrect.");
            model.Password = "";
            return View(model);
        }


        /// <summary>
        /// Reset password for first time login by User
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(SmartPark.Entity.ResetPassword model)
        {
            if (ModelState.IsValid)
            {
                DBCustMembership ObjUser = new DBCustMembership();
                var CurrentUserName = User.Identity.Name;
                if (string.IsNullOrEmpty(CurrentUserName))
                    return RedirectToAction("LogIn", "Account");
                if (!(ObjUser.ResetPassword(CurrentUserName, model.Password, model.NewPassword)))
                {
                    ModelState.AddModelError("Password", "Password supplied was invalid");
                    return View(model);
                }
                return RedirectToAction("LogIn", "Account");
                //if (bResult)
                //    return RedirectToLocal(SystemUserRole);
            }
            return View();
        }

        public ActionResult LogOff()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            //if (Request.Cookies["ST"] != null)
            //{
            //    var cookie = new HttpCookie("ST");
            //    cookie.Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies.Add(cookie);
            //}

            string[] myCookies = Request.Cookies.AllKeys;
            foreach (string cookie in myCookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }

            return View();
        }

        private ActionResult RedirectToLocal(string SystemUserRole)
        {
            if (SystemUserRole == "Sys Admin")
            {
                return RedirectToAction("Index", "Welcome");
            }
            //Navigate to select section / Agent Kiosk screen for other client admin and agent kiosk role user
            else if (SystemUserRole == "Client Admin")
            {
                setServiceProviderID(SystemUserRole);
                return RedirectToAction("SelectService", "Welcome");
            }
            else if (SystemUserRole == "Client Agent")
            {
                setServiceProviderID(SystemUserRole);
                return RedirectToAction("Index", "AgentKiosk");
            }
            else if (SystemUserRole == "Back Office Agent")
            {
                setServiceProviderID(SystemUserRole);
                return RedirectToAction("Index", "BackOffice");
            }
            else
            {
                return RedirectToAction("LogIn", "Account");
            }
        }


        public void setServiceProviderID(string Role)
        {
            //using (SmartPark.Helper.ServiceProviderHelper objserviceProvider = new Helper.ServiceProviderHelper())
            //{
            //    objserviceProvider.setServiceProviderNameandID(Role);
            //}
        }


        public ActionResult ForgotUsername()
        {
            ViewBag.Message = " We'll email you instructions on how to reset your username.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotUsername(UserModel objUser)
        {

            HttpCookie logo = HttpContext.Request.Cookies.Get("logo");

            DBUser objDBUser = new DBUser();
            UserModel objUserModel = new UserModel();
            objUserModel = objDBUser.ForgotUserName(objUser.Email);
            if (objUserModel.Username != null && objUserModel.Username != "")
            {
                #region old code
                //MailHelper NSSMailHelper = new MailHelper();
                //EmailMessage NSSEmailMessage = new EmailMessage();

                //NSSEmailMessage.Subject = "Username Request";
                //NSSEmailMessage.To = objUser.Email;
                //NSSEmailMessage.Body = "";
                //NSSEmailMessage.From = "shreedhar.deshwal@gmail.com";
                //NSSEmailMessage.TemplatePath = Constants.TemplatePath;
                //NSSEmailMessage.TemplateLogo = Constants.TemplateLogo;
                //NSSEmailMessage.Template = "ForgotUsername";
                ////NSSEmailMessage.MarkerList.Add("##CreatedDate##", DateTime.Now.ToString(Constants.DateFormat));
                ////     NSSEmailMessage.MarkerList.Add("##SentTo##", usersModel.FirstName + " " + usersModel.LastName);
                //NSSEmailMessage.MarkerList.Add("##PortalURL##", Constants.BasePath);
                //NSSEmailMessage.MarkerList.Add("{$firstname}", objUserModel.FirstName);
                //NSSEmailMessage.MarkerList.Add("{$lastname}", objUserModel.LastName);
                //NSSEmailMessage.MarkerList.Add("{$Username}", objUserModel.Username);
                //NSSEmailMessage.MarkerList.Add("{$newPasswordUrl}", "smartpark.aspnetdevelopment.in/Account/Login");

                ////   NSSEmailMessage.MarkerList.Add("##Body##", msg);
                ////NSSEmailMessage.MarkerList.Add("##IssuedBy##", "Administrator");
                ////string message = NSSMailHelper.DraftMail(NSSEmailMessage);

                //try
                //{
                //    MailMessage mail = new MailMessage();
                //    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //    mail.From = new MailAddress("your_email_address@gmail.com");
                //    mail.To.Add("sidcoder85@gmail.com");
                //    //mail.To.Add("sidcoder85@gmail.com");
                //    mail.Subject = "Error";
                //    mail.Bcc.Add("shreedhar.deshwal@gmail.com");
                //    SmtpServer.Port = 587;
                //    SmtpServer.Credentials = new System.Net.NetworkCredential("shreedhar.deshwal@gmail.com",
                //        "ghostprotocol");
                //    SmtpServer.EnableSsl = true;
                //    //  SmtpServer.SendAsync(mail, null);
                //    SmtpServer.SendAsync(mail, null);
                //}

                //catch(Exception ex)
                //{
                //    string mg = ex.Message;
                //}



                #endregion
                MSMQEmail email = new MSMQEmail();
                email.Subject = "Username Request";
                email.To = objUser.Email;
                email.From = "shreedhar.deshwal@gmail.com";
                //email.Message = "testmessage";
                email.FirstName = objUserModel.FirstName;
                email.LastName = objUserModel.LastName;
                email.Username = objUserModel.Username;
                if (logo != null && logo.Value != "")
                    email.Logo = logo.Value;
                email.TemplateName = "ForgotUsernameadmin";
                email.ServiceProviderID = objUserModel.ServiceProviderID;
                email.URL = ConfigurationManager.AppSettings["AdminURL"];
                // email.validUntil = validUntilDt;
                new QueueService().QueueMessage(email);

                ViewBag.SuccessMessage = "User Name has been sent successfully in the provided Email Address";
            }

            else
            {
                ViewBag.ErrorMessage = "User with given Email Id doesn't exist.";
            }

            return View();
        }

        public ActionResult ForgotPassword()
        {
            ViewBag.Message = " We'll email you instructions on how to reset your password.";
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string EmailId, string localDate)
        {
            DBUser objDBUser = new DBUser();
            UserModel objUserModel = new UserModel();
            JsonResult data = new JsonResult();
            objUserModel = objDBUser.GetResetPasswordLink(EmailId);
            if (objUserModel.Username != null && objUserModel.Username != "")
            {
                //DateTime localDt = DateTime.UtcNow.AddMinutes(localDate*(-1));
                //DateTime localDt=utcDate.ToLocalTime();

                //DateTime date = DateTime.Parse(localDate.Replace(",", " "),);

                //DateTime date = DateTime.ParseExact(localDate.Replace(",", " "), "MM/dd/yyyy HH:mm:ss tt", CultureInfo.CurrentCulture.DateTimeFormat);

                DateTime localDt = Convert.ToDateTime(localDate.Replace(",", " ")).AddDays(1);
                string validUntilDt = localDt.ToString("dd MMM yyyy hh:mm tt");

                HttpCookie logo = HttpContext.Request.Cookies.Get("logo");

                MSMQEmail email = new MSMQEmail();
                email.Subject = "Password Request";
                email.To = EmailId;
                email.From = "shreedhar.deshwal@gmail.com";
                //email.Message = "testmessage";
                email.FirstName = objUserModel.FirstName;
                email.LastName = objUserModel.LastName;
                email.Username = objUserModel.Username;
                if (logo != null && logo.Value != "")
                    email.Logo = logo.Value;
                email.ServiceProviderID = objUserModel.ServiceProviderID;
                email.TemplateName = "ForgotPasswordadmin";
                email.URL = ConfigurationManager.AppSettings["AdminURL"] + "Account/AccessForgotPasswordLink?ResetPasswordId=" + objUserModel.Email;
                email.validUntil = validUntilDt;
                new QueueService().QueueMessage(email);

                #region Mail sending
                //MailHelper NSSMailHelper = new MailHelper();
                //EmailMessage NSSEmailMessage = new EmailMessage();

                //NSSEmailMessage.Subject = "Password Request";
                //NSSEmailMessage.To = EmailId;
                //NSSEmailMessage.Body = "";
                //NSSEmailMessage.From = "shreedhar.deshwal@gmail.com";
                //NSSEmailMessage.TemplatePath = Constants.TemplatePath;
                //NSSEmailMessage.TemplateLogo = Constants.TemplateLogo;
                //NSSEmailMessage.Template = "ForgotPassword";
                ////NSSEmailMessage.MarkerList.Add("##CreatedDate##", DateTime.Now.ToString(Constants.DateFormat));
                ////     NSSEmailMessage.MarkerList.Add("##SentTo##", usersModel.FirstName + " " + usersModel.LastName);
                //NSSEmailMessage.MarkerList.Add("##PortalURL##", Constants.BasePath);
                //NSSEmailMessage.MarkerList.Add("{$firstname}", objUserModel.FirstName);
                //NSSEmailMessage.MarkerList.Add("{$lastname}", objUserModel.LastName);
                //NSSEmailMessage.MarkerList.Add("{$Username}", objUserModel.Username);
                //NSSEmailMessage.MarkerList.Add("{$newPasswordUrl}", "http://smartpark.aspnetdevelopment.in/Account/AccessForgotPasswordLink?ResetPasswordId=" + objUserModel.Email);
                //NSSEmailMessage.MarkerList.Add("{$validUntil}", validUntilDt);

                //   NSSEmailMessage.MarkerList.Add("##Body##", msg);
                //NSSEmailMessage.MarkerList.Add("##IssuedBy##", "Administrator");
                //string message = NSSMailHelper.DraftMail(NSSEmailMessage);
                #endregion

                data.Data = "success";
                //ViewBag.SuccessMessage = "New Link has been sent to the given Email Id";
            }

            else
            {
                data.Data = "error";
                //ViewBag.ErrorMessage = "User with given Email Id doesn't exist.";
            }

            return Json(data, JsonRequestBehavior.AllowGet);
            //return View();
        }


        public ActionResult AccessForgotPasswordLink(string ResetPasswordId)
        {
            TempData["ResetPasswordId"] = ResetPasswordId;
            TempData.Keep();
            DBUser objDBUser = new DBUser();
            int success = objDBUser.ValidateResetPasswordLink(TempData["ResetPasswordId"].ToString());
            if (success == 1)
            {
                return View("ChangeForgotPassword");
            }
            else
            {
                return View("LinkExpired");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccessForgotPasswordLink(ResetPassword objResetPassword)
        {

            DBUser objDBUser = new DBUser();

            if (TempData["ResetPasswordId"] == null)
            {
                return View("LinkExpired");
            }
            int success = objDBUser.AccessResetPasswordLink(TempData["ResetPasswordId"].ToString(), objResetPassword.NewPassword);
            if (success == 1)
            {
                ViewBag.Message = "Password has been updated successfully !!";
            }
            if (success == -2)
            {
                ViewBag.Message = "Invalid link Accessed!";
            }
            return View("ChangeForgotPassword");

        }


        public ActionResult SessionTimeout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return View("_sessiontimeout");
        }

        public ActionResult DisplayErrorMessage()
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            return View();
        }
    }
}
