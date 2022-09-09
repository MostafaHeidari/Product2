namespace API.DTOs;

public class PostProductDTO
{
    // we dont need Id. becuase Id what we want from clint , we want to create a new product.
    public string Name { get; set; }
    public int price { get; set; }
    
}