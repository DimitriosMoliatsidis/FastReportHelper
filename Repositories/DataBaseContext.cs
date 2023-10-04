using FastReportHelper.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastReportHelper.Repositories;

public class DataBaseContext : DbContext
{
    public DbSet<Programmer> Programmers { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Project> Projects { get; set; }

    public DataBaseContext(DbContextOptions<DbContext> options)
        : base(options)
    { }
}