using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.ADONET;
using Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class SearchLogManagerTests
    {

        [TestMethod]
        public void Add()
        {
            var searchLog = new SearchLog
            {
                InputText = "Test InputText",
                TranslatedText = "Test TranslatedText",
                TranslationType = "Test Translation Type",
                UserName = "Test User",
                CreatedDate = DateTime.Now.ToString()
            };

            var searchLogManager = new SearchLogManager(new SearchLogDal());
            var result = searchLogManager.Add(searchLog);
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void GetAll()
        {
            var searchLogManager = new SearchLogManager(new SearchLogDal());
            var result = searchLogManager.GetAll();

            Assert.IsTrue(result.Success);

        }
    }
}
