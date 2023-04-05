
using Customer.Microservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customer.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customers customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChanges();
            return Ok(customer.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _context.Customers.ToListAsync();
            if (customers == null) return NotFound();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Customer = await _context.Customers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (Customer == null) return NotFound();
            return Ok(Customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Customer = await _context.Customers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (Customer == null) return NotFound();
            _context.Customers.Remove(Customer);
            await _context.SaveChanges();
            return Ok(Customer.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Customers CustomerUpdate)
        {
            var Customer = _context.Customers.Where(a => a.Id == id).FirstOrDefault();
            if (Customer == null) return NotFound();
            else
            {
                Customer.Name = CustomerUpdate.Name;
                Customer.Email = CustomerUpdate.Email;
                Customer.PhoneNumber = CustomerUpdate.PhoneNumber;
                await _context.SaveChanges();
                return Ok(Customer.Id);
            }
        }
    }
}
