using AutoMapper;
using LanchoneteApi.Dtos;
using LanchoneteApi.Models;

namespace OlxApi.Profiles{

    public class ProdutoProfile : Profile {
        public ProdutoProfile()
        {
            CreateMap<CreateProdutoDto, Produto>();
            CreateMap<UpdateProdutoDto, Produto>();
            CreateMap<Produto, UpdateProdutoDto>();
             CreateMap<Produto, ReadProdutoDto>();
        }
    }
}