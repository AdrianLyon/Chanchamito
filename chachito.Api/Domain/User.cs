namespace chachito.Api.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Address { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public bool Deleted { get; set; }
    }
}