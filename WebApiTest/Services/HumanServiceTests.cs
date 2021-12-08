using AutoFixture;
using LibraryAPI.Models.DTOs;
using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
using LibraryAPI.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApiTest.Services
{
    public class HumanServiceTests
    {
        [Fact]
        public void AddHuman_ShouldReturn_HumanDto()
        {
            //Arrange
            var fixture = new Fixture().WithoutCircular();
            var human = fixture.CreateHuman();
            var humanDto = new HumanDto
            {
                Id = human.Id,
                FirstName = human.FirstName,
                LastName = human.LastName,
                MiddleName = human.MiddleName,
                BirthDate = human.BirthDate
            };
            var repositoryMock = new Mock<IHumanRepository>();
            repositoryMock.SetReturnsDefault(human);

            var service = new HumanService(repositoryMock.Object);

            //Act
            var result = service.AddHuman(humanDto);

            //Assert
            Assert.Equal(result, humanDto);
        }

        [Fact]
        public void GetHumans_ShouldReturn_HumansDto()
        {
            //Arrange
            var fixture = new Fixture().WithoutCircular();
            var human = fixture.CreateHuman();
            var humanDto = new HumanDto
            {
                Id = human.Id,
                FirstName = human.FirstName,
                LastName = human.LastName,
                MiddleName = human.MiddleName,
                BirthDate = human.BirthDate
            };
            var repositoryMock = new Mock<IHumanRepository>();
            repositoryMock.Setup(s => s.GetHumans()).Returns(new List<Human> { human });

            var service = new HumanService(repositoryMock.Object);

            //Act
            var result = service.GetHumans().FirstOrDefault();

            //Assert
            Assert.Equal(result, humanDto);
        }
    }
}
