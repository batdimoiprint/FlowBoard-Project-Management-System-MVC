using Microsoft.AspNetCore.Mvc;

namespace FlowBoard_Project_Management_System_MVC.Models
{
    public class NotificationModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
