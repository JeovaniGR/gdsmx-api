using Microsoft.AspNetCore.Mvc;
using gdsmx_back_netcoreAPI.DTO;

namespace gdsmx_back_netcoreAPI.BL.Interfaces
{
    public interface IBLEmployee
    {
        ActionResult<IEnumerable<DataEmployee>> Get(RequestEmployee resquestEmployee);
        byte[] GetExportFile(RequestEmployeeExport resquestEmployee);
        ActionResult<IEnumerable<DataEmployeeSkill>> GetSkills(string gpn, RequestEmployeeSkill requestEmployeeSkill);
        ActionResult<IEnumerable<DataEmployeeBadge>> GetBadges(string gpn, RequestEmployeeBadge request);
        ActionResult<IEnumerable<DataEmployeeCertification>> GetCertifications(string gpn, RequestEmployeeCertification request);

        ActionResult<IEnumerable<DataEmployeeEngagement>> GetEngagements(string gpn, RequestEmployeeEngagement request);
    }
}
