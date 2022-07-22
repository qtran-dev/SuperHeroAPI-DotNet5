using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SuperHeroAPI.Models;
using SuperHeroAPI.Controllers;
using SuperHeroAPI.Data;
using SuperHeroAPI.DTOs;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using SuperHeroAPI.Profiles;

namespace SuperHoerApi.UnitTests
{

    public class SuperHeroControllerTests
    {
        readonly Mock<ISuperHeroRepo> repoMock = new();

        readonly Mock<IMapper> mapperMock = new();

        private readonly Random random = new();

        //[Fact]
        //public void UnitOfWork_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //}

        [Fact]

        public async Task Get_WithNonExistingHero_ReturnsNotFound()
        {
            // Arrange
            repoMock.Setup(repo => repo.GetSuperHero(It.IsAny<int>()))
                .ReturnsAsync((SuperHero)null);

            var controller = new SuperHeroController(repoMock.Object, mapperMock.Object);

            //Act
            var result = await controller.Get(random.Next());

            //Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task Get_WithExistingHero_ReturnsExpectedSuperHero()
        {
            // Arrange
            SuperHero expected = CreateRandomSuperHero();

            repoMock.Setup(repo => repo.GetSuperHero(It.IsAny<int>()))
                .ReturnsAsync(expected);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SuperHeroProfiles());
            });
            var mapper = mockMapper.CreateMapper();

            var controller = new SuperHeroController(repoMock.Object, mapper);

            // Act
            var result = await controller.Get(random.Next());

            // Assert
            Assert.IsType<SuperHeroReadDTO>(result.Value);
            var dto = result.Value;
            Assert.Equal(expected.SuperHeroName, dto.SuperHeroName);
            Assert.Equal($"{expected.LegalFirstName} {expected.LegalLastName}", dto.LegalName);
            Assert.Equal($"{expected.JurisdictionCity}, {expected.JurisdictionState}", dto.Jurisdiction);
        }

        [Fact]
        public async Task GetPrivileged_WithNonExistingHero_ReturnsNotFound()
        {
            // Arrange
            repoMock.Setup(repo => repo.GetSuperHero(It.IsAny<int>()))
                .ReturnsAsync((SuperHero)null);

            var controller = new SuperHeroController(repoMock.Object, mapperMock.Object);

            //Act
            var result = await controller.Get(random.Next());

            //Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetPrivileged_WithExistingHero_ReturnsExpectedSuperHero()
        {
            // Arrange
            SuperHero expected = CreateRandomSuperHero();

            repoMock.Setup(repo => repo.GetSuperHero(It.IsAny<int>()))
                .ReturnsAsync(expected);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SuperHeroProfiles());
            });
            var mapper = mockMapper.CreateMapper();

            var controller = new SuperHeroController(repoMock.Object, mapper);

            // Act
            var result = await controller.GetPrivileged(random.Next());

            // Assert
            result.Value.Should().BeEquivalentTo(
                expected,
                options => options.ComparingByMembers<SuperHero>());
        }

        private SuperHero CreateRandomSuperHero()
        {
            return new()
            {
                Id = random.Next(),
                SuperHeroName = Guid.NewGuid().ToString(),
                LegalFirstName = Guid.NewGuid().ToString(),
                LegalLastName = Guid.NewGuid().ToString(),
                JurisdictionCity = Guid.NewGuid().ToString(),
                JurisdictionState = Guid.NewGuid().ToString()
            };
        }
    }
}
