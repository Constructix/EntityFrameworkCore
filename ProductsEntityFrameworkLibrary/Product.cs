using System.ComponentModel.DataAnnotations;

namespace ProductsEntityFrameworkLibrary;

public class Product
{

    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTimeOffset EffectiveFrom { get; set; }
    public DateTimeOffset? EffectiveTo { get; set; }
    public int unitPrice { get; set; } // store monetary value in Cents then divide by 100 for dollar amount.

}