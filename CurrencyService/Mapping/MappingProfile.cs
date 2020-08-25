using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyService.Controllers.Models;
using CurrencyService.Services.Models;

namespace CurrencyService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CurrencyConversionRequest, CurrencyConversion>()
                .ForMember(dst => dst.InputCurrency,
                    m => m.MapFrom(src => Enum.Parse(typeof(Currency), src.InputCurrency)))
                .ForMember(dst => dst.OutputCurrency,
                    m => m.MapFrom(src => Enum.Parse(typeof(Currency), src.OutputCurrency)));
            CreateMap<CurrencyConversion, CurrencyConversionResponse>()
                .ForMember(dst => dst.InputCurrency,
                    m => m.MapFrom(src => src.InputCurrency.ToString()))
                .ForMember(dst => dst.OutputCurrency,
                    m => m.MapFrom(src => src.OutputCurrency.ToString()));
        }
    }
}
