using Microsoft.AspNetCore.Mvc;
using MarketAPI.DTOs;
using MarketAPI.Entities;
using MarketAPI.Data;

namespace MarketAPI.Controllers
{
    public class ClientController : BaseApiController    
    {
        private readonly UnitOfWork _unitOfWork;

        public ClientController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            
        }

        [HttpGet]
        public async Task<IEnumerable<ClientDtos>> GetClients()
        {
            return await _unitOfWork.clientRepository.GetClients();            
        }

        [HttpGet("clientname/{name}")]
        public IEnumerable<ClientDtos> GetClientByName(string name)
        {
            return _unitOfWork.clientRepository.GetClientByName(name);
        }

        [HttpGet("clientid/{id}")]
        public async Task<ClientDtos> GetClientId(int id)
        {
            return await _unitOfWork.clientRepository.GetClientId(id);            
        }

        [HttpPost]
        public async Task<bool> AddClient(Client client)
        {
            _unitOfWork.clientRepository.AddClient(client);
            return await _unitOfWork.Complete();
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteClient(int id)
        {
            _unitOfWork.clientRepository.DeleteClient(id);
            return await _unitOfWork.Complete();
        }


        
    }
}