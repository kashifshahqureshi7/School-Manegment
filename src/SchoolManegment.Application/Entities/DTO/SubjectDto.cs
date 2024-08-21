using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManegment.Entities.DTO
{
    [AutoMapTo(typeof(Subject)),AutoMapFrom(typeof(Subject))]
    public class SubjectDto:EntityDto<int>
    {
        public string SubjectName { get; set; }
        public List<int> StudentId { get; set; }
        //public ICollection<Students> Students { get; set; }

    }
}
