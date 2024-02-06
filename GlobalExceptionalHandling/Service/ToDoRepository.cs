using GlobalExceptionalHandling.Context;
using GlobalExceptionalHandling.Interface;
using GlobalExceptionalHandling.Model;

namespace GlobalExceptionalHandling.Service
{
    public class ToDoRepository : GenericRepository<ToDo>, IToDoRepository
    {
        public ToDoRepository(ToDoContext context) : base(context)
        {
        }
        public List<ToDo> GetCompletedTasks(int count)
        {
            return table.Where(t => t.Status == "Completed").ToList();
        }
    }
}
