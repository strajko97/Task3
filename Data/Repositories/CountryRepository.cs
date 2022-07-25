using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private MyDbContext MyDataBaseContext;

        public CountryRepository(MyDbContext context)
        {
            MyDataBaseContext = context;
        }

        public async Task<IEnumerable<Country>> GetAllCountiesAsync()
        {
            return  await MyDataBaseContext.Countries.Include(t => t.Smss).ToListAsync(); //.Include(t => t.Smss).
        }
    }
}
