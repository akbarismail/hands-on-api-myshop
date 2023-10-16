using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShopApi.Entities;

[Table("t_purchase")]
public class Purchase
{
    [Key, Column("id")]
    public Guid Id { get; set; }
    
    [Column("trans_date")]
    public DateTime TransDate { get; set; }
    
    [Column("customer_id")]
    public Guid CustomerId { get; set; }
    
    public virtual Customer? Customer { get; set; }
    public virtual ICollection<PurchaseDetail>? PurchaseDetails { get; set; }
}