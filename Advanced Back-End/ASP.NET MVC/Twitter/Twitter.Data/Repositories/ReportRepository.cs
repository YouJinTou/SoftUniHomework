using Twitter.Data.Repositories.Interfaces;
using Twitter.Models;

namespace Twitter.Data.Repositories
{
    public class ReportRepository : GenericRepository<Report>, IRepository<Report>
    {
        public ReportRepository(TwitterDbContext context)
            : base(context)
        {
        }
    }
}
