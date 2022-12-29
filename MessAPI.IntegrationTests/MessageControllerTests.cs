using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MessAPI.IntegrationTests
{
    public class MessageControllerTests:IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient _client;
        public MessageControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            
            //Act

            var response = await _client.GetAsync("/message");


            //Assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }


        [Fact]
        public async Task Post_ReturnsNoContentResult()
        {
           //Arrange

            var model = new Message()
            {
                Title= "Title",
                Body="Body"
            };

            var json = JsonConvert.SerializeObject(model);

            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //Act

           var response =  await _client.PostAsync("/message", httpContent);

            //Assert

           response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent); 
        }

        [Fact]
        public async Task Put_ReturnsOkResult()
        {
            //Arrange

            var model = new Message()
            {
                Id = 1,
                Title = "Title",
                Body = "Body"
            };

            var json = JsonConvert.SerializeObject(model);

            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //Act

            var response = await _client.PutAsync("/message", httpContent);

            //Assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //to jest napewno do poprawy poniewaz za pierwszym razem dziala ale gdy nastepnym razme chcemy zrobic test to juz takiego elementu nie ma w naszej bazie danych
        [Fact]
        public async Task Delete_ReturnsOkResult()
        {
            //Arrange

           

            //Act
            
            var response = await _client.DeleteAsync($"/message?id={11}");

            //Assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

    }
}
