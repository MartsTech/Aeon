using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Services;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> GetAll()
        {
            if (_productService.GetAllProducts().Count == 0)
            {
                return NotFound();
            }

            return Ok(_productService.GetAllProducts());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<ProductModel> GetById(int id)
        {
            ProductModel? product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public void Add([FromBody] ProductModel product)
        {
            _productService.AddProduct(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] ProductModel product)
        {
            return _productService.UpdateProduct(id, product) ? Ok() : NotFound();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _productService.DeleteProduct(id) ? Ok() : NotFound();
        }
    }
}
