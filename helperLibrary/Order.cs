namespace helperLibrary;
public class Order
    {
        public int Id { get; set; }
        public string? OrdenName { get; set; }
        public string? OrdenAddress { get; set; }
        public DateTime? DateOrder { get; set; }
        public DateTime? DateSend { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set;}
    }
