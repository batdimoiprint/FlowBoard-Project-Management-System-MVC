using Microsoft.AspNetCore.Mvc;

namespace FlowBoard_Project_Management_System_MVC.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn([FromForm] string email, [FromForm] string password, [FromForm] bool remember = false)
        {
            // Minimal placeholder authentication.
            // Replace with real user lookup in MongoDB via MongoDBContext when integrating.
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError(string.Empty, "Email and password are required.");
                return View("Login");
            }

            // For demo: accept any password 'password123' as valid
            if (password == "password123")
            {
                // TODO: issue authentication cookie, set claims, etc.
                return RedirectToAction("getLandingPage", "Landing");
            }

            ModelState.AddModelError(string.Empty, "Invalid credentials.");
            return View("Login");
        }
    }
}
