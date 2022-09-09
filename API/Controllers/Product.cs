using API.DTOs;
using AutoMapper;
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
    private IMapper _mapper;
    
    //constractor
    public ProductController(ProductRepository repository ,IMapper mapper)
    {
        _productRepository = repository;
        _productValidator = new ProductValidator();
        _mapper = mapper;
    }

    [HttpGet]
    public List<Product> GetProducts()
    {
        return _productRepository.GetAllProducts();
    }

    // we use to post endpoint to sende data to the server  
    [HttpPost]
    public ActionResult CreateNewProduct(PostProductDTO dto)
    {
        ProductValidator validator = new ProductValidator();
        var validation = _productValidator.Validate(dto);
        if (validation.IsValid)
        {
             // create a new product by using mapper.
            Product product = _mapper.Map<Product>(dto);
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



    //httpUpdate in postman
    [HttpPut]
    //the products id need be last http://localhost:4000/product/8 
    [Route("{id}")]
    //delete product using FromRoute to route id 
    public Product UpdateProduct([FromRoute] int id, [FromBody] Product product)
    {
        //return update Product id and product
        return _productRepository.UpdateProduct(id, product);
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