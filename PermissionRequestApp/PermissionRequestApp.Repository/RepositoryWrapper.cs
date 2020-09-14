using PermissionRequestApp.Contracts;
using PermissionRequestApp.Entities;
using System.Threading.Tasks;

namespace PermissionRequestApp.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IPermissionRepository _permission;
        private IPermissionTypeRepository _permissionType;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IPermissionRepository Permission
        {
            get
            {
                if (_permission == null)
                {
                    _permission = new PermissionRepository(_repoContext);
                }
                return _permission;
            }
        }

        public IPermissionTypeRepository PermissionType
        {
            get
            {
                if (_permissionType == null)
                {
                    _permissionType = new PermissionTypeRepository(_repoContext);
                }
                return _permissionType;
            }
        }

        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
