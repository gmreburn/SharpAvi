namespace NutsAndBrackets.Avi.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using RestSharp;
    using RestSharp.Authenticators;

    [TestFixture]
    public class AviClientTests
    {
        [Test]
        public void Test1()
        {
            // Arrange
            var clientMock = new Mock<IRestClient>();
            clientMock.SetupProperty(c => c.Authenticator);
            var api = new AviClient(clientMock.Object);

            // Act
            //api.AuthenticateAs(It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.IsNull(clientMock.Object.Authenticator);
        }

        [Test]
        public void Test2()
        {
            // Arrange
            var clientMock = new Mock<IRestClient>();
            clientMock.SetupProperty(c => c.Authenticator);
            var api = new AviClient(clientMock.Object);

            // Act
            api.AuthenticateAs(It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.IsInstanceOf(typeof(HttpBasicAuthenticator), clientMock.Object.Authenticator);
        }

        [Test]
        public void Test3()
        {
            // Arrange
            var clientMock = new Mock<IRestClient>();
            clientMock.SetupGet(c => c.DefaultParameters).Returns(new List<Parameter>());
            var api = new AviClient(clientMock.Object);

            // Act
            //api.SetTenant(It.IsAny<string>());

            // Assert
            CollectionAssert.IsEmpty(clientMock.Object.DefaultParameters);
        }

        [Test]
        public void Test4()
        {
            // Arrange
            var clientMock = new Mock<IRestClient>();
            clientMock.SetupGet(c => c.DefaultParameters).Returns(new List<Parameter>());
            var api = new AviClient(clientMock.Object);
            var tenant = "tenant";

            // Act
            api.SetTenant(tenant);

            // Assert
            Assert.IsInstanceOf(typeof(Parameter), clientMock.Object.DefaultParameters.Single(p => p.Value.Equals(tenant)));
        }
    }
}