using Abp.Application.Services;
using Abp.Domain.Repositories;
using SchoolManegment.Entities;
using SchoolManegment.Entities.DTO;
using SchoolManegment.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace SchoolManegment.Entity
{
    public class StudentAppServices:AsyncCrudAppService<Students,StudentDto,int,PagedRoleResultRequestDto>
    {
        private readonly IRepository<Students> _studentsRepository;
        public StudentAppServices(IRepository<Students> Studentrepository):base(Studentrepository) 
        {
            _studentsRepository = Studentrepository; 
        }
        public override async Task<StudentDto> CreateAsync( StudentDto input )
        {
            var student=ObjectMapper.Map<Students>(input);
            student.STID=await GenerateNextID();
            await _studentsRepository.InsertAsync(student);
            return ObjectMapper.Map<StudentDto>(student);
        }
        public async Task<string> GenerateNextID()
        {
            var laststudent= await _studentsRepository.GetAll()
                .OrderByDescending(x => x.STID).FirstOrDefaultAsync();
            if (laststudent == null)
            {
                return "STID-01";
            }
            var lastid= laststudent.STID;
            var parts= lastid.Split('-');
            var lastnumber=int.Parse(parts[1]);
            var newnumber = lastnumber + 1;
            return $"STID-{newnumber:D2}";

        }
      
    }
    
}
