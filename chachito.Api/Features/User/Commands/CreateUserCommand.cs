
using chachito.Api.Infrastructure.Persistence;
using chachito.Api.Domain;
using MediatR;

namespace chachito.Api.Features.User.Commands
{
    public class CreateUserCommand : IRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Address { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public bool Deleted { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly ChanchitoDbContext _context;

        public CreateUserCommandHandler(ChanchitoDbContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new chachito.Api.Domain.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Phone = request.Phone,
                Deleted = request.Deleted
            };

            _context.Users.Add(newUser);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}