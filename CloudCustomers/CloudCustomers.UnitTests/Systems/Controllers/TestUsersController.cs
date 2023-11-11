using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq.Language.Flow;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace CloudCustomers.UnitTests.Sytems.Controllers;

public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange


        var mockUsersService = new Mock<IUsersService>();
        
	    var sut = new UsersController(mockUsersService.Object);


        mockUsersService
            .Setup(service => service
            .GetAllUsers())
            .ReturnsAsync(new List<User>() {
            new() {
                Id = 1,
                Name = "Darren",
                Address = new Address(){
                    Street = "BlaBla St",
                    City = "Endor",
                    ZipCode = "1024423"
                },

                Email = "darren@example.com"
            }
        });

        //Act

        var result = (OkObjectResult)await sut.Get();

        //Assert

        result.StatusCode.Should().Be(200);

    }

    [Fact]
    public async Task Get_OnSuccess_InvokeUserService() {

        //arrange

        var mockUsersService = new Mock<IUsersService>();

        mockUsersService
	    .Setup(service => service.GetAllUsers())
	    .ReturnsAsync(new List<User>());

        var sut = new UsersController(mockUsersService.Object);

        //act
        var result = sut.Get();

        //assert

        mockUsersService
	    .Verify(service => service.GetAllUsers(),
	     Times.Once());
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfUsers() {

        //Arrange
        var mockUsersService = new Mock<IUsersService>();

        mockUsersService
        .Setup(service => service.GetAllUsers())
        .ReturnsAsync(new List<User>() {
            new() {
                Id = 1,
                Name = "Darren",
                Address = new Address(){
                    Street = "BlaBla St",
                    City = "Endor",
                    ZipCode = "1024423"
                },

                Email = "darren@example.com"
	        }
        });

        var sut = new UsersController(mockUsersService.Object);

        //Act

        var result = await sut.Get();

        //Assert

        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();
    }

    [Fact]
    public async Task Get_OnNoUsersFound_Return404() {

        //Arrange
        var mockUsersService = new Mock<IUsersService>();

        mockUsersService
        .Setup(service => service.GetAllUsers())
        .ReturnsAsync(new List<User>());

        var sut = new UsersController(mockUsersService.Object);

        //Act

        var result = await sut.Get();

        //Assert

        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    
    }

}