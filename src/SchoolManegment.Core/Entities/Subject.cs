using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManegment.Entities
{
    public class Subject:Entity
    {
        
        public string SubjectName { get; set; }
      
         public ICollection<Students> Students { get; set; }=new List<Students>();
    }
}
