namespace PermissionRequestApp.Contracts
{
    public interface IRepositoryWrapper
    {
        IPermissionRepository Permission { get; }
        IPermissionTypeRepository PermissionType { get; }
        void SaveAsync();
    }
}
