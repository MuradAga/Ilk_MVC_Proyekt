using AutoMapper;
using Ilk_MVC_Proyekt.Entites;

namespace Ilk_MVC_Proyekt.Models.Mapping
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<ProductAddDTO, Product>().ReverseMap();
        }
    }
}
