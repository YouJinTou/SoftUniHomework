using NewsSystem.Models;

namespace NewsSystem.Data.Interfaces
{
    public interface INewsContext
    {
        IRepository<News> News { get; }

        int SaveChanges();
    }
}
