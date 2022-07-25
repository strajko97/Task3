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

        public async Task<IEnumerable<Sms>> GetSentSms()
        {
            return await _smsrepository.GetSentSmssAsync();
        }
    }
}
