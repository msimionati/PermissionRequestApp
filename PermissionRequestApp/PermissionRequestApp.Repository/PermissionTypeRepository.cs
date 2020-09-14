using Microsoft.EntityFrameworkCore;
using PermissionRequestApp.Contracts;
using PermissionRequestApp.Entities;
using PermissionRequestApp.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionRequestApp.Repository
{
    public class PermissionTypeRepository : RepositoryBase<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<PermissionType>> GetAllAsync()
        {
            return await FindAll()
                .ToListAsync();
        }
        public async Task<PermissionType> GetByIdAsync(int permissionId)
        {
            return await FindByCondition(PermissionType => PermissionType.Id.Equals(permissionId))
                .FirstOrDefaultAsync();
        }

        public void CreatePermission(PermissionType permission)
        {
            Create(permission);
        }
        public void UpdatePermission(PermissionType permission)
        {
            Update(permission);
        }
        public void DeletePermission(PermissionType permission)
        {
            Delete(permission);
        }
    }
}
