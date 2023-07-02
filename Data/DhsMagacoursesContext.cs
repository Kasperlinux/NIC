using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NIC.Models;

namespace NIC.Data;

public partial class DhsMagacoursesContext : IdentityDbContext<ApplicationUser>
{
    public DhsMagacoursesContext()
    {
    }

    public DhsMagacoursesContext(DbContextOptions<DhsMagacoursesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgeEligibilityCriterion> AgeEligibilityCriteria { get; set; }

    public virtual DbSet<ApplicantsAlliedCourse> ApplicantsAlliedCourses { get; set; }

    public virtual DbSet<ApplicantsAnm> ApplicantsAnms { get; set; }

    public virtual DbSet<ApplicantsGnm> ApplicantsGnms { get; set; }

    public virtual DbSet<ApplicantsMbb> ApplicantsMbbs { get; set; }

    public virtual DbSet<MApplicationStatus> MApplicationStatuses { get; set; }

    public virtual DbSet<MApplicationType> MApplicationTypes { get; set; }

    public virtual DbSet<MBlock> MBlocks { get; set; }

    public virtual DbSet<MCategory> MCategories { get; set; }

    public virtual DbSet<MCoursesAlliedCourse> MCoursesAlliedCourses { get; set; }

    public virtual DbSet<MCoursesAnm> MCoursesAnms { get; set; }

    public virtual DbSet<MCoursesGnm> MCoursesGnms { get; set; }

    public virtual DbSet<MCoursesMbb> MCoursesMbbs { get; set; }

    public virtual DbSet<MDistrict> MDistricts { get; set; }

    public virtual DbSet<MGender> MGenders { get; set; }

    public virtual DbSet<MNationality> MNationalities { get; set; }

    public virtual DbSet<MReligion> MReligions { get; set; }

    public virtual DbSet<MScreeningCentre> MScreeningCentres { get; set; }

    public virtual DbSet<MState> MStates { get; set; }

    public virtual DbSet<MUser> MUsers { get; set; }

    public virtual DbSet<MVillage> MVillages { get; set; }

    public virtual DbSet<PreferenceAlliedCourse> PreferenceAlliedCourses { get; set; }

    public virtual DbSet<PreferenceMbb> PreferenceMbbs { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
