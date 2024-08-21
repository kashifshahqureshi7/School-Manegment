using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManegment.Entities.DTO
{
    [AutoMapTo(typeof(StudentSubject)), AutoMapFrom(typeof(StudentSubject))]
    public class StudentSubjectDto:EntityDto<int>
    {
       public int StudentsId { get; set; }

      
       // public int SubjectId { get; set; }
        public List<int> SubjectId { get; set; }
    }
}
