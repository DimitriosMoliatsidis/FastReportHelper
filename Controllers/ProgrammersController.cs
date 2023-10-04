using FastReportHelper.Entities;
using FastReportHelper.Repositories;
using FastReportHelper.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastReportHelper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProgrammersController : ControllerBase
{
    private readonly DataBaseContext _context;
    private readonly IProgrammerRepository _programmerRepository;

    public ProgrammersController(DataBaseContext context, IProgrammerRepository programmerRepository)
    {
        _context = context;
        _programmerRepository = programmerRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Programmer>> Get() => await _programmerRepository.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<Programmer> Get(int id) => await _programmerRepository.GetByIdAsync(id);

    [HttpPost]
    public async Task<IActionResult> Post(Programmer programmer)
    {   
        await _programmerRepository.AddAsync(programmer);
        await _programmerRepository.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = programmer.Id }, programmer);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var entityToDelete = await _programmerRepository.GetByIdAsync(id);
        
        if (entityToDelete is null)
            return;

        await _programmerRepository.DeleteAsync(entityToDelete);
        await _context.SaveChangesAsync();
    }
}