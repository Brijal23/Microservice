using Microsoft.EntityFrameworkCore;

namespace Customer.Microservice.Models
{
    public interface IApplicationDbContext
    {
        DbSet<Customers> Customers { get; set; }

        Task<int> SaveChanges();
    }
}