using System;
using System.Collections.Generic;
using gdsmx_back_netcoreAPI.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace gdsmx_back_netcoreAPI.Models
{
    public partial class sdgmxdemosqldbContext : DbContext
    {
        public sdgmxdemosqldbContext()
        {
        }

        public sdgmxdemosqldbContext(DbContextOptions<sdgmxdemosqldbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BadgeCategory> BadgeCategories { get; set; } = null!;
        public virtual DbSet<BadgeCourse> BadgeCourses { get; set; } = null!;
        public virtual DbSet<BadgeCourseEmployee> BadgeCourseEmployees { get; set; } = null!;
        public virtual DbSet<BadgeDomain> BadgeDomains { get; set; } = null!;
        public virtual DbSet<BadgeLevel> BadgeLevels { get; set; } = null!;
        public virtual DbSet<BadgeStatus> BadgeStatuses { get; set; } = null!;
        public virtual DbSet<BadgeSubDomain> BadgeSubDomains { get; set; } = null!;
        public virtual DbSet<BadgeTopic> BadgeTopics { get; set; } = null!;
        public virtual DbSet<CompetenciesCatalog> CompetenciesCatalogs { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeLevel> EmployeeLevels { get; set; } = null!;
        public virtual DbSet<Engagement> Engagements { get; set; } = null!;
        public virtual DbSet<FiscalYear> FiscalYears { get; set; } = null!;
        public virtual DbSet<GenericCatalog> GenericCatalogs { get; set; } = null!;
        public virtual DbSet<GenericSubCatalog> GenericSubCatalogs { get; set; } = null!;
        public virtual DbSet<LevelCatalog> LevelCatalogs { get; set; } = null!;
        public virtual DbSet<LevelSubCatalog> LevelSubCatalogs { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<PersonSegmentCatalog> PersonSegmentCatalogs { get; set; } = null!;
        public virtual DbSet<DataEmployee> DataEmployees { get; set; } = null!;
        public virtual DbSet<DataEmployeeSkill> DataEmployeeSkills { get; set; } = null!;
        public virtual DbSet<DataEmployeeBadge> DataEmployeeBadge { get; set; } = null!;
        public virtual DbSet<DataEmployeeCertification> DataEmployeeCertification { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Context for SP_GetEmployee
            modelBuilder.Entity<DataEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdEmployee);
                entity.Property(e => e.GPN);
                entity.Property(e => e.FirstName);
                entity.Property(e => e.MiddleName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.SecondLastName);
                entity.Property(e => e.Birthdate);
                entity.Property(e => e.JoinedDate);
                entity.Property(e => e.Email);
                entity.Property(e => e.Counselor);
                entity.Property(e => e.Location);
                entity.Property(e => e.PersonSegment);
                entity.Property(e => e.Competency);
                entity.Property(e => e.Status);
                entity.Property(e => e.Rank);
                entity.Property(e => e.Level);
                entity.Property(e => e.Grade);
                entity.Property(e => e.Notes);
            });

            //Context for SP_GetEmployeeSkill
            modelBuilder.Entity<DataEmployeeSkill>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdEmployee);
                entity.Property(e => e.GPN);
                entity.Property(e => e.FirstName);
                entity.Property(e => e.MiddleName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.SecondLastName);
                entity.Property(e => e.DescriptionSkill);
                entity.Property(e => e.IsPrimarySkill);
                entity.Property(e => e.DescriptionRank);
            });

            // Context for SP_GetEmployeeBadge
            modelBuilder.Entity<DataEmployeeBadge>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdEmployee);
                entity.Property(e => e.DescriptionStatus);
                entity.Property(e => e.DescriptionLevel);
                entity.Property(e => e.DescriptionCourse);
                entity.Property(e => e.DescriptionCategory);
                entity.Property(e => e.DescriptionTopic);
                entity.Property(e => e.DescriptionSubDomain);
                entity.Property(e => e.DescriptionDomain);
                entity.Property(e => e.FirstName);
                entity.Property(e => e.MiddleName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.SecondLastName);
            });

            //Context for SP_GetEmployeeCertification
            modelBuilder.Entity<DataEmployeeCertification>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdEmployee);
                entity.Property(e => e.GPN);
                entity.Property(e => e.FirstName);
                entity.Property(e => e.MiddleName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.SecondLastName);
                entity.Property(e => e.Description);
                entity.Property(e => e.ObtainedDate);
                entity.Property(e => e.ExpirationDate);
            });

            modelBuilder.Entity<BadgeCategory>(entity =>
            {
                entity.HasKey(e => e.IdBadgeCategory);

                entity.ToTable("BadgeCategory");

                entity.HasComment("Badge category");

                entity.Property(e => e.IdBadgeCategory).HasComment("Id of the table");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date of the row");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasComment("Description");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Indicate if the row is active");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");
            });

            modelBuilder.Entity<BadgeCourse>(entity =>
            {
                entity.HasKey(e => e.IdBadgeCourse);

                entity.ToTable("BadgeCourse");

                entity.HasComment("Badge courses");

                entity.Property(e => e.IdBadgeCourse).HasComment("Id of the table");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Description of the course");

                entity.Property(e => e.IdBadgeDomain).HasComment("Id of the domain");

                entity.Property(e => e.IdBadgeLevel).HasComment("Id of the level of the badge");

                entity.Property(e => e.IdBadgeSubDomain).HasComment("Id of the subdomain");

                entity.Property(e => e.IdBadgeTopic).HasComment("Id of the topic");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Indicate if the row is active");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");

                entity.HasOne(d => d.IdBadgeDomainNavigation)
                    .WithMany(p => p.BadgeCourses)
                    .HasForeignKey(d => d.IdBadgeDomain)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BadgeCourse_BadgeDomain");

                entity.HasOne(d => d.IdBadgeLevelNavigation)
                    .WithMany(p => p.BadgeCourses)
                    .HasForeignKey(d => d.IdBadgeLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BadgeCourse_BadgeLevel");

                entity.HasOne(d => d.IdBadgeSubDomainNavigation)
                    .WithMany(p => p.BadgeCourses)
                    .HasForeignKey(d => d.IdBadgeSubDomain)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BadgeCourse_BadgeSubDomain");

                entity.HasOne(d => d.IdBadgeTopicNavigation)
                    .WithMany(p => p.BadgeCourses)
                    .HasForeignKey(d => d.IdBadgeTopic)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BadgeCourse_BadgeTopic");
            });

            modelBuilder.Entity<BadgeCourseEmployee>(entity =>
            {
                entity.HasKey(e => e.IdBadgeCourseEmployee);

                entity.ToTable("BadgeCourseEmployee");

                entity.HasComment("Relation between the badge courses and the employee");

                entity.Property(e => e.IdBadgeCourseEmployee).HasComment("Id principal of the table");

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasComment("Comments");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasComment("End date of the badge");

                entity.Property(e => e.IdBadgeCourse).HasComment("Id of the course");

                entity.Property(e => e.IdBadgeDomain).HasComment("Id of the domain");

                entity.Property(e => e.IdBadgeLevel).HasComment("Id fo the level of the badge");

                entity.Property(e => e.IdBadgeStatus).HasComment("Id of the status ");

                entity.Property(e => e.IdBadgeSubDomain).HasComment("Id of the subdomain");

                entity.Property(e => e.IdBadgeTopic).HasComment("Id of the topic");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdEmployee).HasComment("Id of the employee");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasComment("Start date of the badge");

                entity.HasOne(d => d.IdBadgeCourseNavigation)
                    .WithMany(p => p.BadgeCourseEmployees)
                    .HasForeignKey(d => d.IdBadgeCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BadgeCourseEmployee_BadgeCourse");

                entity.HasOne(d => d.IdBadgeDomainNavigation)
                    .WithMany(p => p.BadgeCourseEmployees)
                    .HasForeignKey(d => d.IdBadgeDomain)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BadgeCourseEmployee_BadgeDomain");

                entity.HasOne(d => d.IdBadgeLevelNavigation)
                    .WithMany(p => p.BadgeCourseEmployees)
                    .HasForeignKey(d => d.IdBadgeLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BadgeCourseEmployee_BadgeLevel");

                entity.HasOne(d => d.IdBadgeStatusNavigation)
                    .WithMany(p => p.BadgeCourseEmployees)
                    .HasForeignKey(d => d.IdBadgeStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BadgeCourseEmployee_BadgeStatus");

                entity.HasOne(d => d.IdBadgeSubDomainNavigation)
                    .WithMany(p => p.BadgeCourseEmployees)
                    .HasForeignKey(d => d.IdBadgeSubDomain)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BadgeCourseEmployee_BadgeSubDomain");

                entity.HasOne(d => d.IdBadgeTopicNavigation)
                    .WithMany(p => p.BadgeCourseEmployees)
                    .HasForeignKey(d => d.IdBadgeTopic)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BadgeCourseEmployee_BadgeTopic");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.BadgeCourseEmployees)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BadgeCourseEmployee_Employee");
            });

            modelBuilder.Entity<BadgeDomain>(entity =>
            {
                entity.HasKey(e => e.IdBadgeDomain);

                entity.ToTable("BadgeDomain");

                entity.HasComment("Badge Domain");

                entity.Property(e => e.IdBadgeDomain).HasComment("Id of the table");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Description of the domain");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Indicate if the row is active");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");
            });

            modelBuilder.Entity<BadgeLevel>(entity =>
            {
                entity.HasKey(e => e.IdBadgeLevel);

                entity.ToTable("BadgeLevel");

                entity.HasComment("Badge Level");

                entity.Property(e => e.IdBadgeLevel).HasComment("Id of the table");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Description of the level");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Indicate if the row is active");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");
            });

            modelBuilder.Entity<BadgeStatus>(entity =>
            {
                entity.HasKey(e => e.IdBadgeStatus);

                entity.ToTable("BadgeStatus");

                entity.HasComment("Badge Status");

                entity.Property(e => e.IdBadgeStatus).HasComment("Id of the table");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Description of the status");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Indicate if the row is active");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");
            });

            modelBuilder.Entity<BadgeSubDomain>(entity =>
            {
                entity.HasKey(e => e.IdBadgeSubDomain);

                entity.ToTable("BadgeSubDomain");

                entity.HasComment("Badge Subdomain");

                entity.Property(e => e.IdBadgeSubDomain).HasComment("Id of the table");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Description of the subdomain");

                entity.Property(e => e.IdBadgeDomain).HasComment("Id of the domain");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Indicate if the row is active");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");

                entity.HasOne(d => d.IdBadgeDomainNavigation)
                    .WithMany(p => p.BadgeSubDomains)
                    .HasForeignKey(d => d.IdBadgeDomain)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BadgeSubDomain_BadgeDomain");
            });

            modelBuilder.Entity<BadgeTopic>(entity =>
            {
                entity.HasKey(e => e.IdBadgeTopic);

                entity.ToTable("BadgeTopic");

                entity.HasComment("Badge Topic");

                entity.Property(e => e.IdBadgeTopic).HasComment("Id of the table");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Description of the topic");

                entity.Property(e => e.IdBadgeCategory).HasComment("Id of the category");

                entity.Property(e => e.IdBadgeDomain).HasComment("Id of the domain");

                entity.Property(e => e.IdBadgeSubDomain).HasComment("Id of the subdomain");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Indicate if the row is active");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");

                entity.HasOne(d => d.IdBadgeCategoryNavigation)
                    .WithMany(p => p.BadgeTopics)
                    .HasForeignKey(d => d.IdBadgeCategory)
                    .HasConstraintName("FK_BadgeTopic_BadgeCategory");

                entity.HasOne(d => d.IdBadgeDomainNavigation)
                    .WithMany(p => p.BadgeTopics)
                    .HasForeignKey(d => d.IdBadgeDomain)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BadgeTopic_BadgeDomain");

                entity.HasOne(d => d.IdBadgeSubDomainNavigation)
                    .WithMany(p => p.BadgeTopics)
                    .HasForeignKey(d => d.IdBadgeSubDomain)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BadgeTopic_BadgeSubDomain");
            });

            modelBuilder.Entity<CompetenciesCatalog>(entity =>
            {
                entity.HasKey(e => e.IdCompetencyCatalog)
                    .HasName("PK_Competencies");

                entity.ToTable("CompetenciesCatalog");

                entity.HasComment("Catalog of competencies");

                entity.Property(e => e.IdCompetencyCatalog).HasComment("Id of the competency");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date of the row");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasComment("Name of the competency");

                entity.Property(e => e.IdCreated).HasComment("Id of the user who created the row");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Indicate if the compentecy is active");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdCountry);

                entity.ToTable("Country");

                entity.HasComment("Country");

                entity.Property(e => e.IdCountry).HasComment("Id of the country");

                entity.Property(e => e.Acronym)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasComment("Acronym of the country");

                entity.Property(e => e.Country1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Country")
                    .HasComment("Name of the country");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("date")
                    .HasComment("Last updated date");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);

                entity.ToTable("Employee");

                entity.HasComment("Principal table of the employee");

                entity.Property(e => e.IdEmployee).HasComment("Id Employee");

                entity.Property(e => e.BirthdateDay)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("Day of the birthdate");

                entity.Property(e => e.BirthdateMonth)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Month of the birthdate");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date of the row");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasComment("Email of the employee");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("First name of the employee");

                entity.Property(e => e.Gpn)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GPN")
                    .HasComment("GPN number");

                entity.Property(e => e.IdCompetency).HasComment("Competency of the employee");

                entity.Property(e => e.IdCounselor).HasComment("Id of the counselor");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdLocation).HasComment("Id of the location of the office");

                entity.Property(e => e.IdPersonSegment).HasComment("Id of the person segment catalog");

                entity.Property(e => e.IdStatus).HasComment("Status of the employee");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Indicate if the row is active");

                entity.Property(e => e.IsCounselor).HasComment("Indicate if the employee is a counselor");

                entity.Property(e => e.JoinedDate)
                    .HasColumnType("date")
                    .HasComment("Joined date of the employee on the firm");

                entity.Property(e => e.LastName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Last name of the employee");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Middle name of the employee");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasComment("Notes");

                entity.Property(e => e.PreferredName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Prefered name of the employee");

                entity.Property(e => e.SecondLastName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Second lastname");

                entity.HasOne(d => d.IdCompetencyNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdCompetency)
                    .HasConstraintName("FK_Employee_CompetenciesCatalog");

                entity.HasOne(d => d.IdPersonSegmentNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdPersonSegment)
                    .HasConstraintName("FK_Employee_PersonSegmentCatalog");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK_Employee_GenericSubCatalog");
            });

            modelBuilder.Entity<EmployeeLevel>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);

                entity.ToTable("EmployeeLevel");

                entity.HasComment("Relation between all the levels of one employee on the time");

                entity.Property(e => e.IdEmployee)
                    .ValueGeneratedOnAdd()
                    .HasComment("Id Employee");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date of the row");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdLevel).HasComment("Id Level Catalog");

                entity.Property(e => e.IdLevelSub).HasComment("Id of the sub level of the employee");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Indicate if the row is active");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithOne(p => p.EmployeeLevel)
                    .HasForeignKey<EmployeeLevel>(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeLevel_Employee");

                entity.HasOne(d => d.IdLevelNavigation)
                    .WithMany(p => p.EmployeeLevels)
                    .HasForeignKey(d => d.IdLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeLevel_LevelCatalog");

                entity.HasOne(d => d.IdLevelSubNavigation)
                    .WithMany(p => p.EmployeeLevels)
                    .HasForeignKey(d => d.IdLevelSub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeLevel_LevelSubCatalog");
            });

            modelBuilder.Entity<Engagement>(entity =>
            {
                entity.HasKey(e => e.IdEngagement);

                entity.ToTable("Engagement");

                entity.HasComment("Indicates all the engagement of the employee");

                entity.Property(e => e.IdEngagement).HasComment("Id of the engagement");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date of the row");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasComment("Name of the engagement");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasComment("Ending date of the engagement");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdEmployee).HasComment("Id employee");

                entity.Property(e => e.IdParent).HasComment("Id of the previous engagement");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive).HasComment("Is active the row");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasComment("Starting date of the engagement");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Engagements)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Engagement_Employee");

                entity.HasOne(d => d.IdParentNavigation)
                    .WithMany(p => p.InverseIdParentNavigation)
                    .HasForeignKey(d => d.IdParent)
                    .HasConstraintName("FK_Engagement_Engagement");
            });

            modelBuilder.Entity<FiscalYear>(entity =>
            {
                entity.HasKey(e => e.IdFiscalYear)
                    .HasName("PK_Fiscal Year");

                entity.ToTable("FiscalYear");

                entity.HasComment("Fiscal year management");

                entity.Property(e => e.IdFiscalYear).HasComment("Id of the table");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasComment("End date of the year");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdLocation).HasComment("Id of the location");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive).HasComment("Indicate if the row is active");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasComment("Start date of the year");
            });

            modelBuilder.Entity<GenericCatalog>(entity =>
            {
                entity.HasKey(e => e.IdGenericCatalog)
                    .HasName("PK_Catalog");

                entity.ToTable("GenericCatalog");

                entity.HasComment("Principal table of the generic catalog");

                entity.Property(e => e.IdGenericCatalog).HasComment("Id Catalog");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("Comments about the new catalog");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Description of the catalog");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Is active the row");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");
            });

            modelBuilder.Entity<GenericSubCatalog>(entity =>
            {
                entity.HasKey(e => e.IdGenericSubCatalog)
                    .HasName("PK_SubCatalog");

                entity.ToTable("GenericSubCatalog");

                entity.HasComment("Sub category of the principal catalog");

                entity.Property(e => e.IdGenericSubCatalog).HasComment("Id Sub-catalog");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Description of the sub-catalog");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdGenericCatalog).HasComment("Id catalog");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Indicate if the row is active");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");

                entity.Property(e => e.Position).HasComment("Order of the sub-catalog");

                entity.HasOne(d => d.IdGenericCatalogNavigation)
                    .WithMany(p => p.GenericSubCatalogs)
                    .HasForeignKey(d => d.IdGenericCatalog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCatalog_Catalog");
            });

            modelBuilder.Entity<LevelCatalog>(entity =>
            {
                entity.HasKey(e => e.IdLevelCatalog);

                entity.ToTable("LevelCatalog");

                entity.HasComment("Level catalog of the employee");

                entity.Property(e => e.IdLevelCatalog).HasComment("Id Level Catalog");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Create date of the row");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Indicate if the row is active");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");

                entity.Property(e => e.Level)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Level");

                entity.Property(e => e.Rank).HasComment("Rank");
            });

            modelBuilder.Entity<LevelSubCatalog>(entity =>
            {
                entity.HasKey(e => e.IdLevelSubCatalog);

                entity.ToTable("LevelSubCatalog");

                entity.HasComment("Sub level catalog of the employee");

                entity.Property(e => e.IdLevelSubCatalog).HasComment("Id of the catalog");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date of the row");

                entity.Property(e => e.Grade)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Grade");

                entity.Property(e => e.IdCreated).HasComment("Id who create the row");

                entity.Property(e => e.IdLevelCatalog).HasComment("Id of the principal catalog (Level Catalog)");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Indicate if the row is active");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Date of the last updated day");

                entity.HasOne(d => d.IdLevelCatalogNavigation)
                    .WithMany(p => p.LevelSubCatalogs)
                    .HasForeignKey(d => d.IdLevelCatalog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LevelSubCatalog_LevelCatalog");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.IdLocation);

                entity.ToTable("Location");

                entity.HasComment("Location");

                entity.Property(e => e.IdLocation)
                    .ValueGeneratedOnAdd()
                    .HasComment("Id of the location of the office");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date");

                entity.Property(e => e.IdCountry).HasComment("Id of the country");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Indicate if the row is active");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");

                entity.Property(e => e.Location1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Location")
                    .HasComment("Location of the office");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Name of the office");

                entity.HasOne(d => d.IdLocationNavigation)
                    .WithOne(p => p.Location)
                    .HasForeignKey<Location>(d => d.IdLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Country");
            });

            modelBuilder.Entity<PersonSegmentCatalog>(entity =>
            {
                entity.HasKey(e => e.IdPersonSegmentCatalog)
                    .HasName("PK_PersonSegment");

                entity.ToTable("PersonSegmentCatalog");

                entity.HasComment("Person Segment Catalog");

                entity.Property(e => e.IdPersonSegmentCatalog).HasComment("Id of the table");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Created date of the row");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Name of the Person Segment");

                entity.Property(e => e.IdCreated).HasComment("Id of who created the row");

                entity.Property(e => e.IdUpdated).HasComment("Id of who updated the row");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Indicate if the row is active");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Last updated date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
