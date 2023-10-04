using FastReport;
using FastReportHelper.Repositories.Interfaces;

namespace FastReportHelper.FastReportService;

public class ReportCreator
{
    private readonly IProgrammerRepository _programmerRepository;
    private readonly ISkillRepository _skillRepository;
    private readonly IProjectRepository _projectRepository;

    public ReportCreator(IProgrammerRepository programmerRepository,
                         ISkillRepository skillRepository,
                         IProjectRepository projectRepository)
    {
        _programmerRepository = programmerRepository;
        _skillRepository = skillRepository;
        _projectRepository = projectRepository;
    }

    public async Task<Report> CreateReportAsync()
    {
        var report = new Report();

        //Path to the .frx file template for your report
        report.Load("ReportExample.frx");

        // Fetch data from repositories
        var programmers = await _programmerRepository.GetAllAsync();
        var skills = await _skillRepository.GetAllAsync();
        var projects = await _projectRepository.GetAllAsync();

        // Register the data 
        report.RegisterData(programmers, "Programmers");
        report.RegisterData(skills, "Skills");
        report.RegisterData(projects, "Projects");

        // Prepare the report
        report.Prepare();

        return report;
    }
}