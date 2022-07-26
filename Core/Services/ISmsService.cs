﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ISmsService
    {
        Task<IEnumerable<Sms>> GetSentSms(DateTime From,DateTime To);
        Task <IEnumerable<Sms>> GetSentSmsWithOutDate();
        Task<int> SettingCountryIdForSendSmsFromReciever(string toDecoded);
        Task<Sms> SendSms(Sms smsToSend);
        Task<bool> validationFromToFormatAsync(string from, string to);
    }
}
