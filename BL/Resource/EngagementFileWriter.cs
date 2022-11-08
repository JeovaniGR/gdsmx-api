using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using gdsmx_back_netcoreAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System.Text;
using gdsmx_back_netcoreAPI.BL.Interfaces;

namespace gdsmx_back_netcoreAPI.BL.Resource
{
    public class EngagementFileWriter: IExcelWriter<DataEmployeeEngagement>, ICSVWriter<DataEmployeeEngagement>
    {
        private readonly List<string> header = new List<string>()
        {
            "GPN",
            "First Name",
            "Middle Name",
            "Last Name",
            "Second LastName",
            "Engagement Id",
            "Customer Name",
            "Project Name",
            "Engagement Hours",
            "Cancelation Date",
            "Comments",
            "Start Date",
            "End Date",            
            "Project Manager Name",
            "Project Manager Email",
            "Status Description",
            "Days Before End",
            "Weeks Before End"
        };

        public byte[] WriteToCSV(List<DataEmployeeEngagement> values)
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Join(",", header));

            foreach(var item in values)
            {
                sb.AppendLine(
                    $"{item.GPN}," +
                    $"{item.FirstName}," +
                    $"{item.MiddleName}," +
                    $"{item.LastName}," +
                    $"{item.SecondLastName}," +
                    $"{item.EngagementId}," +
                    $"{item.CustomerName}," +
                    $"{item.ProjectName}," +
                    $"{item.EngagementHours}," +
                    $"{(item.CancelationDate.Year == 1900 ? string.Empty : item.CancelationDate.ToShortDateString())}," +
                    $"\"{item.Comments}\"," +
                    $"{item.StartDate.ToShortDateString()}," +
                    $"{item.EndDate.ToShortDateString()}," +
                    $"{item.ProjectManagerName}," +
                    $"{item.ProjectManagerEmail}," +
                    $"{item.StatusDescription}," +
                    $"{item.DaysBeforeEnd}," +
                    $"{item.WeeksBeforeEnd}");
            }

            return Encoding.GetEncoding("Windows-1252").GetBytes(sb.ToString());
        }

        public byte[] WriteToExcel(List<DataEmployeeEngagement> values)
        {
            using (var workExcel = new XLWorkbook())
            {
                var worksheet = workExcel.Worksheets.Add("Engagement");
                var currentRow = 1;

                foreach(var (headerValue, index) in header.Select((value, i) => (value, i)))
                {
                    worksheet.Cell(currentRow, index + 1).Value = headerValue;
                }

                var range = worksheet.Range("A1:R1");
                range.Style.Font.FontSize = 12;
                range.Style.Font.Bold = true;
                range.Style.Fill.BackgroundColor = XLColor.PastelGray;

                foreach (var employeeEngagement in values)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = employeeEngagement.GPN;
                    worksheet.Cell(currentRow, 2).Value = employeeEngagement.FirstName;
                    worksheet.Cell(currentRow, 3).Value = employeeEngagement.MiddleName;
                    worksheet.Cell(currentRow, 4).Value = employeeEngagement.LastName;
                    worksheet.Cell(currentRow, 5).Value = employeeEngagement.SecondLastName;
                    worksheet.Cell(currentRow, 6).Value = employeeEngagement.EngagementId;
                    worksheet.Cell(currentRow, 7).Value = employeeEngagement.CustomerName;
                    worksheet.Cell(currentRow, 8).Value = employeeEngagement.ProjectName;
                    worksheet.Cell(currentRow, 9).Value = employeeEngagement.EngagementHours;
                    worksheet.Cell(currentRow, 10).Value = (employeeEngagement.CancelationDate.Year == 1900 ? string.Empty : employeeEngagement.CancelationDate);
                    worksheet.Cell(currentRow, 11).Value = employeeEngagement.Comments;
                    worksheet.Cell(currentRow, 12).Value = employeeEngagement.StartDate;
                    worksheet.Cell(currentRow, 13).Value = employeeEngagement.EndDate;
                    worksheet.Cell(currentRow, 14).Value = employeeEngagement.ProjectManagerName;
                    worksheet.Cell(currentRow, 15).Value = employeeEngagement.ProjectManagerEmail;
                    worksheet.Cell(currentRow, 16).Value = employeeEngagement.StatusDescription;
                    worksheet.Cell(currentRow, 17).Value = employeeEngagement.DaysBeforeEnd;
                    worksheet.Cell(currentRow, 18).Value = employeeEngagement.WeeksBeforeEnd;
                }

                worksheet.Columns(1, 18).AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workExcel.SaveAs(stream);
                    var content = stream.ToArray();

                    return content;
                }
            }
        }
    }
}
