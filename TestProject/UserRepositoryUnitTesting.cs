using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Reposirories;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TestProject
{
    public class UserRepositoryUnitTesting
    {
        [Fact]
        public async Task login_invalidCredentials_ReturnsNull()
        {
            //Arrange

            var user = new User { FirstName = "loginTestFirstName", UserName = "loginTestUserName", LastName = "loginTestLastName", Password = "loginTestPassword", Id = 1 };
            var options = new DbContextOptionsBuilder<ToysContext>().Options;
            var mockContext = new Mock<ToysContext>(options);
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            UserRepository userRepository = new UserRepository(mockContext.Object);
            User loginUser = new();
            loginUser.UserName = "qq";
            loginUser.Password = user.Password;
            //Act

            var result = await userRepository.login(loginUser);

            //Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task login_validCredentials_ReturnsUser()
        {
            //Arrange

            var user = new User { FirstName = "loginTestFirstName", UserName = "loginTestUserName", LastName = "loginTestLastName", Password = "loginTestPassword" , Id =1};
            var options = new DbContextOptionsBuilder<ToysContext>().Options;
            var mockContext = new Mock<ToysContext>(options);
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            UserRepository userRepository = new UserRepository(mockContext.Object);
            User loginUser = new();
            loginUser.UserName = user.UserName;
            loginUser.Password = user.Password;
            //Act

            var result = await userRepository.login(loginUser);

            //Assert
            Assert.Equal(user, result);
        }
        [Fact]
        public async Task Login_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "testUser", Password = "password123" };
            var options = new DbContextOptionsBuilder<ToysContext>().Options;
            var mockContext = new Mock<ToysContext>(options);
            var users = new List<User> { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var userRepository = new UserRepository(mockContext.Object);
            var loginUser = new User { UserName = "wrongUser", Password = "wrongPassword" };

            // Act
            var result = await userRepository.login(loginUser);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task Register_ValidUser_ReturnsUser()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "testUser", FirstName = "Test", LastName = "User", Password = "password123" };
            var options = new DbContextOptionsBuilder<ToysContext>().Options;
            var mockContext = new Mock<ToysContext>(options);
            var users = new List<User>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var userRepository = new UserRepository(mockContext.Object);

            // Act
            var result = await userRepository.register(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.UserName, result.UserName);
            Assert.Equal(user.FirstName, result.FirstName);
        }
        [Fact]
        public async Task Register_NullUser_ThrowsArgumentNullException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ToysContext>().Options;
            var mockContext = new Mock<ToysContext>(options);
            var userRepository = new UserRepository(mockContext.Object);

            // Act & Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => userRepository.register(null));
        }
        [Fact]
        public async Task UpdateUser_ValidUser_ReturnsUpdatedUser()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "testUser", FirstName = "Test", LastName = "User", Password = "password123" };
            var updatedUser = new User { Id = 1, UserName = "updatedUser", FirstName = "Updated", LastName = "User", Password = "newPassword" };
            var options = new DbContextOptionsBuilder<ToysContext>().Options;
            var mockContext = new Mock<ToysContext>(options);
            var users = new List<User> { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var userRepository = new UserRepository(mockContext.Object);

            // Act
            var result = await userRepository.updateUser(user.Id, updatedUser);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedUser.UserName, result.UserName);
            Assert.Equal(updatedUser.FirstName, result.FirstName);
            Assert.Equal(updatedUser.LastName, result.LastName);
        }

        [Fact]
        //public async Task UpdateUser_NonExistentUser_ThrowsInvalidOperationException()
        //{
        //    // Arrange
        //    var user = new User { Id = 1, UserName = "testUser", FirstName = "Test", LastName = "User", Password = "password123" };
        //    var updatedUser = new User { Id = 2, UserName = "updatedUser", FirstName = "Updated", LastName = "User", Password = "newPassword" };
        //    var options = new DbContextOptionsBuilder<ToysContext>().Options;
        //    var mockContext = new Mock<ToysContext>(options);
        //    var users = new List<User> { user };
        //    mockContext.Setup(x => x.Users).ReturnsDbSet(users);
        //    var userRepository = new UserRepository(mockContext.Object);
        //    //Act
        //    var result = userRepository.updateUser(updatedUser.Id, updatedUser);
        //    //  Assert
        //    var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => userRepository.updateUser(updatedUser.Id, updatedUser));
        //    Assert.Equal("User not found.", exception.Message);
        //}
        //[Fact] // Example using xUnit
        public async Task UpdateUser_NonExistentUser_ThrowsInvalidOperationException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ToysContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new ToysContext(options);
            context.Users.Add(new User { Id = 1, UserName = "testUser", FirstName = "Test", LastName = "User", Password = "password123" });
            context.SaveChanges();

            var userRepository = new UserRepository(context);
            var updatedUser = new User { Id = 2, UserName = "updatedUser", FirstName = "Updated", LastName = "User", Password = "newPassword" };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(
                () => userRepository.updateUser(updatedUser.Id, updatedUser));

            Assert.Equal("User not found.", exception.Message);
        }

        [Fact]
        public async Task UpdateUser_NullUser_ThrowsArgumentNullException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ToysContext>().Options;
            var mockContext = new Mock<ToysContext>(options);
            var userRepository = new UserRepository(mockContext.Object);

            // Act & Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => userRepository.updateUser(1, null));
        }

    }
}

