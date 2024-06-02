using MarketAPI.DTOs;
using MarketAPI.Entities;
using AutoMapper;

namespace MarketAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {   
            CreateMap<User,UserDtos>();

            CreateMap<Client,ClientDtos>();

            CreateMap<Services,ServicesDtos>();

            CreateMap<Storage,StorageDtos>();               

            CreateMap<Produto,ProdutoDtos>();
                     
        }
    }
}