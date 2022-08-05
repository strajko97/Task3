
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Sms
    {
        [Key]
        public int SmsId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }= DateTime.Now;
        public int Status { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
