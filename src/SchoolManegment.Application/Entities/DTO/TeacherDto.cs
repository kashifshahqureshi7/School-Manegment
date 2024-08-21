using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManegment.Entities.DTO
{
    [AutoMapTo(typeof(Teacher)), AutoMapFrom(typeof(Teacher))]
    public class TeacherDto:EntityDto<int>
    {
        public string TID { get; set; }
        public string TeacherName { get; set; }
        public string TFatherName { get; set; }
        public string Subject { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
