using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DtoModels
{
    public class SentSmssDto
    {
        public string SendTime { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Status { get; set; }
        public CountryForSentSmsDto Country { get; set; }
    }
}
