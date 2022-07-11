using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.ADONET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UserManagerTests
    {

        [TestMethod]
        public void Get()
        {

            var userManager = new UserManager(new UserDal());
            var result= userManager.Get("TestUser", "12345");

            Assert.IsTrue(result.Success);
        }
    }
}
