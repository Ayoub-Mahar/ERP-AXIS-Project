using ERP.Interfaces;

namespace ERP.Services.IService
{
    public interface IUnitOfWork
    {
        ILevel1Repository _level1Repository { get; }
        ILevel2Repository _level2Repository { get; }
    }
}
