using Sanalogi.Core.UnitofWork;
using Sanalogi.Data.Context;
using System.Threading.Tasks;

namespace Sanalogi.Core.UnitOfWorks
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
