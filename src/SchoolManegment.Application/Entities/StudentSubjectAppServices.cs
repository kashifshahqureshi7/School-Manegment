using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SchoolManegment.Entities.DTO;
using SchoolManegment.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManegment.Entities
{
    public class StudentSubjectAppServices : AsyncCrudAppService<StudentSubject , StudentSubjectDto,int, PagedRoleResultRequestDto>
    {
        private readonly IRepository<StudentSubject> _studentSubjectRepository;
      //  private readonly IRepository<Students> _studentreopository;
        public StudentSubjectAppServices( IRepository<StudentSubject> StudentSubjectRepository ) : base( StudentSubjectRepository )
        {
            _studentSubjectRepository = StudentSubjectRepository;
           // _studentreopository = studentreopository;
        }
        public override async Task<StudentSubjectDto> CreateAsync( StudentSubjectDto input )
        {
            var studentSubject = ObjectMapper.Map<StudentSubject>( input );
            var createdStudentSubject = await _studentSubjectRepository.InsertAsync( studentSubject );
            await CurrentUnitOfWork.SaveChangesAsync(); 
            return ObjectMapper.Map<StudentSubjectDto>( createdStudentSubject );
        }
        public override async Task<StudentSubjectDto> GetAsync( EntityDto<int> input )
        {
          

            var studentSubjects = await _studentSubjectRepository.GetAllIncluding( s => s.Students )
                                                            .Include( s => s.Subjects )
                                                            .Where( s => s.StudentsId == input.Id )
                                                            .ToListAsync();

            if (!studentSubjects.Any())
            {
                throw new UserFriendlyException( "Id was not found" );
            }

            var student = studentSubjects.First().Students;

            var studentSubjectDto = new StudentSubjectDto
            {
                StudentsId = student.Id ,
                SubjectId = studentSubjects.Select( ss => ss.SubjectId ).ToList()
            };

            return studentSubjectDto;
        }


    }
}
