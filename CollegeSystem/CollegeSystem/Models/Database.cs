using Microsoft.EntityFrameworkCore;

namespace CollegeSystem.Models
{
    public  class Database: DbContext
    {

    
        public DbSet<User> users { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<AcademicDay> days { get; set; }
        public DbSet<Schedule> schedules { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-NDE9FL9\SQLEXPRESS;Database=CollegeSystem;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubject>()
           .HasKey(t => new { t.studentID, t.subjectID });

         
            modelBuilder.Entity<StudentSubject>()
             .HasOne(pt => pt.Student)
              .WithMany(p => p.subjects)
              .HasForeignKey(pt => pt.studentID);
            modelBuilder.Entity<StudentSubject>()
               .HasOne(pt => pt.Subject)
               .WithMany(t => t.students)
               .HasForeignKey(pt => pt.subjectID);

       
        }

    }
}
