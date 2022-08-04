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
                    From="vule",
                    To="straja",
                    Text="Posalji kod",
                    SendTime=DateTime.Now,
                    CountryId=262
                },
                new Sms()
                {
                    Status=1,
                    From="straja",
                    To="vule",
                    Text="Stize kod",
                    SendTime=DateTime.Now,
                    CountryId=232
                }
            }) ;

            var mapperConfiguration = new MapperConfiguration(cfg=>cfg.AddProfile<SmsServiceProfiles>());
            var mapper = new Mapper(mapperConfiguration);
            _smssController = new SmssController(smsServiceMock.Object,mapper);
        }


       [Fact]
       public async Task SmssController_GetSentSmssWithOutDate_ReturnTypeActionResultEnumerableSms()
        {
            //Arange
            //Act
            var result=await _smssController.GetSentSmssWithOutDate();


            //Assert
            Assert.IsType <ActionResult<IEnumerable<SentSmssDto>>>(result);
        }

        [Fact]
        public async Task SmssController_GetSentSmss_Return2SentSmssDto()
        {
            //Arrange
            //Act
            var result = await _smssController.GetSentSmssWithOutDate();

            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<SentSmssDto>>>(result);
            Assert.Equal(2,
                ((IEnumerable<SentSmssDto>)((OkObjectResult)actionResult.Result).Value).Count());
        }





    }
}
