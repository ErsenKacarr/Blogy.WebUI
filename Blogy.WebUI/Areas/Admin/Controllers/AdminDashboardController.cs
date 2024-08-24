using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminDashboard/")]
    public class AdminDashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly BlogyContext _context;
        private readonly IArticleService _articleService;

        public AdminDashboardController(UserManager<AppUser> userManager, BlogyContext context, IArticleService articleService)
        {
            _userManager = userManager;
            _context = context;
            _articleService = articleService;
        }


        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.yazarsayisi = _context.Writers.ToList().Count();
            ViewBag.categorisayisi = _context.Categories.ToList().Count();
            ViewBag.sinemasayisi = _articleService.TGetListAll().Where(x => x.CategoryId == 4).Count();
            ViewBag.oyunsayisi = _articleService.TGetListAll().Where(x => x.CategoryId == 3).Count();
            ViewBag.teknolojisayisi = _articleService.TGetListAll().Where(x => x.CategoryId == 1).Count();
            ViewBag.sporsayisi = _articleService.TGetListAll().Where(x => x.CategoryId == 2).Count();
            ViewBag.sagliksayisi = _articleService.TGetListAll().Where(x => x.CategoryId == 5).Count();
            ViewBag.yemeksayisi = _articleService.TGetListAll().Where(x => x.CategoryId == 6).Count();
            ViewBag.tarihsayisi = _articleService.TGetListAll().Where(x => x.CategoryId == 9).Count();
            return View();
        }
    }
}
