using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Authentication;
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
    public class TeacherAppservices:AsyncCrudAppService<Teacher,TeacherDto,int,PagedRoleResultRequestDto>
    {
        private readonly IRepository<Teacher> _Teacherrepository;
        public TeacherAppservices(IRepository<Teacher> TeacherRepository):base(TeacherRepository) 
        {
            _Teacherrepository = TeacherRepository;
        }
        public override async Task<TeacherDto> CreateAsync( TeacherDto input )
        {
            var teacher=ObjectMapper.Map<Teacher>(input);
            teacher.TID= await GenerateNextID();
            await _Teacherrepository.InsertAsync(teacher);
            return ObjectMapper.Map<TeacherDto>(teacher);
        }
        private async Task<string> GenerateNextID()
        {
            var lastteacher= await _Teacherrepository.GetAll()
                .OrderByDescending(x => x.TID).FirstOrDefaultAsync();
            if (lastteacher == null)
            {
                return "TID-01";
            }
            var lastTID=lastteacher.TID;
            var part=lastTID.Split('-');
            var lastID=int.Parse(part[1]);
           var newID = lastTID + 1;
            return $"{newID:D2}";
        }
    }
}
