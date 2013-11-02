using System;
using NUnit.Framework;
using Rhino.Mocks;
using TestSharp;

namespace TheOthers.UnitTests
{
    [TestFixture]
    public class DbExternalDependencyBaseTest
    {
        [Test]
        public void Constructor_NullOrEmptyConnectionString_Exception()
        {
            ExceptionAssert.IsThrowing(typeof(ArgumentNullException), () =>
            {
                new Stub1DbExternalDependency("name", null);
            });

            ExceptionAssert.IsThrowing(typeof(ArgumentException), () =>
            {
                new Stub1DbExternalDependency("name", "");
            });
        }

        [Test]
        public void Constructor_ConnectionStringDoesNotExists_Exception()
        {
            ExceptionAssert.IsThrowing(new ArgumentException("The connection string with name 'failed' does not exist on .config file."), () =>
            {
                new Stub1DbExternalDependency("name", "failed");
            });
        }

        [Test]
        public void Constructor_ConnectionStrinExists_Instanced()
        {
            var actual = new Stub1DbExternalDependency("name", "Test");
            Assert.AreEqual("name", actual.Name);            
        }
    }
}