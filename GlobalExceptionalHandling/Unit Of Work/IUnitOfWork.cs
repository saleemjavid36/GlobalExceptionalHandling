using GlobalExceptionalHandling.Interface;

namespace GlobalExceptionalHandling.Unit_Of_Work
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IToDoRepository Tasks { get; }
        //DbContext Class SaveChanges method
        void Save();
    }
}
