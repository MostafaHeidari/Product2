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
    
    //constractor
    public ProductController(ProductRepository repository)
    {
        _productRepository = repository;
    }

    [HttpGet]
    public List<Product> GetProducts()
    {
        return _productRepository.GetAllProducts();
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