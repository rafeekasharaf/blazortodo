
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

using ToDo.Shared;

namespace ToDo.Server.Services
{
    public class UserService
    {

        private IMongoCollection<Users> _user;
        public UserService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoCloud"));
            var database = client.GetDatabase("RemindMe");

            _user = database.GetCollection<Users>("User");
        }        
        public Users GetCategory(string id) => _user.Find(user => user.UserID == id).FirstOrDefault();

    }
}