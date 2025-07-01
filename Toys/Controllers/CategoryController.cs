using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
// delete comments from all the code files
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860//

namespace Toys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/<CategoryController>//
        [HttpGet]
        public async Task<List<Category>> Get()//clean code - channge function name to more descriptive
        //use ActionResult<List<Category>> to return status codes - in all the controllers
        {
            return await _categoryService.GetCategories();
        }

        //delete
        // GET api/<CategoryController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<CategoryController>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<CategoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<CategoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
