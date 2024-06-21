using MarketAPI.Entities;
using MarketAPI.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace MarketAPI.Data
{
    public class UserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public void AddUser(AppUser user)
        {
            _context.Users.Add(user);
        }



        public async Task<IEnumerable<UserDtos>> GetUsers()
        {
            return await _context.Users.ProjectTo<UserDtos>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public AppUser GetUserName(string name)
        {
            return  _context.Users.Where(us => us.UserName == name).Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefault();
        }

        public async Task<UserDtos> GetUserId(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);

            var userMap = _mapper.Map<UserDtos>(user);



            return userMap;
        }

        public void DeleteUser(int Id)
        {
            var obj = _context.Users.Find(Id);
            _context.Users.Remove(obj);

        }

    }
}