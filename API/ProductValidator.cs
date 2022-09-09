using API.DTOs;
using Entities;
using FluentValidation;

namespace API;

// ProductValidater has to implement an interface

public class ProductValidator : AbstractValidator<PostProductDTO>
{
    //constructor 
    public ProductValidator()
    {
        //make some Rule
        RuleFor(p => p.price).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
    }
}