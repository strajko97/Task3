using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DtoModels
{
   public class SmsDto
    {
        //kada izlistavam samo sms gde ne zelim podatke o drzavi, tako da ce prikazivati sve osim podatke za drzavu
        public int SmsId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }
        public int Status { get; set; }
       // public int CountryId { get; set; }
        public CountryForSmsDto Country{get;set;}
    }
}
