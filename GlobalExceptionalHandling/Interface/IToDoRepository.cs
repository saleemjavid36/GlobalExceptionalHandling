using GlobalExceptionalHandling.Model;

namespace GlobalExceptionalHandling.Interface
{
    public interface IToDoRepository: IGenericRepository<ToDo>
    {
        List<ToDo> GetCompletedTasks(int count);
    }
}
