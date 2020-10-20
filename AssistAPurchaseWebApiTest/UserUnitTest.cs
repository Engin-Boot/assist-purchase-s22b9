using AssistAPurchase.Controllers;
using AssistAPurchase.Models;
using AssistAPurchase.Repository;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AssistAPurchaseWebApiTest
{
    public class UserUnitTest
    {
        readonly UserController _controller;

        public UserUnitTest()
        {
            IUserRepository service = new UserRepository();
            _controller = new UserController(service);
        }

        [Fact]
        public void LoginReturnsOkResult()
        {
            var user = new UserModel
            {
                Email = "gagan@gmail.com",
                Password = "gagan",
            };
            // Act
            var result = _controller.Login(user);
            // Assert
            var actualResult = result as OkResult;
            Assert.NotNull(actualResult);
        }
        [Fact]
        public void LoginReturnsStatusCode500()
        {
            var user = new UserModel
            {
                Email = "test@email.com",
                Password = "pass",
            };
            // Act
            var result = _controller.Login(user);
            // Assert
            var actualResult = result as NotFoundResult;
            Assert.NotNull(actualResult);
        }
        [Fact]
        public void SignUpReturnsStatusCode500()
        {
            var user = new UserModel
            {
                Email = "gagan@gmail.com",
                Password = "gagan"
            };
            // Act
            var result = _controller.SignUp(user);
            // Assert
            var actualResult = result as NotFoundResult;
            Assert.NotNull(actualResult);
        }
        [Fact]
        public void SignUpReturnsOkResult()
        {
            var user = new UserModel
            {
                Email = "test@gmail.com",
                Password = "test",
            };
            // Act
            var result = _controller.SignUp(user);
            // Assert
            var actualResult = result as OkResult;
            Assert.NotNull(actualResult);
        }
    }
}
