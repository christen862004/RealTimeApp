using Microsoft.AspNetCore.Mvc;

namespace RealTimeApp.Controllers
{
    public class ChatRoomController : Controller
    {
        public IActionResult Index()
        {//
            return View();
        }
    }
}
