using PermissionRequestApp.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionRequestApp.Contracts
{
    public interface IPermissionRepository : IRepositoryBase<Permission>
    {
        Task<IEnumerable<Permission>> GetAllAsync();
        Task<Permission> GetByIdAsync(int permissionId);
        void Create(Permission permission);
        void Update(Permission permission);
        void Delete(Permission permission);
    }
}
