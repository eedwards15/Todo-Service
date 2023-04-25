using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.repositories
{
    using Database.interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDatabaseContext _context;

        public TodoRepository(TodoDatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(tables.TodoTask item)
        {
            _context.Tasks.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = _context.Tasks.Find(id);
            if (item != null)
            {
                _context.Tasks.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<tables.TodoTask> Get(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<List<tables.TodoTask>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task Update(tables.TodoTask item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

}
