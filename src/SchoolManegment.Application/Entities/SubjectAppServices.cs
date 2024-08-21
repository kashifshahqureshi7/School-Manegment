using Abp.Application.Services;
using Abp.Domain.Repositories;
using SchoolManegment.Entities.DTO;
using SchoolManegment.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManegment.Entities
{
    public class SubjectAppServices:AsyncCrudAppService<Subject,SubjectDto,int,PagedRoleResultRequestDto>
    {
       private readonly IRepository<Subject> _subjectRepository;
        public SubjectAppServices(IRepository<Subject> SubjectRepository):base(SubjectRepository) 
        {
            _subjectRepository = SubjectRepository;
            
        }
    }
}
