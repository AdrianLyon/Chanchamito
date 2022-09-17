using System.Collections.Generic;

namespace chachito.Api.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool Deleted { get; set; }
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory? ProductCategory { get; set; }
    }
}
