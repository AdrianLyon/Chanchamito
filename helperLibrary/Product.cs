using System.Collections.Generic;

namespace helperLibrary;
public class Product
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public bool Deleted { get; set; }
    public int ProductTypeId { get; set; }
    public virtual ICollection<ProductCategory>? ProductTypes { get; set; }
}
