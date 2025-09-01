using AutoMapper;
using OperacaoFlorestal.Data.DTOs.Coleta;
using OperacaoFlorestal.Models;

namespace OperacaoFlorestal.Profiles
{
    public class ColetaDadosProfile : Profile
    {
        public ColetaDadosProfile()
        {
            CreateMap<DadoBrutoVant, ReadColetaDadosDTO>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => "VANT"))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CaminhoArquivo, opt => opt.MapFrom(src => src.CaminhoArquivo))
                .ForMember(dest => dest.DataProcessamento, opt => opt.MapFrom(src => src.DataProcessamento));

            CreateMap<DadoBrutoMaquinario, ReadColetaDadosDTO>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => "MAQUINARIO"))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CaminhoArquivo, opt => opt.MapFrom(src => src.CaminhoArquivo))
                .ForMember(dest => dest.DataProcessamento, opt => opt.MapFrom(src => src.DataProcessamento));
        }
    }
}
