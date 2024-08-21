using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Abp.AutoMapper;



namespace SchoolManegment.Entities.DTO
{
    [AutoMapTo(typeof(Students)), AutoMapFrom( typeof( Students ) )]
    
    public class StudentDto:EntityDto<int>
    {
        public string STID { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateOnly DOB { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public List<int> SubjectIds { get; set; }
        //  public ICollection<Subject> Subjects { get; set; }
    }
}
