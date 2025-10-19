using FlowBoard_Project_Management_System_MVC.Data;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace FlowBoard_Project_Management_System_MVC.Controllers
{
    public class TestConnectionController : Controller
    {
        private readonly MongoDBContext _dbContext;

        public TestConnectionController(MongoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            try
            {
                // Try to list collections in your database
                var collections = _dbContext.GetType()
                    .GetProperties()
                    .Select(p => p.Name)
                    .ToList();

                ViewBag.Message = "MongoDB connection successful!";
                ViewBag.Collections = collections;
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Connection failed: {ex.Message}";
                ViewBag.Collections = new List<string>();
            }

            return View();
        }
    }
}
