using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SchoolManegment.Authorization.Roles;
using SchoolManegment.Authorization.Users;
using SchoolManegment.MultiTenancy;
using SchoolManegment.Entities;

namespace SchoolManegment.EntityFrameworkCore
{
    public class SchoolManegmentDbContext : AbpZeroDbContext<Tenant, Role, User, SchoolManegmentDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public SchoolManegmentDbContext(DbContextOptions<SchoolManegmentDbContext> options)
            : base(options)
        {
        }
        public DbSet<Students> Tbl_Students { get; set; }
        public DbSet<Teacher> Tbl_Teachers { get; set; }
        public DbSet<Subject> Tbl_Subjects { get; set; }
        public DbSet<StudentSubject> Tbl_StudentSubjects { get; set; }
    }
}
