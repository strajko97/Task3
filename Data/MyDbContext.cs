using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class MyDbContext:DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Sms> Smss { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.

            LinkedList <Country> countries = new LinkedList<Country>();

            Country country1 = new Country
            {
                CountryId = 262,
                Country_Code = 49,
                Name = "Germany",
                Price_Per_Sms = 0.055M
            };
            Country country2 = new Country
            {
                CountryId = 232,
                Country_Code = 43,
                Name = "Austria",
                Price_Per_Sms = 0.053M
            };
            Country country3 = new Country
            {
                CountryId = 260,
                Country_Code = 48,
                Name = "Poland",
                Price_Per_Sms = 0.032M,
            };

            countries.AddFirst(country1);
            countries.AddFirst(country2);
            countries.AddFirst(country3);

            modelBuilder.Entity<Country>().HasData(countries);

            //Finalna izmena linija 54
            LinkedList<Sms> smss = new LinkedList<Sms>();
            Sms sms1 = new Sms { SendTime = DateTime.Now, CountryId = 262, From = "straja", To = "tea", SmsId = 1, Text = "dsadsa", Status=1 };
            Sms sms2 = new Sms { SendTime = DateTime.Now, CountryId = 232, From = "straja", To = "tea", SmsId = 2, Text = "dahhahaha", Status = 0 };
            smss.AddFirst(sms1);
            smss.AddFirst(sms2);
            modelBuilder.Entity<Sms>().HasData(smss);

        }
    }


}
