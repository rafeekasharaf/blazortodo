
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

using ToDo.Shared;

namespace ToDo.Server.Services
{
    public class CategoryService {

        private IMongoCollection<Category> _category;
        public CategoryService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoCloud"));
            var database = client.GetDatabase("RemindMe");

            _category = database.GetCollection<Category>("Category");
        }

       public List<Category> GetCategories() => _category.Find(category => true).ToList();//.OrderBy(category => category.Active).ThenByAscending(category=>category.Completed).ToList();
        public Category GetCategory(string id) => _category.Find(category => category.CategoryID == id).FirstOrDefault();

       /*  public List<Category> GetCategories() {
             List<Category> cats = _category.Find(category => true);

             return cats.OrderBy(category => category.Active).OrderBy(category=>category.Completed).ToList();
         }*/
        
        public Category PostCategory(Category cat) {
            _category.InsertOne(cat);

            return cat;
        }

        public Category PutCategory(Category cat, string id) {
            _category.ReplaceOne(category => category.CategoryID == id, cat);

            return cat;
        }

        public Category DeleteCategory(string id) {
            var oldCat = GetCategory(id);
            _category.DeleteOne(category => category.CategoryID == id);

            return oldCat;
        }
        
    }
}
