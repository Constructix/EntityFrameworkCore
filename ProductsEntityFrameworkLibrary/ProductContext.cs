using Microsoft.EntityFrameworkCore;

namespace ProductsEntityFrameworkLibrary;

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