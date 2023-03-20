using AutoMapper;
using LanchoneteApi.Dtos;
using LanchoneteApi.Models;

namespace OlxApi.Profiles{

    public class ItemComandaProfile : Profile {
        public ItemComandaProfile()
        {
            CreateMap<CreateItemComandaDto, ItemComanda>();
            CreateMap<UpdateItemComandaDto, ItemComanda>();
            CreateMap<ItemComanda, UpdateItemComandaDto>();
             CreateMap<ItemComanda, ReadItemComandaDto>();
        }
    }
}