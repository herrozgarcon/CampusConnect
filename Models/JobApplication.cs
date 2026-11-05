using CampusConnect.Models.Enum;

namespace CampusConnect.Models;

public class JobApplication
{
    public int ApplicationId { get; set; }

    public int JobId { get; set; }

    public int StudentId { get; set; }

    public DateTime AppliedAt { get; set; }

    public JobApplicationStatus Status { get; set; }

    public string? ResumeUrl { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public JobOpening? JobOpening { get; set; }

    public Student? Student { get; set; }
}