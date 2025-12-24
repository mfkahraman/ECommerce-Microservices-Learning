using Ecommerce.Catalog.Entities;
using Ecommerce.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await categoryService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await categoryService.GetByIdAsync(id);
            if (value == null)
            {
                return NotFound($"Record with ID {id} not found.");
            }

            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Category entity)
        {
            await categoryService.AddAsync(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }
    }
}
