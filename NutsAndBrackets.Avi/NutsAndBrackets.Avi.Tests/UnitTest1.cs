namespace NutsAndBrackets.Avi.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Moq;
    using NUnit.Framework;
    using RestSharp;

    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            // Arrange
            var clientMock = new Mock<IRestClient>();
            IPoolsController pc = new PoolsController(clientMock.Object);

            // Act
            var pool = pc.GetByName(It.IsAny<string>());

            // Assert
            Assert.IsNull(pool);
        }

        [Test]
        public void TestMethod2()
        {
            // Arrange
            var clientMock = new Mock<IRestClient>();
            IPoolsController pc = new PoolsController(clientMock.Object);
            var responseMock = new Mock<IRestResponse<PoolInventory>>();
            var exception = new Exception();
            responseMock.Setup(r=>r.ErrorException).Returns(exception);
            clientMock.Setup(c => c.Execute<PoolInventory>(It.Is<IRestRequest>(r=>r.Resource.Equals("pool-inventory")))).Returns(responseMock.Object).Verifiable();

            // Act
            var ex = Assert.Throws<Exception>(()=> { var pool = pc.GetByName(It.IsAny<string>()); });

            // Assert
            Assert.AreEqual(exception, ex);
        }
        
        [Test]
        public void TestMethod3()
        {
            // Arrange
            var clientMock = new Mock<IRestClient>();
            IPoolsController pc = new PoolsController(clientMock.Object);
            var responseMock = new Mock<IRestResponse<PoolInventory>>();
            var piMock = new PoolInventory();
            piMock.results = new List<Result>() { new Result() };
            responseMock.Setup(r => r.Data).Returns(piMock);
            clientMock.Setup(c => c.Execute<PoolInventory>(It.Is<IRestRequest>(r => r.Resource.Equals("pool-inventory")))).Returns(responseMock.Object).Verifiable();
            
            // Act
            var pool = pc.GetByName(It.IsAny<string>());

            // Assert
        }
    }
}