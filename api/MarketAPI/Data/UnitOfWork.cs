using AutoMapper;
using MarketAPI.Entities;

namespace MarketAPI.Data
{
    public class UnitOfWork
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public UserRepository userRepository => new UserRepository(_context, _mapper);

        public ClientRepository clientRepository => new ClientRepository(_context,_mapper);

        public StorageRepository storageRepository => new StorageRepository(_context,_mapper);

        public ServicesRepository servicesRepository => new ServicesRepository(_context,_mapper);



        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        
    }
}