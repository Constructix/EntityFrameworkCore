namespace ProductsEntityFrameworkLibrary;

public class ProductRepository
{
    public ProductContext Context { get; private set; }
    public ProductRepository(ProductContext context)
    {
        Context = context;
    }

    public IEnumerable<Product> GetAll() => Context.Products;

    public Product Add(Product newProduct)
    {
        Context.Products.Add(newProduct);
        Context.SaveChanges();

        return newProduct;
    }

    public Product Delete(int productId)
    {
        var product = Context.Products.FirstOrDefault(x => x.Id == productId);
        if (product != null)
            Context.Products.Remove(product);

        Context.SaveChanges();
        return product;
    }

    public void Save()
    {
        
    }
}