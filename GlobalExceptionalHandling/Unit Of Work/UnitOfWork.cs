using GlobalExceptionalHandling.Context;
using GlobalExceptionalHandling.Interface;
using GlobalExceptionalHandling.Service;

namespace GlobalExceptionalHandling.Unit_Of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoContext _context;
        public UnitOfWork(ToDoContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Tasks = new ToDoRepository(_context);
        }

        public IUserRepository Users { get; private set; }

        public IToDoRepository Tasks { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
