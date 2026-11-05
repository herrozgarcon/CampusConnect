using CampusConnect.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    
    public DbSet<College> Colleges { get; set; }
    
    public DbSet<Company> Companies { get; set; }
    
    public DbSet<PlacementOfficer> PlacementOfficers { get; set; }

    public DbSet<CompanyHR> CompanyHRs { get; set; }

    public DbSet<Student> Students { get; set; }
    
    public DbSet<JobOpening> JobOpenings { get; set; }

    public DbSet<JobTargetCollege> JobTargetColleges { get; set; }

    public DbSet<JobApplication> JobApplications { get; set; }
    
    public DbSet<RecruitmentDrive> RecruitmentDrives { get; set; }

    public DbSet<InterviewRound> InterviewRounds { get; set; }

    public DbSet<InterviewSchedule> InterviewSchedules { get; set; }
    
    public DbSet<ApplicationStatusHistory> ApplicationStatusHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //Application user configuration
        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable("ApplicationUsers");

            // Primary Key
            entity.HasKey(u => u.UserId);

            entity.Property(u => u.UserId)
                .HasMaxLength(450);

            // Full Name
            entity.Property(u => u.FullName)
                .IsRequired();

            // Email
            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(450);

            entity.HasIndex(u => u.Email)
                .IsUnique();

            // Phone Number
            entity.Property(u => u.PhoneNumber)
                .IsRequired();

            // Account Status
            entity.Property(u => u.AccountStatus)
                .IsRequired();

            // Created Date
            entity.Property(u => u.CreatedAt)
                .IsRequired();

            // Updated Date
            entity.Property(u => u.UpdatedAt)
                .IsRequired();
        });
// College Configuration
        modelBuilder.Entity<College>(entity =>
        {
            entity.ToTable("Colleges");

            entity.HasKey(c => c.CollegeId);

            entity.Property(c => c.CollegeName)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(c => c.CollegeCode)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasIndex(c => c.CollegeCode)
                .IsUnique();

            entity.Property(c => c.UniversityName)
                .HasMaxLength(200);

            entity.Property(c => c.OfficialEmail)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(c => c.Website)
                .HasMaxLength(255);

            entity.Property(c => c.Status)
                .IsRequired();

            entity.Property(c => c.CreatedAt)
                .IsRequired();
        });

        // Company Configuration
        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Companies");

            entity.HasKey(c => c.CompanyId);

            entity.Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(c => c.CompanyEmail)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(c => c.Website)
                .HasMaxLength(255);

            entity.Property(c => c.Industry)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(c => c.Description)
                .IsRequired(false);

            entity.Property(c => c.Status)
                .IsRequired();

            entity.Property(c => c.CreatedAt)
                .IsRequired();
        });
        
        // PlacementOfficer
modelBuilder.Entity<PlacementOfficer>(entity =>
{
    entity.ToTable("PlacementOfficers");

    entity.HasKey(p => p.PlacementOfficerId);

    entity.Property(p => p.Designation)
        .IsRequired()
        .HasMaxLength(100);

    entity.Property(p => p.Status)
        .IsRequired();

    entity.HasOne(p => p.User)
        .WithMany()
        .HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.Restrict);

    entity.HasOne(p => p.College)
        .WithMany()
        .HasForeignKey(p => p.CollegeId)
        .OnDelete(DeleteBehavior.Restrict);

    entity.HasOne(p => p.Approver)
        .WithMany()
        .HasForeignKey(p => p.ApprovedBy)
        .OnDelete(DeleteBehavior.Restrict);
});

// CompanyHR
modelBuilder.Entity<CompanyHR>(entity =>
{
    entity.ToTable("CompanyHRs");

    entity.HasKey(h => h.CompanyHRId);

    entity.Property(h => h.Designation)
        .HasMaxLength(100);

    entity.HasOne(h => h.User)
        .WithMany()
        .HasForeignKey(h => h.UserId)
        .OnDelete(DeleteBehavior.Restrict);

    entity.HasOne(h => h.Company)
        .WithMany()
        .HasForeignKey(h => h.CompanyId)
        .OnDelete(DeleteBehavior.Restrict);

    entity.HasOne(h => h.Approver)
        .WithMany()
        .HasForeignKey(h => h.ApprovedBy)
        .OnDelete(DeleteBehavior.Restrict);
});

