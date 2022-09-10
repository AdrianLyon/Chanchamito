using chachito.Api.Data;
using chachito.Api.Dto;
using Microsoft.EntityFrameworkCore;

namespace chachito.Api.Services
{
    public interface IUserService
    {
        Task<ICollection<UserDto>> GetAllAsync();
        Task<UserDto> GetAsync(int id);
        Task AddAsync(UserDto request);
        Task UpdateAsync(int id, UserDto request);
        Task DeleteAsync (int id);
    }
    public class UserService : IUserService
    {
        private readonly ChanchitoDbContext _db;
        public UserService(ChanchitoDbContext db)
        {
            _db = db;
        }

        public Task AddAsync(UserDto request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<UserDto>> GetAllAsync()
        {
            var baseQuery = await _db.Users.Where(x => x.Deleted == false).ToListAsync();
            
            var item = baseQuery.Select(x => new UserDto{
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                Phone = x.Phone
            }).ToList();

            return item;
        }

        public async Task<UserDto> GetAsync(int id)
        {
            var entity = await _db.Users.Where(x => x.Deleted == false && 
                                                    x.Id == id).FirstOrDefaultAsync();
            var item = new UserDto{
                FirstName = entity?.FirstName,
                LastName = entity?.LastName,
                Address = entity?.Address,
                Phone = entity?.Phone
            };

            return item;
        }

        public Task UpdateAsync(int id, UserDto request)
        {
            throw new NotImplementedException();
        }
    }
}