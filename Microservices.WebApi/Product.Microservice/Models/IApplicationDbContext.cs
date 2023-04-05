using Microsoft.EntityFrameworkCore;

namespace Product.Microservice.Models
{
    public interface IApplicationDbContext
    {
        DbSet<Products> Products { get; set; }
        Task<int> SaveChanges();
    }
}