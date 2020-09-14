using System.Threading.Tasks;

namespace PermissionRequestApp.Contracts
{
    public interface IRepositoryWrapper
    {
        IPermissionRepository Permission { get; }
        IPermissionTypeRepository PermissionType { get; }
        Task SaveAsync();
    }
}
