using AutoMapper;
using Core.DtoModels;
using Core.Models;

namespace Web_API.Profiles
{
    public class SmsServiceProfiles: Profile
    {
        //automaper radi po naming konvenciji
        public SmsServiceProfiles()
        {
            CreateMap<Sms,SmsDto>();
            //.ReverseMap();
            CreateMap<Country,CountryDto>();
            CreateMap<Sms,SmsForCountryDto>();
            CreateMap<Country,CountryForSmsDto>();
            //moze da se i mapira svaki properti pojedinacno!!!

        }

    }
}
