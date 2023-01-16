using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using ProductManagementApi.Model;
namespace ProductController;
using ProductManagementApi.DAL;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    

    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [EnableCors()]
    public IEnumerable<Product> GetAllProducts()
    {
        List<Product>products=ProductsDataAccess.GetAllProducts();
         return products;
    }
     
     [Route("{id}")]
    [HttpGet]
    [EnableCors()]
    public ActionResult<Product> GetOneProduct(int id)
    {
        Product products = ProductsDataAccess.GetProductById(id);
        return products;
    }

     [HttpPost]
    [EnableCors()]
    public IActionResult InsertNewProduct(Product product)
    {
        ProductsDataAccess.SaveNewProduct(product);
        return Ok(new { message = "Product created" });
    }
    

     [Route("{id}")]
    [HttpDelete]
    [EnableCors()]
    public ActionResult<Product> DeleteOneProduct(int id)
    {
        ProductsDataAccess.DeleteProductById(id);
        return Ok(new { message = "Product deleted" });
    }
}
