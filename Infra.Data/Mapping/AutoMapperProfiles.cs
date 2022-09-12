using AutoMapper;
using Domain.Entiy;
using Infra.Data.Model;

namespace Infra.Data.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Adm, AdmModel>().ReverseMap();
        }
    }
}