using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    public class AdminNotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
