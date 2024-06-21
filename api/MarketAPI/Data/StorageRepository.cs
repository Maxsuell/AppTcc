using MarketAPI.Entities;
using MarketAPI.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MarketAPI.Data
{
    public class StorageRepository 
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public StorageRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public IEnumerable<Storage> GetStorageClient(string username)
        {

            return _context.Storage.Where(st => st.Client.User.UserName == username).Include(st => st.Produto);
         }

        public async Task<ActionResult<bool>> AddStorage(Storage storage)
        {            
            if(_context.Storage.Where(st => st.IdClient == storage.IdClient).FirstOrDefault() == null)
            {
                _context.Storage.Add(storage);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        
        public void AddStorageProduto(string name,Produto produto)
        {
            var st = _context.Storage.Where(st => st.Client.User.UserName == name).FirstOrDefault();
            st.Produto.Add(produto);
        }

        public void UpdateStorageProduto(Storage storage)
        {
            _context.Entry(storage).State = EntityState.Modified;
        }

        public void DeleteProduto(string name,Produto produto)
        {
            var prod =_context.Storage.Where(st => st.Client.User.UserName == name).FirstOrDefault();
            prod.Produto.Remove(produto);
        }
        public void DeleteStorage(int IdClient)
        {
            var st = _context.Storage.Where(st => st.IdClient == IdClient).FirstOrDefault();
            _context.Storage.Remove(st);
        }
    }
}