using AutoMapper;
using Core.DtoModels;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmssController : ControllerBase
    {
        private readonly ISmsService _smsService;
        private readonly IMapper _mapper;

        public SmssController(ISmsService smsService, IMapper mapper)
        {
            _smsService = smsService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Sms>>> GetSentSmss()
        {
            var SentSmss = await _smsService.GetSentSms();
            var SentSmssDto = _mapper.Map <List<SmsDto>> (SentSmss);
            return Ok(SentSmssDto);
        }

       // [HttpPost("")]
       // public 
    }
}
