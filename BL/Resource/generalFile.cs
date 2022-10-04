using gdsmx_back_netcoreAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace gdsmx_back_netcoreAPI.BL.Resource
{
    public class generalFile
    {
        public bool WirteFileCSV(List<DataEmployee> Employeelist, string fileName)
        {
            bool blResult = false;
            string path = @"Downloads\" + fileName + ".csv";

            if (File.Exists(path))
                File.Delete(path);

            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs,Encoding.UTF8);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("GNP|Nombre");

            foreach (var item in Employeelist)
            {
                sb.AppendLine(item.GPN + '|' + item.FirstName);
               
            }

            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            fs.Close();


            if (File.Exists(path))
                    blResult = true;
           

            return blResult;
        }
    }
}
