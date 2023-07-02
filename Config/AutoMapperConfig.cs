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
