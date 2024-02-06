using GlobalExceptionalHandling.Context;
using GlobalExceptionalHandling.Interface;
using GlobalExceptionalHandling.Model;

namespace GlobalExceptionalHandling.Service
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ToDoContext toDoContext) : base(toDoContext)
        {

        }
    }
}
