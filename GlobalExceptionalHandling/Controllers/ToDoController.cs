using GlobalExceptionalHandling.Interface;
using GlobalExceptionalHandling.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlobalExceptionalHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;
        private readonly IGenericRepository<ToDo> _toDoService;
        public readonly ILogger<ToDoController> _logger;
        public ToDoController(IToDoService service, IGenericRepository<ToDo> toDoService, ILogger<ToDoController> logger)
        {
            _service = service;
            _toDoService = toDoService;
            _logger = logger;
        }
        // GET: api/<ToDoController>
        [HttpGet]
        public List<ToDo> Get()
        {
            //var tasks = _service.GetAllTasks();
            var tasks = _toDoService.GetAll();
            return tasks;
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //var result = _service.ToDoGetTaskById(id);
            var result = _toDoService.GetById(id);
            if (result == null)
            {
                throw new Exception("Getting errors while fetching customer details");
            }
            return Ok(result);
        }

        // POST api/<ToDoController>
        [HttpPost]
        public ToDo Post([FromBody] ToDo todo)
        {
            var task = _toDoService.Add(todo);
            return task;
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public ToDo Put(int id, [FromBody] ToDo value)
        {
            if (id != value.Id)
            {
                throw new Exception("Please enter the valid details");
            }
            var result = _toDoService.Update(value, id);
            return result;


        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            bool result = _toDoService.Delete(id);
            return result;
        }
    }
}
