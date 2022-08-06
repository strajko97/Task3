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
        private readonly ISmsRepository _smsrepository;
        private readonly ICountryRepository _countryRepository;
        

        public SmsService(ISmsRepository smsrepository,ICountryRepository countryRepository)
        {
            _smsrepository = smsrepository;
            _countryRepository = countryRepository;
        }

        public async Task<IEnumerable<Sms>> GetSentSms(DateTime From,DateTime To)//bez parametara
        {
            // return await _smsrepository.GetSentSmssAsync();
            return await _smsrepository.GetSentSmssByDateAsync(From,To);
        }

        public async Task<IEnumerable<Sms>> GetSentSmsWithOutDate()
        {
            return await _smsrepository.GetSentSmssAsync();
        }

        public async Task<Sms> SendSms(Sms smsToSend)
        {
            return await _smsrepository.CreateSmsAsync(smsToSend);
        }

        public async Task<int> SettingCountryIdForSendSmsFromReciever(string toDecoded)
        {
            List<Country> countries = (List<Country>)await _countryRepository.GetAllCountiesAsync();
            int CountryCode = int.Parse(toDecoded.Trim().Substring(0,2));
            foreach(Country country in countries)
            {
                if (country.Country_Code == CountryCode)
                {
                    return country.CountryId;
                }
            }
            return 0;
            //mozda bolje da baca expception
        }

        public async Task<bool> validationFromToFormatAsync(string from, string to)
        {
            //(43,48,48) and 13 numbers
            
            if (from.Length == 13 && to.Length == 13) {
                List<Country> countries = (List<Country>)await _countryRepository.GetAllCountiesAsync();
                
                if (countries.Count == 0) return false;       
                foreach(Country c in countries)
                {
                    if(c.Country_Code.ToString().Equals(to.Substring(0, 2))){
                        foreach(Country c1 in countries)
                        {
                            if (c1.Country_Code.ToString().Equals(from.Substring(0, 2)))
                                return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}
