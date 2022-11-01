using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using gdsmx_back_netcoreAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System.Text;
using gdsmx_back_netcoreAPI.BL.Interfaces;

namespace gdsmx_back_netcoreAPI.BL.Resource
{
    public class EmployeeFileWriter : IExcelWriter<DataEmployee>, ICSVWriter<DataEmployee>
    {
        private readonly List<string> header = new List<string>() {
            "GNP",
            "First Name",
            "Middle Name",
            "Last Name",
            "Second LastName",
            "Birthdate",
            "JoinedDate",
            "Email",
            "Counselor",
            "Location",
            "Person Segment",
            "Competency",
            "Status",
            "Rank",
            "Level",
            "Grade",
            "Notes"
        };
        
        public byte[] WriteFileCSV(List<DataEmployee> Employeelist)
        {

            var sb = new StringBuilder();

            sb.AppendLine(string.Join(",", header));

            foreach (var item in Employeelist)
            {
                sb.AppendLine($"{item.GPN}," +
                            $"{item.FirstName}," +
                            $"{item.MiddleName}," +
                            $"{item.LastName}," +
                            $"{item.SecondLastName}," +
                            $"{item.Birthdate}," +
                            $"{item.JoinedDate.ToShortDateString()}," +
                            $"{item.Email}," +
                            $"{item.Counselor}," +
                            $"{item.Location}," +
                            $"{item.PersonSegment}," +
                            $"{item.Competency}," +
                            $"{item.Status}," +
                            $"{item.Rank}," +
                            $"{item.Level}," +
                            $"{item.Grade}," +
                            $"\"{item.Notes}\"");
            }
           
            return Encoding.GetEncoding("Windows-1252").GetBytes(sb.ToString());
        }

        public byte[] WriteToCSV(List<DataEmployee> values)
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Join(",", header));

            foreach (var item in values)
            {
                sb.AppendLine($"{item.GPN}," +
                            $"{item.FirstName}," +
                            $"{item.MiddleName}," +
                            $"{item.LastName}," +
                            $"{item.SecondLastName}," +
                            $"{item.Birthdate}," +
                            $"{item.JoinedDate.ToShortDateString()}," +
                            $"{item.Email}," +
                            $"{item.Counselor}," +
                            $"{item.Location}," +
                            $"{item.PersonSegment}," +
                            $"{item.Competency}," +
                            $"{item.Status}," +
                            $"{item.Rank}," +
                            $"{item.Level}," +
                            $"{item.Grade}," +
                            $"\"{item.Notes}\"");
            }

            return Encoding.GetEncoding("Windows-1252").GetBytes(sb.ToString());
        }

        public byte[] WriteToExcel(List<DataEmployee> values)
        {
            using (var workExcel = new XLWorkbook())
            {
                var worksheet = workExcel.Worksheets.Add("Employee");
                var currentRow = 1;

                foreach (var (headerValue, index) in header.Select((value, i) => (value, i)))
                {
                    worksheet.Cell(currentRow, index + 1).Value = headerValue;
                }

                var rango = worksheet.Range("A1:Q1");
                rango.Style.Font.FontSize = 12;
                rango.Style.Font.Bold = true;
                rango.Style.Fill.BackgroundColor = XLColor.PastelGray;

                foreach (var item in values)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.GPN;
                    worksheet.Cell(currentRow, 2).Value = item.FirstName;
                    worksheet.Cell(currentRow, 3).Value = item.MiddleName;
                    worksheet.Cell(currentRow, 4).Value = item.LastName;
                    worksheet.Cell(currentRow, 5).Value = item.SecondLastName;
                    worksheet.Cell(currentRow, 6).SetValue(item.Birthdate);
                    worksheet.Cell(currentRow, 7).Value = item.JoinedDate;
                    worksheet.Cell(currentRow, 8).Value = item.Email;
                    worksheet.Cell(currentRow, 9).Value = item.Counselor;
                    worksheet.Cell(currentRow, 10).Value = item.Location;
                    worksheet.Cell(currentRow, 11).Value = item.PersonSegment;
                    worksheet.Cell(currentRow, 12).Value = item.Competency;
                    worksheet.Cell(currentRow, 13).Value = item.Status;
                    worksheet.Cell(currentRow, 14).Value = item.Rank;
                    worksheet.Cell(currentRow, 15).Value = item.Level;
                    worksheet.Cell(currentRow, 16).Value = item.Grade;
                    worksheet.Cell(currentRow, 17).Value = item.Notes;
                }

                worksheet.Columns(1, 17).AdjustToContents();

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
