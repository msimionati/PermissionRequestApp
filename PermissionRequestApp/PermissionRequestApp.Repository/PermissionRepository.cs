using Microsoft.EntityFrameworkCore;
using PermissionRequestApp.Contracts;
using PermissionRequestApp.Entities;
using PermissionRequestApp.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionRequestApp.Repository
{
    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await FindAll()
                .Include(p => p.PermissionType)
                .ToListAsync();
        }
        public async Task<Permission> GetByIdAsync(int permissionId)
        {
            return await FindByCondition(Permission => Permission.Id.Equals(permissionId))
                .FirstOrDefaultAsync();
        }
        public async Task<Permission> GetPermissionWithDetailsAsync(int permissionId)
        {
            return await FindByCondition(Permission => Permission.Id.Equals(permissionId))
                .Include(p => p.PermissionType)
                .FirstOrDefaultAsync();
        }
        public void CreatePermission(Permission permission)
        {
            Create(permission);
        }
        public void UpdatePermission(Permission permission)
        {
            Update(permission);
        }
        public void DeletePermission(Permission permission)
        {
            Delete(permission);
        }
    }
}
