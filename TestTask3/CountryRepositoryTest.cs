using Core.Models;
using Core.Repositories;
using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System.Linq;

namespace TestTask3
{
    public class CountryRepositoryTest
    {
        private readonly CountryRepository _countryRepository;

        public CountryRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
               .UseInMemoryDatabase(databaseName: "InMemoryDbFromExistingDb").Options;
            var myDbContext = new MyDbContext(options);
            myDbContext.Database.EnsureCreated();
            _countryRepository = new CountryRepository(myDbContext);
        }

        [Fact]
        public async Task CountryRepository_GetAllCountriesAsync_MustReturnTypeOfListCountry()
        {
            //Arange
            //Act
            var result = await _countryRepository.GetAllCountiesAsync();
            //Assert
            Assert.IsType<List<Country>>(result);
        }

        [Fact]
        public async Task CountryRepository_GetAllCountriesAsync_MustReturnCount3()
        {
            //Arange
            //Act
            var result = (List<Country>)await _countryRepository.GetAllCountiesAsync();
            //Assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task CountryRepository_GetAllCountriesAsync_MustReturnGermanyPolandAustria()
        {
            //Arange
            //Act
            List<Country> result = (List<Country>)await _countryRepository.GetAllCountiesAsync();
    
            //Assert
            Assert.Contains(result, x => x.Name == "Germany");
            Assert.Contains(result, x => x.Name == "Austria");
            Assert.Contains(result, x => x.Name == "Poland");
        }
    }
}
