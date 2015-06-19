using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using mvc.northwind.EF;

namespace mvc.northwind.Controllers
{
    public class CategoryController : Controller
    {
        public Northwind db = new Northwind();

        // GET: Category
        public ActionResult Index()
        {
            ViewBag.list = db.Categories.AsEnumerable();

            return View();
        }

   
        public ActionResult Display(int id)
        {
            // Yeni Category için buttonTitle ViewBag.ButtonTitle = "Kaydet" olacak.
            var category = db.Categories.FirstOrDefault(x => x.CategoryID == id);
            ViewBag.ButtonTitle = "Update";
            ViewBag.Title = "Category Display/Update";
            ViewBag.Action = "/Category/Update";
            return View(category);
        }

        public ActionResult Update(Category category)
        {
            /* 
             * http://stackoverflow.com/q/15336248/1766716
             * View bütün property'leri içermediği için
             * View'de olmayan property'ler siliniyor.

             * db.Categories.Attach(category);
             * db.Entry(category).State = EntityState.Modified;
             * db.SaveChanges();
             */
            var original = db.Categories.Find(category.CategoryID);

            if (original != null)
            {
                original.CategoryName = category.CategoryName;
                original.Description = category.Description;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult New()
        {
            ViewBag.Title = "New Category";
            ViewBag.ButtonTitle = "Create";
            ViewBag.Action = "/Category/Create";
            return View();
        }

    }
}