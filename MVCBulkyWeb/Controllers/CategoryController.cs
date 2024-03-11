using Microsoft.AspNetCore.Mvc;
using MVCBulky.DataAccess;
using MVCBulky.Models;


namespace MVCBulkyWeb.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
			_db = db;
        }
        public IActionResult Index()
		{
			List<Category> objCategoryList = _db.Categories.ToList();
			return View(objCategoryList);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Category category)
		{
			//ModelState.AddModelError("Name","")
			if(ModelState.IsValid)
			{

			_db.Categories.Add(category);
			_db.SaveChanges();
                TempData["success"] = "Category Added Successfully";
                return RedirectToAction("Index");
			}
			return View();
		}
        public IActionResult Edit(int? id)
        {
			if(id == null || id ==0) {
				return NotFound();
			}

			Category category = _db.Categories.FirstOrDefault(c => c.Id == id);
			if(category == null)
			{
				return NotFound();
			}
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            //ModelState.AddModelError("Name","")
            if (ModelState.IsValid)
            {

                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            //ModelState.AddModelError("Name","")
            Category category = _db.Categories.FirstOrDefault(c => c.Id == id);

            _db.Categories.Remove(category);
                _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
                return RedirectToAction("Index");
            
        }
    }
}
