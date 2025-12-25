using ECommerce.Discount.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Discount.Context
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Coupon> Coupons { get; set; }
    }
}
