namespace CampusConnect.Models;

public class CompanyHR
{
    public int CompanyHRId { get; set; }

    public string UserId { get; set; } = string.Empty;

    public int CompanyId { get; set; }

    public string? Designation { get; set; }

    public string? ApprovedBy { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public ApplicationUser? User { get; set; }

    public Company? Company { get; set; }

    public ApplicationUser? Approver { get; set; }
}