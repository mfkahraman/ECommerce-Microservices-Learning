using ECommerce.Discount.Context;
using ECommerce.Discount.DTOs;
using ECommerce.Discount.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController(AppDbContext context, ILogger<CouponsController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var records = await context.Coupons.AsNoTracking().ToListAsync(cancellationToken);
                var values = records.Select(x => new ResultCouponDto
                {
                    CouponId = x.CouponId,
                    Code = x.Code,
                    DiscountRate = x.DiscountRate,
                    ExpireDate = x.ExpireDate,
                    ProductId = x.ProductId
                }).ToList();

                return Ok(values);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error retrieving coupons");
                return StatusCode(500, new { error = "An unexpected error occurred while retrieving coupons." });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            try
            {
                var record = await context.Coupons.FindAsync(new object[] { id }, cancellationToken);
                if (record == null)
                    return NotFound();
                var value = new ResultCouponDto
                {
                    CouponId = record.CouponId,
                    Code = record.Code,
                    DiscountRate = record.DiscountRate,
                    ExpireDate = record.ExpireDate,
                    ProductId = record.ProductId
                };
                return Ok(value);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error retrieving coupon with ID {CouponId}", id);
                return StatusCode(500, new { error = "An unexpected error occurred while retrieving the coupon." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCouponDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var entity = new Coupon
                {
                    Code = dto.Code,
                    DiscountRate = dto.DiscountRate,
                    ExpireDate = dto.ExpireDate,
                    ProductId = dto.ProductId
                };
                context.Coupons.Add(entity);
                await context.SaveChangesAsync(cancellationToken);

                var resultDto = new ResultCouponDto
                {
                    CouponId = entity.CouponId,
                    Code = entity.Code,
                    DiscountRate = entity.DiscountRate,
                    ExpireDate = entity.ExpireDate,
                    ProductId = entity.ProductId
                };

                return CreatedAtAction(nameof(GetById), new { id = entity.CouponId }, resultDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error creating coupon");
                return StatusCode(500, new { error = "An unexpected error occurred while creating the coupon." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCouponDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var entity = await context.Coupons.FindAsync(new object[] { id }, cancellationToken);
                if (entity == null)
                    return NotFound();
                entity.Code = dto.Code;
                entity.DiscountRate = dto.DiscountRate;
                entity.ExpireDate = dto.ExpireDate;
                entity.ProductId = dto.ProductId;
                await context.SaveChangesAsync(cancellationToken);

                var resultDto = new ResultCouponDto
                {
                    CouponId = entity.CouponId,
                    Code = entity.Code,
                    DiscountRate = entity.DiscountRate,
                    ExpireDate = entity.ExpireDate,
                    ProductId = entity.ProductId
                };

                return Ok(resultDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error updating coupon with ID {CouponId}", id);
                return StatusCode(500, new { error = "An unexpected error occurred while updating the coupon." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await context.Coupons.FindAsync(new object[] { id }, cancellationToken);
                if (entity == null)
                    return NotFound();

                context.Coupons.Remove(entity);
                await context.SaveChangesAsync(cancellationToken);
                return Ok(new { message = $"Record with ID {id} successfully deleted." });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error deleting coupon with ID {CouponId}", id);
                return StatusCode(500, new { error = "An unexpected error occurred while deleting the coupon." });
            }
        }
    }
}
