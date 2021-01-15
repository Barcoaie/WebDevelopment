using Lab9_Barcan_Florin_George_921.DataAbstractionLayer;
using Lab9_Barcan_Florin_George_921.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab9_Barcan_Florin_George_921.Controllers
{
    public class MainController : Controller
    {
        public ActionResult FilterRecipes()
        {
            if (Session["user_ID"] != null)
            {
                int author_id = int.Parse(Request.Params["Recipe_Author_ID"]);
                DAL dal = new DAL();
                List<Recipe> recipes = dal.GetRecipesFromAuthor(author_id);
                ViewData["recipeList"] = recipes;
                return View("FilterRecipes");
            }
            return RedirectToAction("Login", "Login", new { area = "" });
        }

        // GET: Main
        public ActionResult Index()
        {
            return View("ViewAuthors");
        }

        public string Test()
        {
            return "IT WORKS";
        }

        // GET: Main/ViewGetAuthors
        public ActionResult ViewGetAuthors()
        {
            if (Session["user_ID"] != null)
            {
                DAL dal = new DAL();
                List<Author> authors = dal.GetAuthors();
                ViewData["authorList"] = authors;
                return View("ViewGetAuthors");
            }
            return RedirectToAction("Index", "Login", new { area = "" });
        }

        // GET: Main/GetRecipes
        public ActionResult ViewGetRecipes()
        {
            if (Session["user_ID"] != null || (int)Session["user_ID"] == 0)
            {
                DAL dal = new DAL();
                List<Recipe> recipes = dal.GetRecipes();
                ViewData["recipeList"] = recipes;
                return View("ViewGetRecipes");
            }
            return RedirectToAction("Index", "Login", new { area = "" });
        }

        public ActionResult DeleteRecipe()
        {
            return View("DeleteRecipe");
        }

        public ActionResult EditRecipe()
        {
            return View("EditRecipe");
        }

        public ActionResult AddRecipe()
        {
            return View("AddRecipe");
        }

        public ActionResult DeleteAuthor()
        {
            return View("DeleteAuthor");
        }

        public ActionResult EditAuthor()
        {
            return View("EditAuthor");
        }

        public ActionResult AddAuthor()
        {
            return View("AddAuthor");
        }
    }
}