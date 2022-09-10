using chachito.Api.Data;
using chachito.Api.Dto;
using helperLibrary;
using Microsoft.EntityFrameworkCore;

namespace chachito.Api.Services
{
    public interface IUserService
    {
        Task<ICollection<UserAllDto>> GetAllAsync();
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

        public async Task AddAsync(UserDto request)
        {
            var entity = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Address = request.Address
            };
            _db.Users.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entityDelete = await _db.Users.Where(x => x.Deleted == false &&
                                              x.Id == id).FirstOrDefaultAsync();
            entityDelete.Deleted = true;
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<UserAllDto>> GetAllAsync()
        {
            var baseQuery = await _db.Users.Where(x => x.Deleted == false).ToListAsync();
            
            var item = baseQuery.Select(x => new UserAllDto{
                Id = x.Id,
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

        public async Task UpdateAsync(int id, UserDto request)
        {
            var entityToUpdate = await _db.Users.Where(x => x.Deleted == false &&
                                                        x.Id == id).FirstOrDefaultAsync();
            entityToUpdate.FirstName = request.FirstName;
            entityToUpdate.LastName = request.LastName;
            entityToUpdate.Address = request.Address;
            entityToUpdate.Phone = request.Phone;

            await _db.SaveChangesAsync();
        }
    }
}