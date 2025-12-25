using ECommerce.Discount.Context;
using ECommerce.Discount.DTOs;
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
            var values = records.Select(x=> new ResultCouponDto
            {
               CouponId = x.CouponId,
                Code = x.Code,
                DiscountRate = x.DiscountRate,
                ExpireDate = x.ExpireDate,
                ProductId = x.ProductId
            }).ToList();

            return Ok(values);
        }
    }
}
