using MarketAPI.DTOs;
using MarketAPI.Entities;
using AutoMapper;

namespace MarketAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {   
            CreateMap<AppUser,UserDtos>();
            CreateMap<AppUser,RegisterDtos>();
            CreateMap<RegisterDtos,AppUser>();
            

            CreateMap<AppUserRoles,ClientDtos>();
            CreateMap<ClientDtos,AppUserRoles>();

            CreateMap<Services,ServicesDtos>();

            CreateMap<Storage,StorageDtos>();               
            CreateMap<StorageDtos,Storage>();               
            CreateMap<Produto,ProdutoDtos>();
                     
        }
    }
}