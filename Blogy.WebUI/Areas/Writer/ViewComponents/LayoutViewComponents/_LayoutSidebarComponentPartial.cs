﻿using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.ViewComponents.LayoutViewComponents
{
    public class _LayoutSidebarComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;

        public _LayoutSidebarComponentPartial(UserManager<AppUser> userManager, IArticleService articleService)
        {
            _userManager = userManager;
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.resim = values.ImageUrl;
            ViewBag.adsoyad = values.Name + "" + values.Surname;
            ViewBag.blogsayi = _articleService.TGetArticlesByWriter(values.Id).Count();
            return View();
        }
    }
}
