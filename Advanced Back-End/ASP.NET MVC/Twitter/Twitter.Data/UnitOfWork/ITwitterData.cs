using Twitter.Data.Repositories.Interfaces;
using Twitter.Models;

namespace Twitter.Data.UnitOfWork
{
    public interface ITwitterData
    {
        IRepository<User> Users { get; }
        IRepository<Tweet> Tweets { get; }
        IRepository<Report> Reports { get; }
        IRepository<Notification> Notifications { get; }
        IRepository<Message> Messages { get; }
        int Complete();
    }
}
