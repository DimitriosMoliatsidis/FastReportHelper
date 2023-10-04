using FastReportHelper.Entities;
using FastReportHelper.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastReportHelper.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SkillsController : ControllerBase
{
    private readonly DataBaseContext _context;

    public SkillsController(DataBaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var skills = await _context.Skills.ToListAsync();
        return Ok(skills);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var skill = await _context.Skills.FindAsync(id);
        if (skill == null)
        {
            return NotFound();
        }
        return Ok(skill);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Skill skill)
    {
        _context.Skills.Add(skill);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = skill.Id }, skill);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var skill = await _context.Skills.FindAsync(id);
        if (skill == null)
        {
            return NotFound();
        }
        _context.Skills.Remove(skill);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
