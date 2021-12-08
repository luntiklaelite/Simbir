using AutoFixture;
using LibraryAPI.Controllers;
using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.DTOs.Other;
using LibraryAPI.Services;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Skreet2k.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApiTest.Controllers
{
    public class HumanControllerTests
    {
        [Fact]
        public void UpdateHuman_BadRequest()
        {
            //Arrange
            Fixture fixture = new Fixture().WithoutCircular();
            var human = fixture.CreateHumanDto();
            var serviceMock = new Mock<IHumanService>();
            serviceMock.Setup(p => p.UpdateHuman(human)).Returns(new Result<HumanDto> { ErrorMessage = "error" });

            var controller = new HumanController(serviceMock.Object);

            //Act
            var result = controller.UpdateHuman(human);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void GetAllHumans_SholdReturn_HumanDto()
        {
            //Arrange
            Fixture fixture = new Fixture().WithoutCircular();
            var human = fixture.CreateHumanDto();
            var serviceMock = new Mock<IHumanService>();
            serviceMock.Setup(p => p.GetHumans()).Returns(new List<HumanDto> { human });

            var controller = new HumanController(serviceMock.Object);

            //Act
            var result = controller.GetAllHumans().FirstOrDefault();

            //Assert
            Assert.Equal(human, result);
        }
    }
}
