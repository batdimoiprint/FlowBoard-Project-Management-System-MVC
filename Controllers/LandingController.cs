using Microsoft.AspNetCore.Mvc;

namespace FlowBoard_Project_Management_System_MVC.Controllers
{
    public class LandingController : Controller
    {
        public IActionResult getLandingPage()
        {
            return View("Landing");
        }
    }
}
