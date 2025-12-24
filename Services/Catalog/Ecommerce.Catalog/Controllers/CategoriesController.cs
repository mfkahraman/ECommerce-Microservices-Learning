using AutoMapper;
using Ecommerce.Catalog.DTOs.CategoryDTOs;
using Ecommerce.Catalog.Entities;
using Ecommerce.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService service,
                                      IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await service.GetAllAsync();
            var dtos = mapper.Map<IEnumerable<GetCategoryDto>>(values);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await service.GetByIdAsync(id);
            if (value == null)
            {
                return NotFound($"Record with ID {id} not found.");
            }

            var dto = mapper.Map<GetCategoryDto>(value);
            return Ok(dto);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            var entity = mapper.Map<Category>(dto);
            await service.AddAsync(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateCategoryDto dto)
        {
            var existingEntity = await service.GetByIdAsync(dto.Id);
            if (existingEntity == null)
            {
                return NotFound($"Record with ID {dto.Id} not found.");
            }

            mapper.Map(dto, existingEntity);
            await service.UpdateAsync(existingEntity);
            return Ok("Successfully updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await service.DeleteAsync(id);

            return Ok($"Record with ID {id} successfully deleted.");

        }
    }
}
