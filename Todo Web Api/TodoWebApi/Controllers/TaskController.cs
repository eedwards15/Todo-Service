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
    public async Task<ActionResult<TaskViewModel>> GetById(int id)
    {
        var task = await _repository.Get(id);
        if (task == null)
        {
            return NotFound();
        }


        var response = _mapper.Map<TaskViewModel>(task);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskViewModel>>> GetAll()
    {
        var tasks = await _repository.GetAll();
        if (tasks == null || !tasks.Any())
        {
            return NotFound();
        }

        var response = _mapper.Map<IEnumerable<TaskViewModel>>(tasks);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<TaskViewModel>> Create([FromBody] TaskViewModel taskViewModel)
    {
        var task = _mapper.Map<Database.tables.TodoTask>(taskViewModel);
        await _repository.Add(task);
        var response = _mapper.Map<TaskViewModel>(task);
        return  Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TaskViewModel>> Update(int id, [FromBody] TaskViewModel taskViewModel)
    {
        var task = await _repository.Get(id);
        if (task == null || id != taskViewModel.Id)
        {
            return NotFound();
        }

        var fromBody = _mapper.Map(taskViewModel, task);
        await _repository.Update(fromBody);
        return Ok(fromBody);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var task = await _repository.Get(id);
        if (task == null)
        {
            return NotFound();
        }
        await _repository.Delete(id);
        return Ok();
    }
}
