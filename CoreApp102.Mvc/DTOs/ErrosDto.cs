using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp102.Mvc.DTOs
{
    public class ErrosDto
    {
        //public ErrosDto(List<string> errors, int status)
        //{
        //    Errors = errors;
        //    Status = status;
        //}

        public ErrosDto()
        {
            Errors = new List<string>();
        }

        //public ErrosDto() => Errors = new List<string>();

        public List<String> Errors { get; set; }
        public int Status { get; set; }
    }
}
