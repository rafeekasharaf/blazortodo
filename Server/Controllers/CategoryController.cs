using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDo.Shared;
using ToDo.Server.Services;


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

        [HttpGet("")]
        public ActionResult<List<Category>> GetCategories()
        {            
            return _catService.GetCategories();
        }

        [HttpGet("{id:length(24)}")]
        public Category GetCategoryById(string id) {
            return _catService.GetCategory(id);
        }

        [HttpPost]
        public Category CreateCategory(Category cat) {
            //cat.Active = 1;
            _catService.PostCategory(cat);

            return cat;
        }

        //[HttpPut]
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