// Student
modelBuilder.Entity<Student>(entity =>
{
    entity.ToTable("Students");

    entity.HasKey(s => s.StudentId);

    entity.Property(s => s.RegisterNumber)
        .IsRequired()
        .HasMaxLength(50);

    entity.HasIndex(s => new { s.CollegeId, s.RegisterNumber })
        .IsUnique();

    entity.Property(s => s.Department)
        .IsRequired()
        .HasMaxLength(100);

    entity.Property(s => s.Degree)
        .IsRequired()
        .HasMaxLength(100);

    entity.Property(s => s.GraduationYear)
        .IsRequired();

    entity.Property(s => s.CGPA)
        .HasPrecision(4, 2)
        .IsRequired();

    entity.Property(s => s.ActiveBacklogs)
        .IsRequired();

    entity.Property(s => s.ResumeUrl)
        .HasMaxLength(500);

    entity.Property(s => s.Status)
        .IsRequired();

    entity.HasOne(s => s.User)
        .WithMany()
        .HasForeignKey(s => s.UserId)
        .OnDelete(DeleteBehavior.Restrict);

    entity.HasOne(s => s.College)
        .WithMany()
        .HasForeignKey(s => s.CollegeId)
        .OnDelete(DeleteBehavior.Restrict);

    entity.HasOne(s => s.PlacementOfficer)
        .WithMany()
        .HasForeignKey(s => s.PlacementOfficerId)
        .OnDelete(DeleteBehavior.Restrict);
});

// JobOpening Configuration
modelBuilder.Entity<JobOpening>(entity =>
{
    entity.ToTable("JobOpenings");

    entity.HasKey(j => j.JobId);

    entity.Property(j => j.JobTitle)
        .IsRequired()
        .HasMaxLength(200);

    entity.Property(j => j.JobDescription)
        .IsRequired();

    entity.Property(j => j.JobType)
        .IsRequired()
        .HasMaxLength(50);

    entity.Property(j => j.Location)
        .IsRequired()
        .HasMaxLength(200);

    entity.Property(j => j.SalaryPackage)
        .HasPrecision(12, 2);

    entity.Property(j => j.MinimumCGPA)
        .HasPrecision(4, 2);

    entity.Property(j => j.ApplicationDeadline)
        .IsRequired();

    entity.Property(j => j.IsOpenToAllColleges)
        .IsRequired();

    entity.Property(j => j.Status)
        .IsRequired();

    entity.Property(j => j.CreatedAt)
        .IsRequired();

    entity.HasOne(j => j.Company)
        .WithMany()
        .HasForeignKey(j => j.CompanyId)
        .OnDelete(DeleteBehavior.Restrict);

    entity.HasOne(j => j.CreatedByHR)
        .WithMany()
        .HasForeignKey(j => j.CreatedByHRId)
        .OnDelete(DeleteBehavior.Restrict);
});


// JobTargetCollege Configuration
modelBuilder.Entity<JobTargetCollege>(entity =>
{
    entity.ToTable("JobTargetColleges");

    entity.HasKey(j => j.JobTargetCollegeId);

    entity.HasOne(j => j.JobOpening)
        .WithMany(j => j.TargetColleges)
        .HasForeignKey(j => j.JobId)
        .OnDelete(DeleteBehavior.Restrict);

    entity.HasOne(j => j.College)
        .WithMany()
        .HasForeignKey(j => j.CollegeId)
        .OnDelete(DeleteBehavior.Restrict);
});


