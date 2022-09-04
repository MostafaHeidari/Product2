using Entities;

namespace Infrastructure;

public class ProductRepository
{
    //it is an Instance variable. the way to make instance variable write _productcContext
    private ProductDbContext _productContext;

    //constractor
    public ProductRepository(ProductDbContext context)
    { 
        //this a normal denependeices injection 
        _productContext = context;
    }

    // we make this function to make a list of product. list of quarries
    public List<Product> GetAllProducts()
    {
        // this ToList() is like to select alle statement that convert them to a list of entity product.
        // this like to fetch all product
        return _productContext.ProductTable.ToList();
    }

    public Product InsertProduct(Product product)
    {
        _productContext.ProductTable.Add(product);
        _productContext.SaveChanges();
        return product;
    }

    //we call some function that create that database.
    public void CreateDB()
    {
        // off curse if we have some data in the database should we delete first and create data after on.
        _productContext.Database.EnsureDeleted();
        _productContext.Database.EnsureCreated();

    }
}