using Core.Models;
using Core.Repositories;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class SmsService : ISmsService
    {
        private ISmsRepository _smsrepository;

        public SmsService(ISmsRepository smsrepository)
        {
            _smsrepository = smsrepository;
        }

        public async Task<IEnumerable<Sms>> GetSentSms(DateTime From,DateTime To)//bez parametara
        {
            // return await _smsrepository.GetSentSmssAsync();
            List<Sms> Smss = (List<Sms>)_smsrepository.GetSentSmssAsync().Result;

            foreach (Sms sms in Smss)
            {
                if (sms.SendTime<=From || sms.SendTime>=To)
                {
                    Smss.Remove(sms);
                }
            }
            return Smss;
        }

        public async Task<IEnumerable<Sms>> GetSentSmsWithOutDate()
        {
            return await _smsrepository.GetSentSmssAsync();
        }
    }
}
