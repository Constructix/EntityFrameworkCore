using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using ProductsEntityFrameworkLibrary;


var path = $@"{Environment.CurrentDirectory}\Products.db";
using var context = new ProductContext(new DbContextOptionsBuilder<ProductContext>().UseSqlite(@$"Data Source={path}"));
var repo = new ProductRepository(context);

var newProduct = new Product()
{
    Name = "90x19 Merbau",
    Description = "Fencing",
    unitPrice = 959,
    EffectiveFrom = DateTimeOffset.Parse("01/01/2022")
};
var product = repo.GetAll().FirstOrDefault(product => product.Name.Equals(newProduct.Name));

if(product == null)
{
    repo.Add(newProduct);
}




PrintProducts(repo.GetAll());

Console.WriteLine("About to Delete 110x90 Pine Post");
Console.ReadLine();


var productToDelete = repo.GetAll().FirstOrDefault(x=>x.Name.Equals("110 x 90 Pine post")).Id;

if (productToDelete != 0)
    repo.Delete(productToDelete);
else
{
    Console.WriteLine("Product does not exist.");
}

PrintProducts(repo.GetAll());

void PrintProducts(IEnumerable<Product> products)
{
    Console.WriteLine("--------- PRINTING OUT PRODUCTS ----------------");
    Console.WriteLine($"{"Id",-10}{"Name",-30}{"Unit Price",15}");
    foreach (var currentProduct in products)
    {
        Console.WriteLine($"{currentProduct.Id,-10}{currentProduct.Name,-30}{currentProduct.unitPrice / 100,15:C}");
    }

    Console.WriteLine($"{new String('-', 80)}");
    Console.WriteLine($"{"Total",40}{products.Sum(products => products.unitPrice / 100),15:C}");
}

