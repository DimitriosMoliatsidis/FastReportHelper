using FastReportHelper.Entities;
using FastReportHelper.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastReportHelper.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly DataBaseContext _context;

    public SkillRepository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Skill>> GetAllAsync()
    {
        return await _context.Skills.ToListAsync();
    }

    public async Task<Skill> GetByIdAsync(int id) => await _context.Skills.FindAsync(id);

    public async Task AddAsync(Skill skill)
    {
        await _context.Skills.AddAsync(skill);
    }

    public Task UpdateAsync(Skill skill)
    {
        _context.Skills.Update(skill);
        return Task.CompletedTask;  // Since EF Core's Update method is not asynchronous.
    }

    public Task DeleteAsync(Skill skill)
    {
        _context.Skills.Remove(skill);
        return Task.CompletedTask;  // Same reason as Update.
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
