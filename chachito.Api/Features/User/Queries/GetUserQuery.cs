using chachito.Api.Infrastructure.Persistence;
using MediatR;

namespace chachito.Api.Features.User.Queries
{
    public class GetUserQuery : IRequest<GetUserQueryResponse>
    {
        public int UserId { get; set; }
    }



    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryResponse>
    {
        private readonly ChanchitoDbContext _context;

        public GetUserQueryHandler(ChanchitoDbContext context)
        {
            _context = context;
        }
        public async Task<GetUserQueryResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.UserId);

            return new GetUserQueryResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }

    public class GetUserQueryResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}