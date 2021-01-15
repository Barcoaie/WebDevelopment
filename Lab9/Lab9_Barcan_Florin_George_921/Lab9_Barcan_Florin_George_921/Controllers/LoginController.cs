using Lab9_Barcan_Florin_George_921.DataAbstractionLayer;
using Lab9_Barcan_Florin_George_921.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab9_Barcan_Florin_George_921.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login()
        {
            string user_name = Request.Params["user_name"];
            string pass_word = Request.Params["pass_word"];
            DAL dal = new DAL();
            User logged_used = dal.Login(user_name, pass_word);
            Session["user_ID"] = logged_used.user_ID;
            Console.Write(logged_used.username);
            if (Session["user_ID"] == null)
                return View();
            return RedirectToAction("ViewGetAuthors", "Main", new { area = "" });
        }
    }
}