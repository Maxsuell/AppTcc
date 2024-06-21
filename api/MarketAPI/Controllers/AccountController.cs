using System.Linq;
using AutoMapper;
using MarketAPI.Data;
using MarketAPI.DTOs;
using MarketAPI.Entities;
using MarketAPI.Extensions;
using MarketAPI.ServicesSystem;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketAPI.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly UnitOfWork _unitOfWork;
        private readonly SignInManager<AppUser> _signInManager;
        
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;
        public AccountController(UserManager<AppUser> usertManager, SignInManager<AppUser> signInManager, IMapper mapper, TokenService tokenService, UnitOfWork unitOfWork)
        {
            
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _userManager = usertManager;
            _tokenService = tokenService;
            _mapper = mapper;
            
        }

        [HttpPost("registerUser")]
        public async Task<ActionResult<UserDtos>> Register(RegisterDtos registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Name.ToLower())) return BadRequest("Username is taken");

            var user = _mapper.Map<AppUser>(registerDto);
            
            user.UserName = registerDto.Name.ToLower();

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if(!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            if(!roleResult.Succeeded) return BadRequest(result.Errors);

            return new UserDtos
            {
                Username = user.UserName
            };
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDtos>> Login(LoginDtos loginDto)
        {
            var user = await _userManager.Users
            .SingleOrDefaultAsync(x => x.UserName == loginDto.UserName);


            if (user == null) return Unauthorized("Invalid username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(!result.Succeeded) return Unauthorized();

            return new UserDtos
            {
                Username = user.UserName,
                Token = await _tokenService.CreateUserToken(user),

            };
        }
        [Authorize]
        [HttpPost("RegisterClient")]
        public async Task<ActionResult> RegisterClient(ClientDtos clientDtos)
        {
            var username = User.GetUsername();

            var user = _userManager.FindByNameAsync(username);
    
            var client = new AppUserRoles
            {                
                UserId = user.Id,
                RoleId = user.Id,
                User = await user,            
                CNPJ =  clientDtos.CNPJ,
                Number = clientDtos.Number            
            };   
            var roles = "Client";
            var selectedRoles = roles.Split(",").ToArray();
            var userRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            if(!result.Succeeded) return BadRequest(result);

            _unitOfWork.clientRepository.AddClient(client);           

            if(await _unitOfWork.Complete())return Ok();
            return BadRequest("Problem saving changes");

            
        }

        [HttpGet("GetUser")]
        public async Task<IEnumerable<UserDtos>> GetCurrentUser()
        {
            return await  _unitOfWork.userRepository.GetUsers();
        }
    }
}