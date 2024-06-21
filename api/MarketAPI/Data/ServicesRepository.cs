using MarketAPI.Entities;
using MarketAPI.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace MarketAPI.Data
{
    public class ServicesRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ServicesRepository(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServicesDtos>> GetServicesClient(string nameClient)
        {
            return await  _context.Services.ProjectTo<ServicesDtos>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IEnumerable<ServicesDtos>> GetServicesClientById(int id)
        {
            return await  _context.Services.ProjectTo<ServicesDtos>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public void AddServices(Services service)
        {
            _context.Services.Add(service);
        }

        public void DeleteServices(int id)
        {
            var obj = _context.Services.Find(id);
            _context.Services.Remove(obj);
        }
    }
}