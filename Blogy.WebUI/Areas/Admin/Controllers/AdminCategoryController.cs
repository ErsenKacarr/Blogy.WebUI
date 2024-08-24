using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCategory/")]
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public AdminCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _categoryService.TGetListAll();
            return View(values);
        }


        [Route("DeleteBlog/{id}")]
        public ActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("NewCategory")]
        public IActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        [Route("NewCategory")]
        public IActionResult NewCategory(Category category)
        {
            _categoryService.TInsert(category);
            return RedirectToAction("Index");
        }
    }
}
