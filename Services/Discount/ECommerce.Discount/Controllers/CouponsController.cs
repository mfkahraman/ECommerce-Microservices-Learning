using ECommerce.Discount.Context;
using ECommerce.Discount.DTOs;
using ECommerce.Discount.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var records = await context.Coupons.ToListAsync();
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await context.Coupons.FindAsync(id);
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateCouponDto dto)
        {
            var entity = new Coupon
            {
                Code = dto.Code,
                DiscountRate = dto.DiscountRate,
                ExpireDate = dto.ExpireDate,
                ProductId = dto.ProductId
            };
            context.Coupons.Add(entity);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.CouponId }, entity);
        }
    }
}
