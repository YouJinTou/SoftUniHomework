using Moq;
using NewsSystem.Data.Interfaces;
using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Services.Tests.ControllerTests
{
    public class MockContainer
    {
        public Mock<IRepository<News>> NewsRepositoryMock { get; set; }

        public void PrepareMocks()
        {
            this.SetupFakeNews();
        }

        private void SetupFakeNews()
        {
            var fakeNews = new List<News>()
            {
                new News()
                {
                    Id = 20,
                    Title = "Fake News 1",
                    Content = "Fake Content 1",
                    PublishDate = DateTime.Parse("Jan 1, 2020")
                },
                new News()
                {
                    Id = 21,
                    Title = "Fake News 2",
                    Content = "Fake Content 2",
                    PublishDate = DateTime.Parse("Jan 1, 2020")
                },
                new News()
                {
                    Id = 22,
                    Title = "Fake News 3",
                    Content = "Fake Content 3",
                    PublishDate = DateTime.Parse("Jan 1, 2020")
                }
            };

            this.NewsRepositoryMock = new Mock<IRepository<News>>();
            this.NewsRepositoryMock.Setup(n => n.All())
                .Returns(fakeNews.AsQueryable());

            this.NewsRepositoryMock.Setup(n => n.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {

                })
        }
    }
}
