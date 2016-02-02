using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsSystem.Data;
using NewsSystem.Data.Interfaces;
using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace NewsSystem.Services.Tests.RepositoryTests
{
    [TestClass]
    public class RepositoryTests
    {
        private TransactionScope tran;
        private INewsContext newsContext;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
            newsContext = new NewsData(new NewsContext());
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetAllNewsItems()
        {
            List<News> newsExpected = new List<News>();
            for (int i = 0; i < 5; i++)
            {
                News news = new News()
                {
                    Title = "Title " + i,
                    Content = "Content " + i,
                    PublishDate = DateTime.Now.AddDays(-i)
                };

                newsExpected.Add(news);
            }

            var newsActual = this.newsContext.News.All().ToList();
            
            for (int i = 0; i < newsActual.Count; i++)
            {
                Assert.AreEqual(newsExpected[i].Content,
                    newsActual[i].Content);
            }
        }
    }
}
