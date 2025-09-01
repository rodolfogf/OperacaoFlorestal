using AutoMapper;
using OperacaoFlorestal.Data.DTOs.Maquinario;
using OperacaoFlorestal.Models;

namespace OperacaoFlorestal.Profiles
{
    public class MaquinarioProfile : Profile
    {
        public MaquinarioProfile()
        {
            CreateMap<CreateMaquinarioDTO, Maquinario>();
            CreateMap<UpdateMaquinarioDTO, Maquinario>();
            CreateMap<Maquinario, UpdateMaquinarioDTO>();
            CreateMap<Maquinario, ReadMaquinarioDTO>();
        }
    }
}
