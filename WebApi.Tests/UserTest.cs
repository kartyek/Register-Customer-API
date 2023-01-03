using System;
using WebApi.Controllers;
using WebApi.Models;
using WebApi.Services;
using Xunit;
using Moq;
using WebApi.Models.Users;
using WebApi.Entities;
using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Tests
{
    public class UserTest
    {
        #region Property
        public Mock<IUserService> mock = new Mock<IUserService>();
        public Mock<IMapper> mockMapper = new Mock<IMapper>();
        #endregion

        [Fact]
        public void LegalAge()
        {
            var bday = Convert.ToDateTime("14/08/1990");
            var ts = DateTime.Today - bday;
            var year = DateTime.MinValue.Add(ts).Year - 1;

            // Assert
            Assert.True(year >= 18, "It is a Legal age to create an insurance");

        }

        [Fact]
        public void IsNotLegalAge()
        {
            var bday = Convert.ToDateTime("14/08/2015");
            var ts = DateTime.Today - bday;
            var year = DateTime.MinValue.Add(ts).Year - 1;

            // Assert
            Assert.False(year >= 18, "It is not a Legal age to create an insurance");

        }

        [Fact]
        public void Create()
        {
            var userDetails = new User()
            {
                CustomerID = 123456789,
                FirstName = "Test",
                LastName = "Testing",
                ReferenceNumber = "AA-999999",
                EmailId = "Test@gmail.com",
                DOB = "14/08/1990"
            };
            var registermodel = new RegisterModel()
            {
                CustomerID = 123456789,
                FirstName = "Test",
                LastName = "Testing",
                ReferenceNumber = "AA-999999",
                EmailId = "Test@gmail.com",
                DOB = "14/08/1990"
            };
            mock.Setup(p => p.Create(userDetails)).Returns(userDetails);
            UsersController userinfo = new UsersController(mock.Object, mockMapper.Object);
            var result = userinfo.Register(registermodel);
            var okResult = result as OkResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void USerController_WhenCreateIsCalled_ThenBadRequestIsReturned()
        {
            UsersController userDetails = new UsersController(mock.Object, mockMapper.Object);

            var registermodel = new RegisterModel()
            {
                CustomerID = 123456789,
                FirstName = "Test",
                LastName = "Testing",
                ReferenceNumber = "",
                EmailId = "Test@gmail.com",
                DOB = "14/08/1990"
            };

            userDetails.ModelState.AddModelError("ReferenceError", "Empty value");

            IActionResult result = userDetails.Register(registermodel);

            var BadResult = result as BadRequestResult;

            Assert.Equal(400, BadResult.StatusCode);
            
        }
    }
}
