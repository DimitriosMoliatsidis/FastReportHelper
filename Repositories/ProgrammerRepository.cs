using FastReportHelper.Entities;
using FastReportHelper.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastReportHelper.Repositories;

public class ProgrammerRepository : IProgrammerRepository
{
    private readonly DataBaseContext _context;

    public ProgrammerRepository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Programmer>> GetAllAsync()
    {
        return await _context.Programmers.ToListAsync();
    }

    public async Task<Programmer> GetByIdAsync(int id)
    {
        return await _context.Programmers.FindAsync(id);
    }

    public async Task AddAsync(Programmer programmer)
    {
        await _context.Programmers.AddAsync(programmer);
    }

    public  Task UpdateAsync(Programmer programmer)
    {
        _context.Programmers.Update(programmer);
        return Task.CompletedTask;  // Since EF Core's Update method is not asynchronous.
    }

    public  Task DeleteAsync(Programmer programmer)
    {
        _context.Programmers.Remove(programmer);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
