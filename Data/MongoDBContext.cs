using Microsoft.AspNetCore.Mvc;
using FlowBoard_Project_Management_System_MVC.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowBoard_Project_Management_System_MVC.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING") 
                                  ?? configuration.GetConnectionString("MongoDB");
            var mongoUrl = new MongoUrl(connectionString);
            var client = new MongoClient(mongoUrl);
            _database = client.GetDatabase("flowboard_db");
        }

        public IMongoCollection<UserModel> Users => _database.GetCollection<UserModel>("user");
        public IMongoCollection<ProjectModel> Projects => _database.GetCollection<ProjectModel>("project");
        public IMongoCollection<BoardModel> Boards => _database.GetCollection<BoardModel>("boards");
        public IMongoCollection<TaskModel> Tasks => _database.GetCollection<TaskModel>("tasks");
        public IMongoCollection<NotificationModel> Notifications => _database.GetCollection<NotificationModel>("notification");
        public IMongoCollection<PermissionModel> Permissions => _database.GetCollection<PermissionModel>("permission");

        public async Task<List<string>> GetCollectionNamesAsync()
        {
            var cursor = await _database.ListCollectionNamesAsync();
            return await cursor.ToListAsync();
        }
    }
}
