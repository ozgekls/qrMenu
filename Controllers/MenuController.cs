using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qrMenu.Models;


namespace qrMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
         
        }


        //GET /menu
        //tüm menüyü çağıdrdık burada
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _context.MenuItems.ToListAsync();
            return Ok(items);
        }


        //GET /menu/{id}
        //burada da kimlik numarasını kullanarak(id) belirli bir içeriği çağırıyoruz
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.MenuItems.FindAsync(id);

            if (item == null)
                return NotFound();
            return Ok(item);

        }

        //POST /menu
        [HttpPost]
        public async Task<IActionResult> Create(MenuItem newItem)
        {
            _context.MenuItems.Add(newItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }

        //PUT /menu/{id}
        //ürün güncelleme
        [HttpPut("{id}")]
        public async  Task<IActionResult> Update(int id , [FromBody] MenuItem updatedItem)
        {
            var existingItem = await _context.MenuItems.FindAsync(id);
            if (existingItem == null)
                return NotFound();

            existingItem.Name = updatedItem.Name;
            existingItem.Description = updatedItem.Description;
            existingItem.Price = updatedItem.Price;

            await _context.SaveChangesAsync();

            return Ok(existingItem);



        }

        //DELETE /menu/{id}
        [HttpDelete("{id}")]
        public async  Task<IActionResult> Delete(int id)
        {
            var item = await _context.MenuItems.FindAsync(id);
            if (item == null) return NotFound();

            _context.MenuItems.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();

        }


    }
}
