using AutoMapper;
using LanchoneteApi.Dtos;
using LanchoneteApi.Models;

namespace OlxApi.Profiles{

    public class GarcomProfile : Profile {
        public GarcomProfile()
        {
            CreateMap<CreateGarcomDto, Garcom>();
            CreateMap<UpdateGarcomDto, Garcom>();
            CreateMap<Garcom, UpdateGarcomDto>();
             CreateMap<Garcom, ReadGarcomDto>();
        }
    }
}