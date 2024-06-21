using MarketAPI.Entities;
using MarketAPI.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;


namespace MarketAPI.Data
{
    public class ClientRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ClientRepository(DataContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public void AddClient(AppUserRoles client)
        {
            _context.UserRoles.Add(client);
               
        }

        public async Task<IEnumerable<ClientDtos>> GetClients()
        {
            return await _context.UserRoles.ProjectTo<ClientDtos>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public IEnumerable<ClientDtos> GetClientByName(string name)
        {
            return  _context.UserRoles.ProjectTo<ClientDtos>(_mapper.ConfigurationProvider).Where(cl => cl.UserName == name);
        }

        public void DeleteClient(AppUserRoles UserRole)
        {
            _context.UserRoles.Remove(UserRole);
        }

    }
}