using AutoMapper;
using Core.DtoModels;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("sms/sent.{format}/{From}&{To}"),FormatFilter]
       
        public async Task<ActionResult<IEnumerable<SentSmssDto>>> GetSentSmss(DateTime From, DateTime To)
        {
            var SentSmss = await _smsService.GetSentSms(From,To);
           var SentSmsDto = _mapper.Map<List<SentSmssDto>>(SentSmss);
          return Ok(SentSmsDto);
       
        }

        [HttpGet("sms/sent.{format}"), FormatFilter]
        public async Task<ActionResult<IEnumerable<SentSmssDto>>> GetSentSmssWithOutDate()
        {
            var SentSmss = await _smsService.GetSentSmsWithOutDate();
            var SentSmsDto = _mapper.Map<List<SentSmssDto>>(SentSmss);
            return Ok(SentSmsDto);
        }
    }
}

