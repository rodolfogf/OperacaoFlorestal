using AutoMapper;
using OperacaoFlorestal.Data.DTOs.VooVant;
using OperacaoFlorestal.Models;

namespace OperacaoFlorestal.Profiles
{
    public class VooVantProfile : Profile
    {
        public VooVantProfile()
        {
            CreateMap<CreateVooVantDTO, VooVant>();
            CreateMap<UpdateVooVantDTO, VooVant>();
            CreateMap<VooVant, UpdateVooVantDTO>();
            CreateMap<VooVant, ReadVooVantDTO>();
        }
    }
}
