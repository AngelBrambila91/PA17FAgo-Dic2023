using System.ComponentModel.DataAnnotations.Schema;

namespace WorkingWithEFCore;

public class Category
{
    // properties
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    [Column(TypeName = "ntext")]
    public string? Description { get; set; }
    // Navigation Property
    public virtual ICollection<Product> Products { get; set; }
    // SELECT * FROM Categories AS C
    // JOIN Products AS P ON P.CategoryId = C.CategoryId

    public Category ()
    {
        // Initialize ICollection of Products
        Products = new HashSet<Product>();
    }
}