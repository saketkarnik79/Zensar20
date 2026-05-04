using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Web_DemoWebAPIWithEFCore.Infrastructure.Data;
using Web_DemoWebAPIWithEFCore.Models;
using Web_DemoWebAPIWithEFCore.Application.UnitOfWork;

namespace Web_DemoWebAPIWithEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        // private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public ProductsApiController(AppDbContext context)
        //{
        //    _context = context;
        //}

        public ProductsApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/ProductsApi
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            //return await _context.Products.ToListAsync();
            var products= await _unitOfWork.Products.GetAllAsync();
            return Ok(products);
        }

        // GET: api/ProductsApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            //var product = await _context.Products.FindAsync(id);

                var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/ProductsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            //_context.Entry(product).State = EntityState.Modified;
            _unitOfWork.Products.Update(product);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                if (!await ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return NoContent();
        }

        // POST: api/ProductsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostProduct(Product product)
        {
            //_context.Products.Add(product);
            //await _context.SaveChangesAsync();

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/ProductsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            //var product = await _context.Products.FindAsync(id);
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // _context.Products.Remove(product);
            _unitOfWork.Products.Remove(product);
            //await _context.SaveChangesAsync();
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        private async Task<bool> ProductExists(int id)
        {
            //return _context.Products.Any(e => e.Id == id);
            var products = await _unitOfWork.Products.GetAllAsync();
            return products.Any(e => e.Id == id);
        }
    }
}
