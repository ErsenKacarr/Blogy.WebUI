using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message/")]
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;

        public MessageController(UserManager<AppUser> userManager, IMessageService messageService)
        {
            _userManager = userManager;
            _messageService = messageService;
        }
        [Route("")]
        [Route("MessageList")]
        public async Task<IActionResult> MessageList(string p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            p = user.Email;
            var messageList = _messageService.TGetMessageListByWriter(p);
            return View(messageList);
        }

        [Route("DeleteMessage/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            _messageService.TDelete(id);
            return RedirectToAction("MessageList");
        }

        [Route("ReadMessage/{id}")]
        public IActionResult ReadMessage(int id) 
        {
            var values = _messageService.TGetMessageByArticleId(id);
            return View(values);
        }
    }
}
