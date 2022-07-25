using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICountryRepository
    {
       public Task<IEnumerable<Country>> GetAllCountiesAsync();
    }
}
