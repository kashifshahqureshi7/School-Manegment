using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManegment.Entities
{
    public class StudentSubject:Entity
    {
        public int StudentsId { get; set; }
        public int SubjectId { get; set; }
        public Subject Subjects { get; set; }
        public Students Students { get; set; }
    }
}
