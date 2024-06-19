using Microsoft.AspNetCore.Mvc;
using MarketAPI.DTOs;
using MarketAPI.Entities;
using MarketAPI.Data;

namespace MarketAPI.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly UnitOfWork _unitOfWork;
        public UserController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       [HttpGet]
        public async Task<IEnumerable<UserDtos>> GetUsers()
        {
            return await  _unitOfWork.userRepository.GetUsers();
        }

        [HttpGet("UserName/{name}")]
        public IEnumerable<UserDtos> GetUserName(string name)
        {
            return _unitOfWork.userRepository.GetUserName(name);
        }

        [HttpGet("UserId/{id}")]
        public async Task<UserDtos> GetUserId(int id)
        {
            return await _unitOfWork.userRepository.GetUserId(id);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddUser(User user)
        {            
            _unitOfWork.userRepository.AddUser(user);
            return await _unitOfWork.Complete();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            _unitOfWork.userRepository.DeleteUser(id);
            if(await _unitOfWork.Complete()) return Ok();

            return BadRequest("Usuario não encontrado");
        }
    }
}