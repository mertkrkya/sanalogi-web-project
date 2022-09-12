using System.Threading.Tasks;

namespace Sanalogi.Core.UnitofWork
{
    public interface IUnitofWork
    {
        Task CommitAsync();
        void Commit();
    }
}