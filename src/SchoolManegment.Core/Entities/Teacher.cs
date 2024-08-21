using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManegment.Entities
{
    public class Teacher:Entity
    {
        public string TID { get; set; }
        public string TeacherName { get; set; }
        public string TFatherName { get; set; }
        public string Subject { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
