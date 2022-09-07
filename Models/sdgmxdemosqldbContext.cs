using System;
using System.Collections.Generic;
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

        public virtual DbSet<Catalog> Catalogs { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<SubCatalog> SubCatalogs { get; set; } = null!;
        public virtual DbSet<TimesheetReportExcel> TimesheetReportExcels { get; set; } = null!;

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.HasKey(e => e.IdCatalog);

                entity.ToTable("Catalog");

                entity.Property(e => e.IdCatalog).HasComment("Id Catalog");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Description of the catalog");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Is active the row");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);

                entity.ToTable("Employee");

                entity.HasIndex(e => e.Gpn, "IX_Employee_GPN");

                entity.Property(e => e.IdEmployee).HasComment("Id Employee");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasComment("Birthdate");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date of the row");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("First name of the employee");

                entity.Property(e => e.Gpn)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GPN")
                    .HasComment("GPN number");

                entity.Property(e => e.JoinedDate)
                    .HasColumnType("date")
                    .HasComment("Joined date of the employee on the firm");

                entity.Property(e => e.LastName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Last name of the employee");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Middle name of the employee");
            });

            modelBuilder.Entity<SubCatalog>(entity =>
            {
                entity.HasKey(e => e.IdSubCatalog);

                entity.ToTable("SubCatalog");

                entity.Property(e => e.IdSubCatalog).HasComment("Id Sub-catalog");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Creation date");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComment("Description of the sub-catalog");

                entity.Property(e => e.IdCatalog).HasComment("Id catalog");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Order).HasComment("Order of the sub-catalog");

                entity.HasOne(d => d.IdCatalogNavigation)
                    .WithMany(p => p.SubCatalogs)
                    .HasForeignKey(d => d.IdCatalog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCatalog_Catalog");
            });

            modelBuilder.Entity<TimesheetReportExcel>(entity =>
            {
                entity.HasKey(e => e.IdTimesheetReportExcel);

                entity.ToTable("TimesheetReportExcel");

                entity.Property(e => e.AccountName)
                    .HasColumnType("text")
                    .HasColumnName("Account_Name");

                entity.Property(e => e.AccountNumber)
                    .HasColumnType("text")
                    .HasColumnName("Account_Number");

                entity.Property(e => e.Area).HasColumnType("text");

                entity.Property(e => e.Category).HasColumnType("text");

                entity.Property(e => e.Channel).HasColumnType("text");

                entity.Property(e => e.ChargedHours)
                    .HasColumnType("text")
                    .HasColumnName("Charged_Hours");

                entity.Property(e => e.ClientIndustryCode)
                    .HasColumnType("text")
                    .HasColumnName("Client_Industry_Code");

                entity.Property(e => e.ClientIndustryDesc)
                    .HasColumnType("text")
                    .HasColumnName("Client_Industry_Desc");

                entity.Property(e => e.ClientIndustrySectorCode)
                    .HasColumnType("text")
                    .HasColumnName("Client_Industry_Sector_Code");

                entity.Property(e => e.ClientIndustrySectorDesc)
                    .HasColumnType("text")
                    .HasColumnName("Client_Industry_Sector_Desc");

                entity.Property(e => e.ClientIndustrySubSectorCode)
                    .HasColumnType("text")
                    .HasColumnName("Client_Industry_Sub_Sector_Code");

                entity.Property(e => e.ClientIndustrySubSectorDesc)
                    .HasColumnType("text")
                    .HasColumnName("Client_Industry_Sub_Sector_Desc");

                entity.Property(e => e.Competency).HasColumnType("text");

                entity.Property(e => e.CompetencyLead)
                    .HasColumnType("text")
                    .HasColumnName("Competency_Lead");

                entity.Property(e => e.Country).HasColumnType("text");

                entity.Property(e => e.Country2).HasColumnType("text");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartmentName)
                    .HasColumnType("text")
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.EaseOrNonEase)
                    .HasColumnType("text")
                    .HasColumnName("Ease_OR_Non_Ease");

                entity.Property(e => e.EmployeeCategory)
                    .HasColumnType("text")
                    .HasColumnName("Employee_Category");

                entity.Property(e => e.EngBuName)
                    .HasColumnType("text")
                    .HasColumnName("Eng_BU_Name");

                entity.Property(e => e.EngBuNumber)
                    .HasColumnType("text")
                    .HasColumnName("Eng_BU_Number");

                entity.Property(e => e.EngClientName)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Client_Name");

                entity.Property(e => e.EngClientNumber)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Client_Number");

                entity.Property(e => e.EngCodeBlock)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Code_Block");

                entity.Property(e => e.EngGlobalServiceCode)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Global_Service_Code");

                entity.Property(e => e.EngGlobalServiceDesc)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Global_Service_Desc");

                entity.Property(e => e.EngManagerGpn)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Manager_GPN");

                entity.Property(e => e.EngManagerName)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Manager_Name");

                entity.Property(e => e.EngMgmtUnitName)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Mgmt_Unit_Name");

                entity.Property(e => e.EngMgmtUnitNumber)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Mgmt_Unit_Number");

                entity.Property(e => e.EngName)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Name");

                entity.Property(e => e.EngNumber)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Number");

                entity.Property(e => e.EngOperatingUnitDesc)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Operating_Unit_Desc");

                entity.Property(e => e.EngOperatingUnitNumber)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Operating_Unit_Number");

                entity.Property(e => e.EngPartnerGpn)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Partner_GPN");

                entity.Property(e => e.EngPartnerName)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Partner_Name");

                entity.Property(e => e.EngServiceCode)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Service_Code");

                entity.Property(e => e.EngServiceCodeDesc)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Service_Code_Desc");

                entity.Property(e => e.EngStatusCode)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Status_Code");

                entity.Property(e => e.EngStatusCodeDesc)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Status_Code_Desc");

                entity.Property(e => e.EngSubMgmtUnitDesc)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Sub_Mgmt_Unit_Desc");

                entity.Property(e => e.EngSubMgmtUnitNumber)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Sub_Mgmt_Unit_Number");

                entity.Property(e => e.EngType)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Type");

                entity.Property(e => e.EngTypeDesc)
                    .HasColumnType("text")
                    .HasColumnName("Eng_Type_Desc");

                entity.Property(e => e.EngagementActivityCode)
                    .HasColumnType("text")
                    .HasColumnName("Engagement_Activity_Code");

                entity.Property(e => e.EngagementActivityName)
                    .HasColumnType("text")
                    .HasColumnName("Engagement_Activity_Name");

                entity.Property(e => e.FinancialYear)
                    .HasColumnType("text")
                    .HasColumnName("Financial_Year");

                entity.Property(e => e.FiscalYear)
                    .HasColumnType("text")
                    .HasColumnName("Fiscal_Year");

                entity.Property(e => e.Gpn)
                    .HasColumnType("text")
                    .HasColumnName("GPN");

                entity.Property(e => e.Level).HasColumnType("text");

                entity.Property(e => e.Location).HasColumnType("text");

                entity.Property(e => e.PdMonth)
                    .HasColumnType("text")
                    .HasColumnName("PD_Month");

                entity.Property(e => e.PdWeek)
                    .HasColumnType("text")
                    .HasColumnName("PD_Week");

                entity.Property(e => e.PeriodEndingDate)
                    .HasColumnType("text")
                    .HasColumnName("Period_Ending_Date");

                entity.Property(e => e.PersonBusinessUnitName)
                    .HasColumnType("text")
                    .HasColumnName("Person_Business_Unit_Name");

                entity.Property(e => e.PersonBusinessUnitNumber)
                    .HasColumnType("text")
                    .HasColumnName("Person_Business_Unit_Number");

                entity.Property(e => e.PersonCodeBlock)
                    .HasColumnType("text")
                    .HasColumnName("Person_Code_Block");

                entity.Property(e => e.PersonLocation)
                    .HasColumnType("text")
                    .HasColumnName("Person_Location");

                entity.Property(e => e.PersonManagementUnitName)
                    .HasColumnType("text")
                    .HasColumnName("Person_Management_Unit_Name");

                entity.Property(e => e.PersonManagementUnitNumber)
                    .HasColumnType("text")
                    .HasColumnName("Person_Management_Unit_Number");

                entity.Property(e => e.PersonName)
                    .HasColumnType("text")
                    .HasColumnName("Person_Name");

                entity.Property(e => e.PersonOperatingUnitName)
                    .HasColumnType("text")
                    .HasColumnName("Person_Operating_Unit_Name");

                entity.Property(e => e.PersonOperatingUnitNumber)
                    .HasColumnType("text")
                    .HasColumnName("Person_Operating_Unit_Number");

                entity.Property(e => e.PersonSegment)
                    .HasColumnType("text")
                    .HasColumnName("Person_Segment");

                entity.Property(e => e.PersonSubManagementUnitName)
                    .HasColumnType("text")
                    .HasColumnName("Person_Sub_Management_Unit_Name");

                entity.Property(e => e.PersonSubManagementUnitNumber)
                    .HasColumnType("text")
                    .HasColumnName("Person_Sub_Management_Unit_Number");

                entity.Property(e => e.PrimarySector)
                    .HasColumnType("text")
                    .HasColumnName("Primary_Sector");

                entity.Property(e => e.PriorityAccountCategoryCodeDesc)
                    .HasColumnType("text")
                    .HasColumnName("Priority_Account_Category_Code_Desc");

                entity.Property(e => e.RankCode).HasColumnType("text");

                entity.Property(e => e.RankDescription)
                    .HasColumnType("text")
                    .HasColumnName("Rank_Description");

                entity.Property(e => e.Region).HasColumnType("text");

                entity.Property(e => e.RegularRfMs)
                    .HasColumnType("text")
                    .HasColumnName("Regular_RF_MS");

                entity.Property(e => e.ReportingSegment)
                    .HasColumnType("text")
                    .HasColumnName("Reporting_Segment");

                entity.Property(e => e.SegmentEng)
                    .HasColumnType("text")
                    .HasColumnName("Segment_Eng");

                entity.Property(e => e.ServiceLine)
                    .HasColumnType("text")
                    .HasColumnName("Service_Line");

                entity.Property(e => e.ServiceLineDescription)
                    .HasColumnType("text")
                    .HasColumnName("Service_Line_Description");

                entity.Property(e => e.Span)
                    .HasColumnType("text")
                    .HasColumnName("SPAN");

                entity.Property(e => e.Ssl)
                    .HasColumnType("text")
                    .HasColumnName("SSL");

                entity.Property(e => e.SubCategory)
                    .HasColumnType("text")
                    .HasColumnName("Sub_Category");

                entity.Property(e => e.SubCompetency)
                    .HasColumnType("text")
                    .HasColumnName("Sub__Competency");

                entity.Property(e => e.SubSector)
                    .HasColumnType("text")
                    .HasColumnName("Sub_Sector");

                entity.Property(e => e.SubServiceLine)
                    .HasColumnType("text")
                    .HasColumnName("Sub_Service_Line");

                entity.Property(e => e.SubServiceLineDesc)
                    .HasColumnType("text")
                    .HasColumnName("Sub_Service_Line_Desc");

                entity.Property(e => e.TdMonth)
                    .HasColumnType("text")
                    .HasColumnName("TD_Month");

                entity.Property(e => e.TdWeek)
                    .HasColumnType("text")
                    .HasColumnName("TD_Week");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("text")
                    .HasColumnName("Transaction_Date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
