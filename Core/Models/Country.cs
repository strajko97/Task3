using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Models
{
    public class Country

    {
        // Country code []
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }
        public int Country_Code { get; set; }
        [Column(TypeName ="decimal(6,3)")]
        public decimal Price_Per_Sms { get; set; }
        public IEnumerable<Sms> Smss { get; set; }
    }
}
