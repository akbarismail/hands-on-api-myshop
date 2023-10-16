using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShopApi.Entities;

[Table("m_product")]
public class Product
{
    [Key, Column("id")]
    public Guid Id { get; set; }
    
    [Required]
    [Column("product_name", TypeName = "NVarchar(50)")]
    public string? ProductName { get; set; }
    
    [Required]
    [Column("product_price")]
    public long ProductPrice { get; set; }
    
    [Required]
    [Column("stock")]
    public int Stock { get; set; }
}