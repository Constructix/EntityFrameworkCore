using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;

//var options = new DbContextOptionsBuilder<ProductContext>()
//                    //.UseInMemoryDatabase("Products")
//                    //.UseSqlServer($@"Data Source=(localdb)\ProjectsV13;Initial Catalog=Products;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
//                    .UseSqlite(@$"Data Source=D:\Databases\SqlLite\Products.db")
//                    .Options;
var path = $@"{Environment.CurrentDirectory}\Products.db";
using var context = new ProductContext(new DbContextOptionsBuilder<ProductContext>().UseSqlite(@$"Data Source={path}"));

var newProduct = new Product()
{
    Name = "100x15 H3 Pine Paling",
    Description = "Fencing",
    unitPrice = 155,
    EffectiveFrom = DateTimeOffset.Parse("01/01/2022")
};
var product = context.Products.FirstOrDefault(product => product.Name.Equals(newProduct.Name));

if(product == null)
{
    context.Products.Add(newProduct);
}
context.SaveChanges();


Console.WriteLine("--------- PRINTING OUT PRODUCTS ----------------");

Console.WriteLine($"{"Id",-10}{"Name",-30}{"Unit Price", 15}");
foreach (var currentProduct in context.Products)
{
    Console.WriteLine($"{currentProduct.Id,-10}{currentProduct.Name, -30}{currentProduct.unitPrice /100,15:C}");
}
Console.WriteLine($"{new String('-', 80)}");
Console.WriteLine($"{"Total",40}{context.Products.Sum(products=>products.unitPrice/100),15:C}");