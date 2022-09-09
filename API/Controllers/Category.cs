using API.DTOs;
using AutoMapper;
using Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[Controller]")]
public class CategoryController : ControllerBase
{
    //instance variable
    private ProductRepository _productRepository;
    private ProductValidator _productValidator;
    private IMapper _mapper;

    //constracter
    public CategoryController(ProductRepository repository, IMapper mapper)
    {
        _productRepository = repository;
        _productValidator = new ProductValidator();
        _mapper = mapper;
    }

    [HttpGet]
    public List<Category> GetCategorys()
    {
        return _productRepository.GetAllCategorys();
    }
}


