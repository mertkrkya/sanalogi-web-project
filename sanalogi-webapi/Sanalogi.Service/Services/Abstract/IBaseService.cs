using Sanalogi.Core.Entities;
using System.Threading.Tasks;

namespace Sanalogi.Service.Services
{
    public interface IBaseService<Dto, T>
    {
        Task<ResponseEntity> GetAllAsync();
        Task<ResponseEntity> GetByIdAsync(int id);
        Task<ResponseEntity> InsertAsync(Dto entity);
        Task<ResponseEntity> UpdateAsync(int id, Dto entity);
        Task<ResponseEntity> DeleteAsync(int id);
    }
}
