using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDo.Shared;
using ToDo.Server.Services;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;

namespace Server.Controllers
{   

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private CategoryService _catService;

        public CategoryController(CategoryService categoryService)
        {
            _catService = categoryService;
        }

        [HttpGet("{type}/{email}")]
        public  List<Category> GetCategories(string type, string email)
        {            
            return _catService.GetCategories(type, email);
        }

        [HttpGet("{id:length(24)}")]
        public Category GetCategoryById(string id) {
            return _catService.GetCategory(id);
        }

        [HttpPost]
        public Category CreateCategory(Category cat) {
            _catService.PostCategory(cat);

            return cat;
        }

        
        [HttpPut("{id}")]
        public Category UpdateCategory(string id, Category cat){
            // Microsoft.JSRuntime.Invoke("alert", System.Text.Json.JsonSerializer.Serialize(cat));             
           return  _catService.PutCategory(cat, id);
          
        }

        [HttpDelete("{id}")]
         public Category DeleteCategory(string id){
           return  _catService.DeleteCategory(id);
        }

    }
}