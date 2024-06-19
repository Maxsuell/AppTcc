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
        
        public void AddUser(User user)
        {
            _context.User.Add(user);
        }

        

        public async Task<IEnumerable<UserDtos>> GetUsers()
        {
            return await _context.User.ProjectTo<UserDtos>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public IEnumerable<UserDtos> GetUserName(string name)
        {
            return  _context.User.ProjectTo<UserDtos>(_mapper.ConfigurationProvider).Where(us => us.NameUser == name);
        }

        public async Task<UserDtos> GetUserId(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(user => user.Id == id);

            var userMap = _mapper.Map<UserDtos>(user);

            

            return userMap;
        }

        public void DeleteUser(int Id)
        {
            var obj = _context.User.Find(Id);
            _context.User.Remove(obj);
            
        }
    
    }
}