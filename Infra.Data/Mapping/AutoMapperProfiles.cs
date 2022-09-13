using AutoMapper;
using Domain.Entity;
using Domain.Model;
using Infra.Data.Model;

namespace Infra.Data.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Adm, AdmModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Client, ClientModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
        }
    }
}