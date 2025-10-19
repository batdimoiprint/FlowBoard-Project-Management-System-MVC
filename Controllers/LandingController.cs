using Microsoft.AspNetCore.Mvc;
using FlowBoard_Project_Management_System_MVC.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowBoard_Project_Management_System_MVC.Controllers
{
    public class LandingController : Controller
    {
        private readonly MongoDBContext _dbContext;

        public LandingController(MongoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> getLandingPage()
        {
            try
            {
                var collections = await _dbContext.GetCollectionNamesAsync();
                ViewBag.Message = "MongoDB connection successful.";
                ViewBag.Collections = collections;
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"MongoDB connection failed: {ex.Message}";
                ViewBag.Collections = new List<string>();
            }

            return View("Landing");
        }
    }
}
