using chachito.Api.Data;
using chachito.Api.Dto;
using Microsoft.EntityFrameworkCore;

namespace chachito.Api.Services
{
    public interface IUserService
    {
        Task<ICollection<UserDto>> GetAllAsync();
    }
    public class UserService : IUserService
    {
        private readonly ChanchitoDbContext _db;
        public UserService(ChanchitoDbContext db)
        {
            _db = db;
        }
        public async Task<ICollection<UserDto>> GetAllAsync()
        {
            var baseQuery = await _db.Users.ToListAsync();
            
            var item = baseQuery.Select(x => new UserDto{
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                Phone = x.Phone
            }).ToList();

            return item;
        }
    }
}