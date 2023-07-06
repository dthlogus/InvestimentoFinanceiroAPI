using API_Financeira.DTO;
using API_Financeira.Models;
using AutoMapper;

namespace API_Financeira.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<StockData, StockDTO>()
                .ForMember(dest => dest.PVP, opt => opt.MapFrom(src => src.RegularMarketPrice / src.BookValue))
                .ForMember(dest => dest.PV, opt => opt.MapFrom(src => 1 / src.PriceToBook))
                .ForMember(dest => dest.DY, opt => opt.MapFrom(src => src.TrailingAnnualDividendYield))
                .ForMember(dest => dest.VPA, opt => opt.MapFrom(src => src.BookValue))
                .ForMember(dest => dest.LPA, opt => opt.MapFrom(src => src.EpsTrailingTwelveMonths))
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.Symbol))
                .ForMember(dest => dest.LongName, opt => opt.MapFrom(src => src.LongName));

            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Perfil, opt => opt.MapFrom(src => src.Perfil));

            CreateMap<PerfilUsuarioDTO, PerfilUsuario>()
                .ForMember(dest => dest.pv, opt => opt.MapFrom(src => src.pv))
                .ForMember(dest => dest.pvp, opt => opt.MapFrom(src => src.pvp))
                .ForMember(dest => dest.dy, opt => opt.MapFrom(src => src.dy))
                .ForMember(dest => dest.vpa, opt => opt.MapFrom(src => src.vpa))
                .ForMember(dest => dest.lpa, opt => opt.MapFrom(src => src.lpa))
                .ForMember(dest => dest.simbolos, opt => opt.MapFrom(src => src.simbolos));

            CreateMap<PerfilUsuarioDTO, Usuario>()
                .ForPath(dest => dest.Perfil.pv, opt => opt.MapFrom(src => src.pv))
                .ForPath(dest => dest.Perfil.pvp, opt => opt.MapFrom(src => src.pvp))
                .ForPath(dest => dest.Perfil.dy, opt => opt.MapFrom(src => src.dy))
                .ForPath(dest => dest.Perfil.vpa, opt => opt.MapFrom(src => src.vpa))
                .ForPath(dest => dest.Perfil.lpa, opt => opt.MapFrom(src => src.lpa))
                .ForPath(dest => dest.Perfil.simbolos, opt => opt.MapFrom(src => src.simbolos));
        }

        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperConfig>();
            });

            return mapperConfig.CreateMapper();
        }
    }
}

