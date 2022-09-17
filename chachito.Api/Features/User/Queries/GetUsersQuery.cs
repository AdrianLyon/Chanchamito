using chachito.Api.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace chachito.Api.Features.User.Queries
{
    public class GetUsersQuery : IRequest<List<GetUsersQueryResponse>>
    {
        
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<GetUsersQueryResponse>>
    {
        private readonly ChanchitoDbContext _context;
        public GetUsersQueryHandler(ChanchitoDbContext context)
        {
            _context = context;
        }

        public Task<List<GetUsersQueryResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken) =>
            _context.Users
                .AsNoTracking()
                .Select(x => new GetUsersQueryResponse{
                    UserId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).ToListAsync();
    }


    public class GetUsersQueryResponse
    {
        public int UserId{get; set;}
        public string FirstName{get; set;} = default!;
        public string LastName{get; set;} = default!;
    }
}