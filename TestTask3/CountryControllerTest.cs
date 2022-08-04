using AutoMapper;
using Core.DtoModels;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Web_API.Controllers;
using Web_API.Profiles;
namespace TestTask3
{
    public class CountryControllerTest
    { 
        private readonly CountryController _countryController;

        public CountryControllerTest()
        {
            var countryServiceMock = new Mock<ICountryService>();
            countryServiceMock.Setup(m => m.GetAllCountries()).ReturnsAsync(new List<Country>(){
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

            //var mapperMock = new Mock<IMapper>();
            //mapperMock.Setup(m=>m.Map<Country,CountryDto>
            //    (It.IsAny<Country>()))
            //    .Returns(new CountryDto());

            var mapperConfiguration = new MapperConfiguration(cfg=>cfg.AddProfile<SmsServiceProfiles>());
            var mapper = new Mapper(mapperConfiguration);

            //moram da instancija kontroler
            _countryController = new CountryController(countryServiceMock.Object, mapper);
            // CountryController countryController = new CountryController(countryServiceMock.Object, mapperMock.Object);
            //ako se testira ponasanje mapper onda ne treba njega da mokujem 
            //ako se ne testira ponasanje mappera onda treba da se mokuje to je ovo pod komenatrom 
        }


        [Fact]
        public async Task CountryController_GetAllCountries_MustReturnSameType()
        {
            //Arange
            //Act
            var result=await _countryController.GetAllCountries();

            //Assert
            Assert.IsType < ActionResult < IEnumerable < CountryDto >>> (result);
        }

        [Fact]
        public async Task CountryController_GetAllCountries_MustReturn3Countries()
        {
            //Arrange
            //Act
             var result = await _countryController.GetAllCountries();


            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CountryDto>>>(result);
            Assert.Equal(3,
                ((IEnumerable<CountryDto>)((OkObjectResult)actionResult.Result).Value).Count());

        }
    }
}