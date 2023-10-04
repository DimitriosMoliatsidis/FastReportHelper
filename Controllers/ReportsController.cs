using FastReport;
using FastReport.Export.Pdf;
using FastReportHelper.Entities;
using FastReportHelper.FastReportService;
using FastReportHelper.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastReportHelper.Controllers;
public class ReportsController : Controller
{
    private readonly DataBaseContext _context;
    private readonly ReportCreator _reportCreator;
    public ReportsController(DataBaseContext context, ReportCreator reportCreator)
    {
        _context = context;
        _reportCreator = reportCreator;
}

    [HttpGet("report")]
    public async Task<IActionResult> GetReport(int id)
    {
        var preparedReport = await _reportCreator.CreateReportAsync();

        //Create The Pdf Export
        var export = new PDFExport();
        using var memoryStream = new MemoryStream();
        preparedReport.Export(export, memoryStream);

        return File(memoryStream.ToArray(), "application/pdf");
    }
}
