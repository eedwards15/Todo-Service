namespace Database.interfaces
{
    using System.Collections.Generic;

    public interface ITodoRepository
    {
        Task<tables.TodoTask> Get(int id);
        Task<List<tables.TodoTask>> GetAll();

        Task Add(tables.TodoTask item);
        Task Update(tables.TodoTask item);
        Task Delete(int id);
    }

}
