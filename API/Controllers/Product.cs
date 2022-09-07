using Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[Controller]")]
public class ProductController : ControllerBase
{
    //instance variable
    private ProductRepository _productRepository;
    private ProductValidator _productValidator;
    
    //constractor
    public ProductController(ProductRepository repository)
    {
        _productRepository = repository;
        _productValidator = new ProductValidator();
    }

    [HttpGet]
    public List<Product> GetProducts()
    {
        return _productRepository.GetAllProducts();
    }

    // we use to post endpoint to sende data to the server  
    [HttpPost]
    public ActionResult CreateNewProduct(Product product)
    {
        
        var validation = _productValidator.Validate(product);
        if (validation.IsValid)
        {
            return Ok(_productRepository.InsertProduct(product));
        }

        return BadRequest(validation.ToString());

    }

    //httpDelete in postman
    [HttpDelete]
    //the products id need be last http://localhost:4000/product/8 
    [Route("{id}")]
    //delete product using FromRoute to route id 
    public Product DeleteProduct([FromRoute]int id)
    {
        //return delete Product id
        return _productRepository.DeleteProduct(id);
    }
    
    
    //make an endpoint her to ensure created function in repository.
    [HttpGet]
    [Route("createDB")]
    public string CreateDB()
    {
        _productRepository.CreateDB();
        return "Db has been created";
    } 
}