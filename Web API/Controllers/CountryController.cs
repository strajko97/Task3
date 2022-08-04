using AutoMapper;
using Core.DtoModels;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
         private readonly ICountryService _countryService;
        //moram za automaper da dodam i u konstruktor
        private readonly IMapper _mapper;


        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet("countries.{format}"), FormatFilter] 
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetAllCountries()
        {
            var Countries=await _countryService.GetAllCountries();
            var CountriesDto = _mapper.Map<List<CountryDto>>(Countries);
            return Ok(CountriesDto); 
        }
    }
}
