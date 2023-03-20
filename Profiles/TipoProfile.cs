using AutoMapper;
using LanchoneteApi.Dtos;
using LanchoneteApi.Models;

namespace OlxApi.Profiles{

    public class TipoProfile : Profile {
        public TipoProfile()
        {
            CreateMap<CreateTipoDto, Tipo>();
            CreateMap<UpdateTipoDto, Tipo>();
            CreateMap<Tipo, UpdateTipoDto>();
             CreateMap<Tipo, ReadTipoDto>();
        }
    }
}