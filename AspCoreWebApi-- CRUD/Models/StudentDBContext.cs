using Microsoft.EntityFrameworkCore;

namespace AspCoreWebApi___CRUD.Models

{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> tblStudents { get; set; }
    }
}
