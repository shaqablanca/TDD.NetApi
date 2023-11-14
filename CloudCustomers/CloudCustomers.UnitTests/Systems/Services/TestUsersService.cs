using System;
using CloudCustomers.API.Services;

namespace CloudCustomers.UnitTests.Systems.Services
{
	public class TestUsersService
	{
		[Fact]
		public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest() {

			//Arrange
			var sut = new UsersService();
			//Act

			await sut.GetAllUsers();

			//Assert
		}
	}
}

