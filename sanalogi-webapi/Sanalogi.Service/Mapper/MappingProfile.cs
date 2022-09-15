using AutoMapper;
using Sanalogi.Data.Dto;
using Sanalogi.Data.Models;

namespace Sanalogi.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Siparis, SiparisDto>().ReverseMap();
            CreateMap<Siparis, SiparisDetailDto>().ReverseMap();
        }
    }
}
