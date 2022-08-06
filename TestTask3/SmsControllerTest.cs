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
    public class SmsControllerTest
    {
        private readonly SmssController _smssController;

        public SmsControllerTest()
        {
            var smsServiceMock = new Mock<ISmsService>();
            smsServiceMock.Setup(s => s.GetSentSmsWithOutDate()).ReturnsAsync(new List<Sms>()
            {
                new Sms()
                {
                    Status=1,
                    From="4312345678901",
                    To="4910987654321",
                    Text="Posalji kod",
                    SendTime=new DateTime(2022,07,01),
                    CountryId=262
                },
                new Sms()
                {
                    Status=1,
                    From="4910987654321",
                    To="4312345678901",
                    Text="Stize kod",
                    SendTime=new DateTime(2022,08,05),
                    CountryId=232
                },
                 new Sms()
                {
                    Status=1,
                    From="4312345678901",
                    To="4910987654321",
                    Text="Posalji kod",
                    SendTime=new DateTime(2022,07,01),
                    CountryId=262
                }
            });



            smsServiceMock.Setup(s => s.GetSentSms(new DateTime(2022, 07, 01), new DateTime(2023, 07, 01))).ReturnsAsync(new List<Sms>()
            {
                new Sms()
                {
                    Status=1,
                    From="4312345678901",
                    To="4910987654321",
                    Text="Posalji kod",
                    SendTime=new DateTime(2022,07,01),
                    CountryId=262
                },
                new Sms()
                {
                    Status=1,
                    From="4910987654321",
                    To="4312345678901",
                    Text="Stize kod",
                    SendTime=new DateTime(2022,08,05),
                    CountryId=232
                },
                 new Sms()
                {
                    Status=1,
                    From="4312345678901",
                    To="4910987654321",
                    Text="Posalji kod",
                    SendTime=new DateTime(2022,07,01),
                    CountryId=262
                }
            });


            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<SmsServiceProfiles>());
            var mapper = new Mapper(mapperConfiguration);
            _smssController = new SmssController(smsServiceMock.Object, mapper);
        }

        [Fact]
        public async Task SmssController_GetSentSmssWithOutDate_ReturnTypeActionResultEnumerableSmsDto()
        {
            //Arange
            //Act
            var result = await _smssController.GetSentSmssWithOutDate();


            //Assert
            Assert.IsType<ActionResult<IEnumerable<SentSmssDto>>>(result);
        }

        [Fact]
        public async Task SmssController_GetSentSmssWithoutDate_Return2SentSmssDto()
        {
            //Arrange
            //Act
            var result = await _smssController.GetSentSmssWithOutDate();

            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<SentSmssDto>>>(result);
            Assert.Equal(3,
                ((IEnumerable<SentSmssDto>)((OkObjectResult)actionResult.Result).Value).Count());
        }

        [Fact]
        public async Task SmssController_GetSentSmss_ReturnTypeActionResultEnumerableSmsDto()
        {
            //Arange

            //Act
            var result = await _smssController.GetSentSms(new DateTime(2022, 07, 1), new DateTime(2022, 08, 1));
            //Assert
            Assert.IsType<ActionResult<IEnumerable<SentSmssDto>>>(result);
        }

        //[Fact]
        //public async Task SmssController_GetSentSmss_ReturnCountMustBe3()
        //{
        //    //Arange

        //    //Act
        //    var result = await _smssController.GetSentSms(new DateTime(2022,07,01), new DateTime(2023,01,01));
        //    //Assert
        //    var actionResult = Assert.IsType<ActionResult<IEnumerable<SentSmssDto>>>(result);
        //    var smss = (IEnumerable<SentSmssDto>)((OkObjectResult)actionResult.Result).Value;
        //    Assert.Equal(3,
        //        ((IEnumerable<SentSmssDto>)((OkObjectResult)actionResult.Result).Value).Count());

        //}

    }
}
