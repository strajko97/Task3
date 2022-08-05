using AutoMapper;
using Core.DtoModels;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
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


        [HttpGet("sms/sent.{format}")]
        [FormatFilter]
        public async Task<ActionResult<IEnumerable<SentSmssDto>>> GetSentSmss([FromQuery] DateTime From, [FromQuery] DateTime To)
        {
            var SentSmss = await _smsService.GetSentSms(From, To);
            var SentSmsDto = _mapper.Map<List<SentSmssDto>>(SentSmss);
            return Ok(SentSmsDto);
        }

        //WithOutQueryString
        //[HttpGet("sms/sent.{format}/DateFrom={From}/DateTo={To}")]
        //[FormatFilter]
        //public async Task<ActionResult<IEnumerable<SentSmssDto>>> GetSentSmssWithOutDate2(DateTime From, DateTime To)
        //{
        //    var SentSmss = await _smsService.GetSentSms(From, To);
        //    var SentSmsDto = _mapper.Map<List<SentSmssDto>>(SentSmss);
        //    return Ok(SentSmsDto);
        //}

        //Ovu metodu sam testirao
        [HttpGet("smss/sent.{format}"), FormatFilter]
        public async Task<ActionResult<IEnumerable<SentSmssDto>>> GetSentSmssWithOutDate()
        {
            var SentSmss = await _smsService.GetSentSmsWithOutDate();
            var SentSmsDto = _mapper.Map<List<SentSmssDto>>(SentSmss);
            return Ok(SentSmsDto);
        }

        [HttpPost("sms/send.{format}")]
        [FormatFilter]
        public async Task<ActionResult<SendSmsDto>> SendSms([FromQuery] string From, [FromQuery] string To, [FromQuery] string Text)
        {
            string ToDecoded = WebUtility.UrlDecode(To).Trim();
            string FromDecoded = WebUtility.UrlDecode(From).Trim();
            if (await _smsService.validationFromToFormatAsync(FromDecoded,ToDecoded))
            {
                int smsCountryId = await _smsService.SettingCountryIdForSendSmsFromReciever(ToDecoded);
                Random random = new Random();
                Sms SmsToSend = new Sms()
                {
                    CountryId = smsCountryId,
                    Text = Text,
                    From = From,
                    To = ToDecoded,
                    Status = random.Next(0, 2)

                };
                await _smsService.SendSms(SmsToSend);
                var SendSmsDto = _mapper.Map<SendSmsDto>(SmsToSend);
                return Ok(SendSmsDto);
            }
            else return BadRequest("Nepravilan format mobilnih brojeva telefona");
        }
    }
}

