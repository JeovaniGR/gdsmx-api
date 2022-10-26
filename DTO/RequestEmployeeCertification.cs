﻿namespace gdsmx_back_netcoreAPI.DTO
{
    public class RequestEmployeeCertification
    {
        public int Option { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Certification { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public RequestEmployeeCertification()
        {
            Page = 1;
            PageSize = 1;
        }
    }
}
