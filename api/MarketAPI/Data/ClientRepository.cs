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
        
        public void AddClient(Client client)
        {
            _context.Client.Add(client);
        }

        

        public async Task<IEnumerable<ClientDtos>> GetClients()
        {
            return await _context.Client.ProjectTo<ClientDtos>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public IEnumerable<ClientDtos> GetClientByName(string name)
        {
            return  _context.Client.ProjectTo<ClientDtos>(_mapper.ConfigurationProvider).Where(cl => cl.Name == name);
        }

        public async Task<ClientDtos> GetClientId(int id)
        {
            var client = await _context.Client.FirstOrDefaultAsync(client => client.Id == id);

            var clientMap = _mapper.Map<ClientDtos>(client);

            return clientMap;
        }

        public void DeleteClient(int Id)
        {
            var obj = _context.Client.Find(Id);
            _context.Client.Remove(obj);
            
        }
    
    }
}