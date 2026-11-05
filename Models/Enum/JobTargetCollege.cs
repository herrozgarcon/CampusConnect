namespace CampusConnect.Models;

public class JobTargetCollege
{
    public int JobTargetCollegeId { get; set; }

    public int JobId { get; set; }

    public int CollegeId { get; set; }

    public JobOpening? JobOpening { get; set; }

    public College? College { get; set; }
}