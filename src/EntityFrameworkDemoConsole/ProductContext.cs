using Microsoft.EntityFrameworkCore;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductContext()
    {
       
    }
    public ProductContext(DbContextOptionsBuilder optionsBuilder): base(optionsBuilder.Options)
    {
        this.Database.EnsureCreated(); 
        this.OnConfiguring(optionsBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       base.OnConfiguring(optionsBuilder);
        //optionsBuilder.UseSqlite(@$"Data Source=D:\Databases\SqlLite\Products.db");
        
    }
}


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
}