using AutoMapper;
using Database.interfaces;
using Microsoft.AspNetCore.Mvc;
using Todo_Web_Api.ViewModel;


[ApiController]
[Route("api/tasks")]
public class TaskController : ControllerBase
{
    private readonly ITodoRepository _repository;
    private readonly IMapper _mapper;

    public TaskController(ITodoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public ActionResult<TaskViewModel> GetById(int id)
    {
        var task = _repository.Get(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<TaskViewModel>(task));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskViewModel>>> GetAll()
    {
        var tasks = await _repository.GetAll();
        

        if (tasks == null || !tasks.Any())
        {
            return NotFound();
        }
        return Ok(_mapper.Map<IEnumerable<TaskViewModel>>(tasks));
    }

    [HttpPost]
    public async Task<ActionResult<TaskViewModel>> Create(TaskViewModel taskViewModel)
    {
        var task = _mapper.Map<Database.tables.TodoTask>(taskViewModel);
        await _repository.Add(task);
        return CreatedAtAction(nameof(GetById), new { id = task.Id }, _mapper.Map<TaskViewModel>(task));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TaskViewModel>> Update(int id, TaskViewModel taskViewModel)
    {
        var task = await _repository.Get(id);
        if (task == null)
        {
            return NotFound();
        }
        _mapper.Map(taskViewModel, task);
        await _repository.Update(task);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TaskViewModel>> Delete(int id)
    {
        var task = await _repository.Get(id);
        if (task == null)
        {
            return NotFound();
        }
        await _repository.Delete(id);
        return Ok(_mapper.Map<TaskViewModel>(task));
    }
}
