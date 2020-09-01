using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using VoterRegistration.Data;
using VoterRegistration.Business;

namespace VoterRegistration.Tests.Services
{
    [TestClass]
    public class RegisterTests
    {
        IDataLayer dataLayer = null;
        IRegisterBusiness registerService = null;

        [TestInitialize]
        public void Setup()
        {
            dataLayer = Substitute.For<IDataLayer>();
            registerService = new RegisterBusiness(dataLayer);

        }
        [TestMethod]
        public void Service_Calls_User()
        {
            registerService.GetVoter(1);
            dataLayer.Received().GetUser(1);
        }

        [TestMethod]
        public void Service_Returns_Some_Userinfo()
        {
            var returnValue = "Derek";

            dataLayer.GetUser(1).Returns(returnValue);

            Assert.AreEqual(returnValue, registerService.GetVoter(1).Name);
        }

        [TestMethod]
        public void Service_Registers_New_User()
        {
            var newUser = "Sam";
            dataLayer.RegisterUser(1, newUser).Returns(true);
            Assert.IsTrue(registerService.RegisterVoter(1, newUser).IsSuccess);
        }



    }
}
