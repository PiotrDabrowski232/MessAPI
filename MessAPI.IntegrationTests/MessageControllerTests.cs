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
using Xunit.Sdk;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using MessAPI.Entities;


namespace MessAPI.IntegrationTests
{
    public class MessageControllerTests:IClassFixture<MessageFactory<FakeStartup>>
    {
        private readonly WebApplicationFactory<FakeStartup> _factory;
        private readonly HttpClient _client;

        public MessageControllerTests(MessageFactory<FakeStartup> factory)
        {
            _factory = factory;
            _client = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var dbcontesxtOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<MessageDbContext>));

                        services.Remove(dbcontesxtOptions);

                        services.AddDbContext<MessageDbContext>(options => options.UseInMemoryDatabase("Message"));
                    });
                })
                .CreateClient();

            
        }

        [Fact]
        public async Task Get_ReturnsOkResult()
        {


            // Arrange



            //Act

            var response = await _client.GetAsync("message");

            var responseString = await response.Content.ReadAsStringAsync();



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

           var response =  await _client.PostAsync("message", httpContent);

            var responseString = await response.Content.ReadAsStringAsync();



            //Assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent); 
        }

        [Fact]
        public async Task Put_ReturnsOkResult()
        {



            //Arrange

            var model = new Message()
            {
                Id=1,
                Title = "Title",
                Body = "Body"
            };

            var json = JsonConvert.SerializeObject(model);

            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");



            //Act

            await _client.PostAsync("message", httpContent);

            var response = await _client.PutAsync("message", httpContent);

            var responseString = await response.Content.ReadAsStringAsync();



            //Assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult()
        {



            //Arrange

            var modelPost = new Message()
            {
                Title = "Title",
                Body = "Body"
            };

            var json = JsonConvert.SerializeObject(modelPost);

            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");



            //Act

            var postResponse = _client.PostAsync("message", httpContent);

            var response = await _client.DeleteAsync($"message?id={1}");
            


            //Assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

    }
}
