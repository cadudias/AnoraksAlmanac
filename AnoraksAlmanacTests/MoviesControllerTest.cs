using AnoraksAlmanacApi.Controllers;
using AnoraksAlmanacModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Xunit;

namespace AnoraksAlmanacTests
{
    public class MoviesControllerTest
    {
        private MoviesController _controller;

        public MoviesControllerTest()
        {
            var _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.tests.json")
            .Build();

            _controller = new MoviesController(_configuration);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<ActionResult<List<Movie>>>(okResult.Result);
        }
    }
}