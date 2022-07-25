using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DtoModels
{
    public class CountryDto
    {
        //posto country korisnik nece moci da unosi nece mi biti potreban id i sve ostalo vec samo naziv i price
        //
        public string Name { get; set; }
        public decimal Price_Per_Sms { get; set; }

        //kada listam sve drzave hocu da vidim podatke samo za smsdto a to su id 
        public ICollection<SmsForCountryDto> Smss { get; set; }
    }
}
