using System.ComponentModel.DataAnnotations;// Required, StringLenght
using System.ComponentModel.DataAnnotations.Schema; //Column TypeName
namespace WorkingWithEFCore;
public class Product
{
    public int ProductId { get; set; }
    [Required]
    [StringLength(40)]
    public string? ProductName { get; set; }
    [StringLength(20)]
    [Column("QuantityPerUnit")]
    public string? Quantity { get; set; }
    [Column("UnitPrice", TypeName = "money")]
    public decimal? Cost { get; set; }
    [Column("UnitsInStock")]
    public short Stock { get; set; }
    public bool Discontinued { get; set; }

    // Navigation Properties
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
}