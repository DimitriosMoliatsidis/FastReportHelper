using FastReportHelper.Entities;
using FastReportHelper.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastReportHelper.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DataBaseContext _context;

    public ProjectRepository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _context.Projects.Include(p => p.Programmers).ToListAsync();
    }

    public async Task<Project> GetByIdAsync(int id) => await _context.Projects.Include(p => p.Programmers)
                                                                               .FirstOrDefaultAsync(p => p.Id == id);

    public async Task AddAsync(Project project)
    {
        await _context.Projects.AddAsync(project);
    }

    public Task UpdateAsync(Project project)
    {
        _context.Projects.Update(project);
        return Task.CompletedTask;  // Since EF Core's Update method is not asynchronous.
    }

    public Task DeleteAsync(Project project)
    {
        _context.Projects.Remove(project);
        return Task.CompletedTask;  // Same reason as Update.
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
