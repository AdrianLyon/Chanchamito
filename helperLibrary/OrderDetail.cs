
namespace helperLibrary;
public class OrderDetail
{
    public int Id { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public bool Deleted { get; set; }
    public DateTime? DeletedDate { get; set; }
    public virtual Order? Order { get; set; }
    public int ProductId { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}
