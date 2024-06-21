using AutoMapper;
using AutoMapper.QueryableExtensions;
using MarketAPI.Data;
using MarketAPI.DTOs;
using MarketAPI.Entities;
using MarketAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarketAPI.Controllers
{
    [Authorize(Policy = "Client")]
    public class StorageController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        public StorageController(UnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [HttpPost("Add")]
        public async Task<ActionResult<string>> AddStorage(StorageDtos storage)
        {            
            var storageEntity = _mapper.Map<Storage>(storage);
            
            try{
                await _unitOfWork.storageRepository.AddStorage(storageEntity);

                if(await _unitOfWork.Complete())
                {
                    return Ok("Storage added");
                }
                else
                    {
                        return BadRequest("Storage not added");
                    }       
            
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
                    
        }
        [HttpGet()]
        public IEnumerable<Storage> GetStorageClient()
        {
            var name = User.GetUsername();
            return _unitOfWork.storageRepository.GetStorageClient(name);
              
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteStorage()
        {
            var name = User.GetUsername();
            var storage = _unitOfWork.storageRepository.GetStorageClient(name).FirstOrDefault();
            if(storage == null)
            {
                return BadRequest("Storage not found");
            }
            _unitOfWork.storageRepository.DeleteStorage(storage.IdClient);
            if (await _unitOfWork.Complete())
            {
                return Ok("Storage deleted");
            }
            else
            {
                return BadRequest("Storage not deleted");
            }
        }

        

    }
}