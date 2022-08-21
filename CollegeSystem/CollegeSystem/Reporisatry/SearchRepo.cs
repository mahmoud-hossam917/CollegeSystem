using CollegeSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeSystem.Reporisatry
{
    public class SearchRepo
    {
       
        public Student SearchUserName(string name)
        {
            var user = DataBaseObject.db.students.Include(x => x.subjects).Where(x => x.name == name).FirstOrDefault(); ;
            return  user ;

        }
        public Student SearchUserEmail(string email)
        {
            var user = DataBaseObject.db.students.Include(x => x.subjects).Where(x => x.email == email).FirstOrDefault();

            return user;

        }
        public Student SearchUserId(int id)
        {
            var user = DataBaseObject.db.students.Include(x=>x.subjects).Where(x=>x.id==id).FirstOrDefault();
                      
            return user;
        }
        public StudentSubject SearchSubjectInStudent(StudentSubject studentSubject)
        {
            var Subject = (from data in DataBaseObject.db.studentSubjects
                       where data.subjectID == studentSubject.subjectID
                       && data.studentID == studentSubject.studentID
                       select data).FirstOrDefault();
            return Subject;
        }
        public Subject SearchSubjectById(int Id)
        {
            var subject=DataBaseObject.db.subjects.Find(Id);
            return subject;
        }
        public Subject SearchSubjectByName(string name)
        {
            var subject = (from data in DataBaseObject.db.subjects
                           where data.name.ToLower() == name.ToLower()
                           select data).FirstOrDefault();
            return subject;
        }

    }
}
