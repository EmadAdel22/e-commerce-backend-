using Microsoft.AspNetCore.Mvc;
using e_commerce.Data;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class productudController : ControllerBase
    {
        private readonly AppDbContext _context;

        public productudController(AppDbContext context)
        {
            _context = context;
        }


        // productus

        [HttpGet("AllProducts")]
        public IActionResult getallproducts() {

            return Ok(_context.products.ToList());
        
        }

        [HttpPost("product")]
        public IActionResult addproduct(productsDto p)
        {
            var categoryExists = _context.Categories.Any(c => c.id == p.categoryId);
            if (!categoryExists)
            {
                return NotFound($"Category with Id {p.categoryId} not found");
            }


            var newProduc = new product
            {
                name = p.name,
                description = p.description,
                price = p.price,
                imageUrl = p.imageUrl,
                categoryId = p.categoryId
            };

            _context.products.Add(newProduc);
            _context.SaveChanges();
            return Ok(p);
        }

        [HttpPut("updateproduct/{id}")]
        public IActionResult updateproduct(product product) {
            var existingProduct = _context.products.Find(product.id);
            if (existingProduct == null)
            {
                return NotFound("Product not found");
            }

            existingProduct.name = product.name;
            existingProduct.description = product.description;
            existingProduct.price = product.price;
            existingProduct.imageUrl = product.imageUrl;
            existingProduct.categoryId = product.categoryId;

            _context.SaveChanges();
            return Ok(existingProduct);
        }

        [HttpDelete("deleteproduct/{id}")]
        public IActionResult deleteproduct(int id) {
            var product = _context.products.Find(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            _context.products.Remove(product);
            _context.SaveChanges();
            return Ok("Product deleted successfully");
        }   

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("No image uploaded");

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

            var filePath = Path.Combine(folderPath, image.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            var imageUrl = "images/" + image.FileName;

            return Ok(imageUrl);
        }




        //Categories

        [HttpGet("category/{CategId}")]
        public IActionResult GetProductsByCategory(int CategId)
        {
            var categoryExists = _context.Categories.Any(c => c.id == CategId);

            if (!categoryExists)
            {
                return NotFound("Category not found");
            }
            var products = _context.products
                .Where(p => p.categoryId == CategId)
                .ToList();

            return Ok(products);
        }



        

        [HttpPost("category")]
        public IActionResult addcategory(Category c)
        {
            _context.Categories.Add(c);
            _context.SaveChanges();
            return Ok(c);
        }

        [HttpDelete("deletcategory/{id}")]
        public IActionResult deletecategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok("Category deleted successfully");

        }

        [HttpPut("updatecategory/{id}")]
        public IActionResult updatecategory(int id, Category updatedCategory)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }

            category.name = updatedCategory.name;
            _context.SaveChanges();
            return Ok(category);
        }

    }
}
