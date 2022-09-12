using Sanalogi.Data.Context;
using Sanalogi.Data.Models;
using Sanalogi.Data.Repositories.Abstract;

namespace Sanalogi.Data.Repositories.Concrete
{
    public class SiparisRepository : BaseRepository<Siparis>, ISiparisRepository
    {
        private readonly AppDbContext _dbctx;
        public SiparisRepository(AppDbContext dbctx) : base(dbctx)
        {
            _dbctx = dbctx;
        }
    }
}
