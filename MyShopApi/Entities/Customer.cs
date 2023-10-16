using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShopApi.Entities;

[Table("m_customer")]
public class Customer
{
    [Key, Column(name: "id")]
    public Guid Id { get; set; }
    
    [Required]
    [Column(name: "customer_name", TypeName = "NVarchar(50)")]
    public string? CustomerName { get; set; }
    
    [Required]
    [Column(name: "address", TypeName = "NVarchar(250)")]
    public string? Address { get; set; }
    
    [Required]
    [Column(name: "mobile_phone", TypeName = "NVarchar(14)")]
    public string? MobilePhone { get; set; }
    
    [Required]
    [Column(name: "email", TypeName = "NVarchar(50)")]
    public string? Email { get; set; }
    
}