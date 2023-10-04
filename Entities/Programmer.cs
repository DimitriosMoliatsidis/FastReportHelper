namespace FastReportHelper.Entities;

public class Programmer
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string JobDescription { get; set; }
    public decimal Salary { get; set; }
    public List<Skill> Skills { get; set; }
    public Project Project { get; set; }
}
