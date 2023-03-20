using AutoMapper;
using LanchoneteApi.Dtos;
using LanchoneteApi.Models;

namespace OlxApi.Profiles{

    public class ComandaProfile : Profile {
        public ComandaProfile()
        {
            CreateMap<CreateComandaDto, Comanda>();
            CreateMap<UpdateComandaDto, Comanda>();
            CreateMap<Comanda, UpdateComandaDto>();
             CreateMap<Comanda, ReadComandaDto>();
        }
    }
}