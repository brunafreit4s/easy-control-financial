using AutoMapper;
using EasyControl.Api.Contract.NaturezaLancamento;
using EasyControl.Api.Domain.Models;

namespace EasyControl.Api.AutoMapper
{
    public class NaturezaDeLancamentoProfile : Profile
    {
        public NaturezaDeLancamentoProfile()
        {
            CreateMap<NaturezaDeLancamento, NaturezaDeLancamentoRequestContract>().ReverseMap();
            CreateMap<NaturezaDeLancamento, NaturezaDeLancamentoResponseContract>().ReverseMap();
        }    
    }
}