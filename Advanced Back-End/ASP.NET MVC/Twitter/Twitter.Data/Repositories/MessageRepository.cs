using Twitter.Data.Repositories.Interfaces;
using Twitter.Models;

namespace Twitter.Data.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IRepository<Message>
    {
        public MessageRepository(TwitterDbContext context)
            : base(context)
        {
        }
    }
}
