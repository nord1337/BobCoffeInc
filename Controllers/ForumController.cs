using BobCoffeInc.Models.ForumModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
namespace BobCoffeInc.Controllers
{
    public class ForumController : Controller
    {
        ForumContext db = new ForumContext();
        
        public ActionResult ForumCategory()
        {
             string[] categories = { "Американо", "Эспрессо", "Латте", "Раф-кофе",
                         "Прочее" };
            
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@ForumTitle", categories[0]);
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@ForumTitle", categories[1]);
            System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@ForumTitle", categories[2]);
            System.Data.SqlClient.SqlParameter param3 = new System.Data.SqlClient.SqlParameter("@ForumTitle", categories[3]);
            System.Data.SqlClient.SqlParameter param4 = new System.Data.SqlClient.SqlParameter("@ForumTitle", categories[4]);
            ViewBag.PostsAmericano = db.ForumCategories.SqlQuery("SELECT * FROM ForumCategories WHERE MainTitle=@ForumTitle ORDER BY Created DESC", param).ToList<ForumCategories>();
            ViewBag.PostsEspresso = db.ForumCategories.SqlQuery("SELECT * FROM ForumCategories WHERE MainTitle=@ForumTitle ORDER BY Created DESC ", param1).ToList<ForumCategories>();
            ViewBag.PostsLatte = db.ForumCategories.SqlQuery("SELECT * FROM ForumCategories WHERE MainTitle=@ForumTitle ORDER BY Created DESC ", param2).ToList<ForumCategories>();
            ViewBag.PostsRaf = db.ForumCategories.SqlQuery("SELECT * FROM ForumCategories WHERE MainTitle=@ForumTitle ORDER BY Created DESC ", param3).ToList<ForumCategories>();
            ViewBag.PostsOther = db.ForumCategories.SqlQuery("SELECT * FROM ForumCategories WHERE MainTitle=@ForumTitle ORDER BY Created DESC ", param4).ToList<ForumCategories>();
            return View();
        }
        public ActionResult ForumCategoryOverview(string title)
        {
            try
            {
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@ForumTitle", title);
                ViewBag.Forums = db.ForumCategories.SqlQuery("SELECT * FROM ForumCategories WHERE MainTitle=@ForumTitle ORDER BY Created",param).ToList<ForumCategories>();
                ViewBag.Theme = title;
                return View();
            }
            catch
            {
                return HttpNotFound();
            } 
        }
        [HttpGet]
        public ActionResult ForumPost(int ?Id,string Title)
        {
            if (Id == null) return HttpNotFound();
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@ForumCategoriesId", Id);
            ViewBag.Posts = db.Posts.SqlQuery("SELECT * FROM Posts WHERE ForumCategoriesId=@ForumCategoriesId",param).ToList<Post>();
            ViewBag.Id = Id;
            ViewBag.CoffeTitle = Title;
            ViewBag.MainTitle = db.ForumCategories.First(c => c.Id == Id).MainTitle;
            return View();
        }
        [HttpPost]
        public ActionResult ForumPost(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();
            ViewBag.Post = post;
            return PartialView("ForumPostUpdate");
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            var CoffeCategories = new CoffeCategories();
            ViewBag.CoffeCategories = CoffeCategories;
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(ForumCategories ForumCategory)
        {
            db.ForumCategories.Add(ForumCategory);
            db.SaveChanges();
            return RedirectToAction("ForumPost",new { Id=ForumCategory.Id,Title=ForumCategory.Title});
        }
    }
}