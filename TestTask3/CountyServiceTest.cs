using Core.Models;
using Core.Repositories;
using Moq;
using Services.Services;

namespace TestTask3
{
    public class CountyServiceTest
    {
        private readonly CountryService _countryService;

        public CountyServiceTest()
        {
            var countryRepositoryMock = new Mock<ICountryRepository>();
            countryRepositoryMock.Setup(m => m.GetAllCountiesAsync()).ReturnsAsync(new List<Country>(){
                new Country(){
                    CountryId = 262,
                    Country_Code = 49,
                    Name = "Germany",
                    Price_Per_Sms = 0.055M
                },
                new Country(){
                    CountryId = 232,
                    Country_Code = 48,
                    Name = "Polad",
                    Price_Per_Sms = 0.055M

                },
                new Country(){
                    CountryId = 252,
                    Country_Code = 46,
                    Name = "Serbia",
                    Price_Per_Sms = 0.055M
                }
            });
            _countryService = new CountryService(countryRepositoryMock.Object);
        }

        [Fact]
        public async Task CountryService_GetAllCountries_MustReturnTypeIEnumerableCountry()
        {
            //Arange
            //Act
            var result = await _countryService.GetAllCountries();
            //Assert
            //
            // var actionResult = Assert.IsType<ActionResult<IEnumerable<CountryDto>>>(result);
            // Assert.Equal(3,
            //  ((IEnumerable<CountryDto>)((OkObjectResult)actionResult.Result).Value).Count());

            Assert.IsType<List<Country>>(result);
        }

        [Fact]
        public async Task CountryService_GetAllCountries_MustReturnCount3()
        {
            //Arange
            //Act
            var result = await _countryService.GetAllCountries();

            //Assert
            var actionResult = Assert.IsType<List<Country>>(result);
            Assert.Equal(3, actionResult.Count());
        }

    }
}
