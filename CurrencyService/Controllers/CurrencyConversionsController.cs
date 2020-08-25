using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyService.Controllers.Models;
using CurrencyService.Services;
using CurrencyService.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyService.Controllers
{
    [ApiVersion("1.0")]
    [Route("[controller]")]
    [ApiController]
    public class CurrencyConversionsController : ControllerBase
    {
        private readonly ICurrencyConversionService _currencyConversionService;
        private readonly IMapper _mapper;

        public CurrencyConversionsController(ICurrencyConversionService currencyConversionService, IMapper mapper)
        {
            _currencyConversionService = currencyConversionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CurrencyConversionResponse>> Get([FromQuery]CurrencyConversionRequest currencyConversionRequest)
        {
            var currencyConversion = _mapper.Map<CurrencyConversion>(currencyConversionRequest);

            currencyConversion = await _currencyConversionService.Convert(currencyConversion);

            return Ok(_mapper.Map<CurrencyConversionResponse>(currencyConversion));
        }
    }
}
