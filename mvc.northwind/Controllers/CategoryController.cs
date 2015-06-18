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
            var category = db.Categories.FirstOrDefault(x => x.CategoryID == id);
            return View(category);
        }

        // POST: Category/Update

    }
}