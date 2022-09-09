using System;
namespace API.DTOs
{
    public class PostCategoryDTO
    {
        // we dont need Id. becuase Id what we want from clint , we want to create a new product.
        public string krimi { get; set; }
        public string romantic { get; set; }
        public string action { get; set; }
        public int numbersOfCategory { get; set; }
    }
}

