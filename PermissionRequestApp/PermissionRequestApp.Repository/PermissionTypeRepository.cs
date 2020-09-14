using PermissionRequestApp.Contracts;
using PermissionRequestApp.Entities;
using PermissionRequestApp.Entities.Models;

namespace PermissionRequestApp.Repository
{
    public class PermissionTypeRepository : RepositoryBase<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
