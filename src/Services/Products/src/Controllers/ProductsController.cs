using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Products.Models;
using Products.Services;

namespace Products.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [RequiredScope("User.Scope")]
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
            List<ProductModel> products = _productService.GetAllProducts();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
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
