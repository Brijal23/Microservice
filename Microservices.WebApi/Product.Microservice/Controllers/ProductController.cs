using Product.Microservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Products Product)
        {
            _context.Products.Add(Product);
            await _context.SaveChanges();
            return Ok(Product.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Products = await _context.Products.ToListAsync();
            if (Products == null) return NotFound();
            return Ok(Products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Product = await _context.Products.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (Product == null) return NotFound();
            return Ok(Product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Product = await _context.Products.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (Product == null) return NotFound();
            _context.Products.Remove(Product);
            await _context.SaveChanges();
            return Ok(Product.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Products ProductUpdate)
        {
            var Product = _context.Products.Where(a => a.Id == id).FirstOrDefault();
            if (Product == null) return NotFound();
            else
            {
                Product.Name = ProductUpdate.Name;
                Product.Description = ProductUpdate.Description;
                Product.SKU = ProductUpdate.SKU;
                await _context.SaveChanges();
                return Ok(Product.Id);
            }
        }
    }
}
