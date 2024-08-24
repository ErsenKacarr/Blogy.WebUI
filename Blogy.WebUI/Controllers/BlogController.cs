using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{

    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;

        public BlogController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult BlogList(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var articles = _articleService.TGetArticleFilterList(search);
                ViewBag.Search = search;
                return View(articles);
            }
            else
            {
                var values = _articleService.TGetArticleWithWriter();
                return View(values);

            }
        }

        public IActionResult BlogDetail(int id)
        {
            ViewBag.i = id;
            return View();
        }
    }
}
