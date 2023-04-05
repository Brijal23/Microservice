using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Product.Microservice.Models
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(table => table.IsActive).HasDefaultValue(true).ValueGeneratedOnAdd();
                entity.Property(table => table.Createddate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                entity.Property(table => table.Createddate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
                entity.Property(table => table.Id).ValueGeneratedOnAdd().UseIdentityColumn();
                entity.HasKey(table => table.Id);
            });

        }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
        private const string CONNECTIONSTRING = "Data Source=DESKTOP-9N1RJHQ\\SQLEXPRESS;Initial Catalog=DevelopmentProduct;Integrated Security=true;Persist Security Info=False;Trust Server Certificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(CONNECTIONSTRING, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery));

        }

    }
}
