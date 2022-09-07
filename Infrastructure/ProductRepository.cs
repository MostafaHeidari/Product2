using Entities;

namespace Infrastructure;

public class ProductRepository
{
    //it is an Instance variable. the way to make instance variable write _productcContext
    private ProductDbContext _productContext;

    public object ServiceLifeTime { get; private set; }


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

    //Delete product method
    public Product DeleteProduct(int id)
    {
        //trying to find id with an Exception if error
        var product = _productContext.ProductTable.Find(id) ?? throw new KeyNotFoundException();
        //removes product
        _productContext.ProductTable.Remove(product);
        //saving the remove
        _productContext.SaveChanges();
        //returning the removed product
        return product;
    }



    //update product method
    public Product UpdateProduct(int id, Product product)
    {
        //trying to find id with an Exception if error
        var product2 = _productContext.ProductTable.Find(id) ?? throw new KeyNotFoundException();
        //update name
        product2.Name = product.Name;
        //update price
        product2.price = product.price;
        //update id
        //product2.Id = product.Id; //dont work
        //setting updates
        _productContext.ProductTable.Update(product2);
        //saving updates
        _productContext.SaveChanges();
        //returning updates
        return product2;
    }

    /*
    public Product DeleteProduct(int id)
    {
        using (var context = new ProductDbContext(_productContext, ServiceLifeTime.Scoped))
        {
            var obj = new Product { Id = id };
            context.Remove(obj);
            context.SaveChanges();
            return obj;
        }
    }
    */
    //we call some function that create that database.
    public void CreateDB()
    {
        // off curse if we have some data in the database should we delete first and create data after on.
        _productContext.Database.EnsureDeleted();
        _productContext.Database.EnsureCreated();

    }
}