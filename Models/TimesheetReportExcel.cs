using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    public partial class TimesheetReportExcel
    {
        public int IdTimesheetReportExcel { get; set; }
        public string? Gpn { get; set; }
        public string? PersonName { get; set; }
        public string? PersonSegment { get; set; }
        public string? EmployeeCategory { get; set; }
        public string? Level { get; set; }
        public string? Ssl { get; set; }
        public string? ReportingSegment { get; set; }
        public string? Competency { get; set; }
        public string? SubCompetency { get; set; }
        public string? Location { get; set; }
        public string? Country { get; set; }
        public string? Span { get; set; }
        public string? CompetencyLead { get; set; }
        public string? PrimarySector { get; set; }
        public string? SubSector { get; set; }
        public string? RegularRfMs { get; set; }
        public string? PersonLocation { get; set; }
        public string? RankCode { get; set; }
        public string? RankDescription { get; set; }
        public string? DepartmentName { get; set; }
        public string? PersonBusinessUnitNumber { get; set; }
        public string? PersonBusinessUnitName { get; set; }
        public string? PersonOperatingUnitNumber { get; set; }
        public string? PersonOperatingUnitName { get; set; }
        public string? PersonManagementUnitNumber { get; set; }
        public string? PersonManagementUnitName { get; set; }
        public string? PersonSubManagementUnitNumber { get; set; }
        public string? PersonSubManagementUnitName { get; set; }
        public string? PersonCodeBlock { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountName { get; set; }
        public string? EngClientNumber { get; set; }
        public string? EngClientName { get; set; }
        public string? EngNumber { get; set; }
        public string? EngName { get; set; }
        public string? EngagementActivityCode { get; set; }
        public string? EngagementActivityName { get; set; }
        public string? Description { get; set; }
        public string? EngManagerGpn { get; set; }
        public string? EngManagerName { get; set; }
        public string? EngPartnerGpn { get; set; }
        public string? EngPartnerName { get; set; }
        public string? EngStatusCode { get; set; }
        public string? EngStatusCodeDesc { get; set; }
        public string? EngType { get; set; }
        public string? EngTypeDesc { get; set; }
        public string? Channel { get; set; }
        public string? EngBuNumber { get; set; }
        public string? EngBuName { get; set; }
        public string? EngOperatingUnitNumber { get; set; }
        public string? EngOperatingUnitDesc { get; set; }
        public string? EngMgmtUnitNumber { get; set; }
        public string? EngMgmtUnitName { get; set; }
        public string? EngSubMgmtUnitNumber { get; set; }
        public string? EngSubMgmtUnitDesc { get; set; }
        public string? EngCodeBlock { get; set; }
        public string? EngServiceCode { get; set; }
        public string? EngServiceCodeDesc { get; set; }
        public string? EngGlobalServiceCode { get; set; }
        public string? EngGlobalServiceDesc { get; set; }
        public string? ServiceLine { get; set; }
        public string? ServiceLineDescription { get; set; }
        public string? SubServiceLine { get; set; }
        public string? SubServiceLineDesc { get; set; }
        public string? PriorityAccountCategoryCodeDesc { get; set; }
        public string? ClientIndustryCode { get; set; }
        public string? ClientIndustryDesc { get; set; }
        public string? ClientIndustrySectorCode { get; set; }
        public string? ClientIndustrySectorDesc { get; set; }
        public string? ClientIndustrySubSectorCode { get; set; }
        public string? ClientIndustrySubSectorDesc { get; set; }
        public string? Category { get; set; }
        public string? SubCategory { get; set; }
        public string? Area { get; set; }
        public string? Country2 { get; set; }
        public string? Region { get; set; }
        public string? SegmentEng { get; set; }
        public string? EaseOrNonEase { get; set; }
        public string? PeriodEndingDate { get; set; }
        public string? TransactionDate { get; set; }
        public string? FinancialYear { get; set; }
        public string? ChargedHours { get; set; }
        public string? FiscalYear { get; set; }
        public string? PdMonth { get; set; }
        public string? TdMonth { get; set; }
        public string? TdWeek { get; set; }
        public string? PdWeek { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
