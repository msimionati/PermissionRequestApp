using PermissionRequestApp.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionRequestApp.Contracts
{
    public interface IPermissionTypeRepository : IRepositoryBase<PermissionType>
    {
        Task<IEnumerable<PermissionType>> GetAllAsync();
        Task<PermissionType> GetByIdAsync(int permissionTypeId);
        void Create(PermissionType permissionType);
        void Update(PermissionType permissionType);
        void Delete(PermissionType permissionType);
    }
}
