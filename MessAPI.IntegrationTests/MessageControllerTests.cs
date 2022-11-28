using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace MessAPI.IntegrationTests
{
    public class MessageControllerTests
    {
        [Fact]
        public async Task POST_ReturnsOkResult()
        {
            //Arange
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();



            //Act
            var response = await client.GetAsync("/message");



            //Assert
            response.EnsureSuccessStatusCode();
            //response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);


        }

    }
}