// JobApplication Configuration
modelBuilder.Entity<JobApplication>(entity =>
{
    entity.ToTable("JobApplications");

    entity.HasKey(a => a.ApplicationId);

    entity.Property(a => a.AppliedAt)
        .IsRequired();

    entity.Property(a => a.Status)
        .IsRequired();

    entity.Property(a => a.ResumeUrl)
        .HasMaxLength(500);

    entity.Property(a => a.LastUpdatedAt)
        .IsRequired();

    entity.HasIndex(a => new { a.StudentId, a.JobId })
        .IsUnique();

    entity.HasOne(a => a.JobOpening)
        .WithMany(j => j.Applications)
        .HasForeignKey(a => a.JobId)
        .OnDelete(DeleteBehavior.Restrict);

    entity.HasOne(a => a.Student)
        .WithMany()
        .HasForeignKey(a => a.StudentId)
        .OnDelete(DeleteBehavior.Restrict);
});

// RecruitmentDrive Configuration
modelBuilder.Entity<RecruitmentDrive>(entity =>
{
    entity.ToTable("RecruitmentDrives");

    entity.HasKey(r => r.DriveId);

    entity.Property(r => r.DriveDate)
        .IsRequired();

    entity.Property(r => r.Venue)
        .HasMaxLength(255);

    entity.Property(r => r.Description)
        .IsRequired(false);

    entity.Property(r => r.Status)
        .IsRequired();

    entity.HasOne(r => r.JobOpening)
        .WithMany()
        .HasForeignKey(r => r.JobId)
        .OnDelete(DeleteBehavior.Restrict);

    entity.HasOne(r => r.College)
        .WithMany()
        .HasForeignKey(r => r.CollegeId)
        .OnDelete(DeleteBehavior.Restrict);
});


// InterviewRound Configuration
modelBuilder.Entity<InterviewRound>(entity =>
{
    entity.ToTable("InterviewRounds");

    entity.HasKey(i => i.InterviewRoundId);

    entity.Property(i => i.RoundName)
        .IsRequired()
        .HasMaxLength(100);

    entity.Property(i => i.RoundNumber)
        .IsRequired();

    entity.Property(i => i.Description)
        .IsRequired(false);

    entity.HasOne(i => i.JobOpening)
        .WithMany()
        .HasForeignKey(i => i.JobId)
        .OnDelete(DeleteBehavior.Restrict);
});


// InterviewSchedule Configuration
modelBuilder.Entity<InterviewSchedule>(entity =>
{
    entity.ToTable("InterviewSchedules");

    entity.HasKey(i => i.InterviewScheduleId);

    entity.Property(i => i.ScheduledAt)
        .IsRequired();

    entity.Property(i => i.MeetingLink)
        .HasMaxLength(500);

    entity.Property(i => i.Venue)
        .HasMaxLength(255);

    entity.Property(i => i.Status)
        .IsRequired();

    entity.Property(i => i.Feedback)
        .IsRequired(false);

    entity.HasOne(i => i.JobApplication)
        .WithMany()
        .HasForeignKey(i => i.ApplicationId)
        .OnDelete(DeleteBehavior.Restrict);

    entity.HasOne(i => i.InterviewRound)
        .WithMany()
        .HasForeignKey(i => i.InterviewRoundId)
        .OnDelete(DeleteBehavior.Restrict);
});
modelBuilder.Entity<ApplicationStatusHistory>(entity =>
{
    entity.HasKey(h => h.HistoryId);

    entity.Property(h => h.Remarks)
        .HasMaxLength(500);

    entity.Property(h => h.PreviousStatus)
        .HasConversion<string>();

    entity.Property(h => h.NewStatus)
        .IsRequired()
        .HasConversion<string>();

    entity.Property(h => h.UpdatedAt)
        .IsRequired();

    entity.HasOne(h => h.JobApplication)
        .WithMany()
        .HasForeignKey(h => h.ApplicationId)
        .OnDelete(DeleteBehavior.Restrict);

    entity.HasOne(h => h.UpdatedByUser)
        .WithMany()
        .HasForeignKey(h => h.UpdatedByUserId)
        .OnDelete(DeleteBehavior.Restrict);
});

    }
}
