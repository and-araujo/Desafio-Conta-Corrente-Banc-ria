using AutoMapper;
using Banco.App.ViewModels;
using Banco.Business.Models;

namespace Banco.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ContaCorrente, ContaCorrenteViewModel>().ReverseMap();
            CreateMap<ContaCorrenteTransacao, ContaCorrenteTransacaoViewModel>().ReverseMap();
        }
    }
}
