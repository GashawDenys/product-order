using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Impl;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;


namespace DAL.Tests
{
    class TestPostRepository
            : BaseRepository<customer>
    {
        public TestPostRepository(DbContext context)
            : base(context)
        {

        }
    }
    public class BaseRepositoryUnitTests
    {
        [Fact]

        public void Create_InputPostInstance_CalledAddMethodOfDBSetWithPostInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<product_orderContext>()
                .Options;
            var mockContext = new Mock<product_orderContext>(opt);
            var mockDbSet = new Mock<DbSet<customer>>();
            mockContext
               .Setup(context =>
                    context.Set<customer>(
                        ))
                .Returns(mockDbSet.Object);
            var repository = new TestPostRepository(mockContext.Object);
            customer expectedCustomer = new Mock<customer>().Object;
            //Act
            repository.Create(expectedPost);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedCustomer
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {

            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<product_orderContext>()
                .Options;
            var mockContext = new Mock<product_orderContext>(opt);
            var mockDbSet = new Mock<DbSet<customer>>();
            mockContext
                .Setup(context =>
                    context.Set<customer>(
                        ))
                .Returns(mockDbSet.Object);

            customer expectedStreet = new customer() { postID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.customer_id))
                    .Returns(expectedStreet);
            var repository = new TestPostRepository(mockContext.Object);

            //Act
            var actualStreet = repository.Get(expectedStreet.customer_id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStreet.customer_id
                    ), Times.Once());
            Assert.Equal(expectedStreet, actualStreet);
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<product_orderContext>()
                .Options;
            var mockContext = new Mock<product_orderContext>(opt);
            var mockDbSet = new Mock<DbSet<customer>>();
            mockContext
                .Setup(context =>
                    context.Set<customer>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IStreetRepository repository = uow.Streets;
            var repository = new TestPostRepository(mockContext.Object);

            customer expectedStreet = new customer() { customer_id = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.postID)).Returns(expectedStreet);

            //Act
            repository.Delete(expectedStreet.customer_id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStreet.postID
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedStreet
                    ), Times.Once());
        }

    }
}
