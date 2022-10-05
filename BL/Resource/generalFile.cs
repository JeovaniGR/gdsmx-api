using ClosedXML.Excel;
using gdsmx_back_netcoreAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace gdsmx_back_netcoreAPI.BL.Resource
{
    public class generalFile
    {
        public byte[] WirteFileCSV(List<DataEmployee> Employeelist)
        {
            var sb = new StringBuilder();

            sb.AppendLine("GNP," +
                        "FirstName," +
                        "MiddleName," +
                        "LastName," +
                        "SecondLastName," +
                        "Birthdate," +
                        "JoinedDate," +
                        "Email," +
                        "Counselor," +
                        "Location," +
                        "PersonSegment," +
                        "Competency," +
                        "Status," +
                        "Rank," +
                        "Level," +
                        "Grade");

            foreach (var item in Employeelist)
            {
                sb.AppendLine($"{item.GPN}," +
                            $"{item.FirstName}," +
                            $"{item.MiddleName}," +
                            $"{item.LastName}," +
                            $"{item.SecondLastName}," +
                            $"{item.Birthdate}," +
                            $"{item.JoinedDate}," +
                            $"{item.Email}," +
                            $"{item.Counselor}," +
                            $"{item.Location}," +
                            $"{item.PersonSegment}," +
                            $"{item.Competency}," +
                            $"{item.Status}," +
                            $"{item.Rank}," +
                            $"{item.Level}," +
                            $"{item.Grade}");


            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        public byte[] WirteFileExcel(List<DataEmployee> Employeelist)
        {
           using (var workExcel =  new XLWorkbook())
            {
                var worksheet = workExcel.Worksheets.Add("Employee");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "GNP";
                worksheet.Cell(currentRow, 2).Value = "FirstName";
                worksheet.Cell(currentRow, 3).Value = "MiddleName";
                worksheet.Cell(currentRow, 4).Value = "LastName";
                worksheet.Cell(currentRow, 5).Value = "SecondLastName";
                worksheet.Cell(currentRow, 6).Value = "Birthdate";
                worksheet.Cell(currentRow, 7).Value = "JoinedDate";
                worksheet.Cell(currentRow, 8).Value = "Email";
                worksheet.Cell(currentRow, 9).Value = "Counselor";
                worksheet.Cell(currentRow, 10).Value = "Location";
                worksheet.Cell(currentRow, 11).Value = "PersonSegment";
                worksheet.Cell(currentRow, 12).Value = "Competency";
                worksheet.Cell(currentRow, 13).Value = "Status";
                worksheet.Cell(currentRow, 14).Value = "Rank";
                worksheet.Cell(currentRow, 15).Value = "Level";
                worksheet.Cell(currentRow, 16).Value = "Grade";
                worksheet.Cell(currentRow, 17).Value = "Notes";

                var rango = worksheet.Range("A1:Q1"); 
                rango.Style.Font.FontSize = 12; 
                rango.Style.Font.Bold = true;
                rango.Style.Fill.BackgroundColor = XLColor.PastelGray;

                foreach (var item in Employeelist)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.GPN;
                    worksheet.Cell(currentRow, 2).Value = item.FirstName;
                    worksheet.Cell(currentRow, 3).Value = item.MiddleName;
                    worksheet.Cell(currentRow, 4).Value = item.LastName;
                    worksheet.Cell(currentRow, 5).Value = item.SecondLastName;
                    worksheet.Cell(currentRow, 6).Value = item.Birthdate;
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
