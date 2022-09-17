
namespace chachito.Api.Domain
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public int QuantityOrder { get; set; }
        public int OrderId { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public virtual Order? Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Products { get; set; }
    }
}
