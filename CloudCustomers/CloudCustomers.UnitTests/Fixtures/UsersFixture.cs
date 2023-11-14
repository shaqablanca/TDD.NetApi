using CloudCustomers.API.Models;

namespace CloudCustomers.UnitTests.Fixtures
{
	public static class UsersFixture {
        public static List<User> GetTestUsers() => new() {
            new User {
                Name = "TUser 1",
                Email = "tuser1@example.com",   
                Address = new Address {
                    Street = "4 Hulu St",   
                    City = "Jakku",
                    ZipCode = "204323"
                }
            },
            new User {
                Name = "TUser 2",
                Email = "tuser2@example.com",
                Address = new Address {
                    Street = "3 Kachow St",
                    City = "Kamino",
                    ZipCode = "53233"
                }
            },
             new User {
                Name = "TUser 3",
                Email = "tuser3@example.com",
                Address = new Address {
                    Street = "5 ElTorku St",
                    City = "Corellia",
                    ZipCode = "59392"
                }
            }

        };
	}
}

