using FastReportHelper.Entities;
using FastReportHelper.Repositories;
using FastReportHelper.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastReportHelper.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectRepository _projectRepository;
    public ProjectsController(DataBaseContext context, IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Project>> Get()
    {
        return await _projectRepository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<Project> GetAsync(int id)
    {
        return await _projectRepository.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Project project)
    {
        await _projectRepository.UpdateAsync(project);
        return CreatedAtAction(nameof(Get), new { id = project.Id }, project);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        if (project is null)
        {
            return NotFound();
        }
        await _projectRepository.DeleteAsync(project);
        return Accepted();
    }
}