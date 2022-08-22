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
            var subject=DataBaseObject.db.subjects.Include(x=>x.students).Include(x=>x.days).Where(x=>x.Id==Id).FirstOrDefault();
            return subject;
        }
        public Subject SearchSubjectByName(string name)
        {
            var subject = DataBaseObject.db.subjects.Include(x => x.students).
                              Where(x => x.name==name).FirstOrDefault();
            return subject;
        }
        public Student IsUserExits(string email, string password)
        {
            var student=DataBaseObject.db.students.Include(x=>x.subjects).
                            Where(x=>x.email==email && x.password==password).FirstOrDefault();
            return student;
        }
        public AcademicDay IsDayExits(DateTime date , string day , int scheduleID)
        {

           var exits= DataBaseObject.db.days.Include(x=>x.subjects).Where(x => x.day == day && x.scheduleID == scheduleID
            && x.date.Day == date.Day && x.date.Year == date.Year).FirstOrDefault();
            return exits;
        }
        public AcademicDay SearchAboutDaybyId(int id)
        {
            var day= DataBaseObject.db.days.Include(x=>x.subjects).Where(x=>x.id==id).FirstOrDefault();
            return day;
        }
        public SubjectDay SearchAboutSubjectInDay(int subjectID, int dayID)
        {
            var subject=DataBaseObject.db.subjectDay.
                Where(x=>x.subjectID==subjectID && x.dayID==dayID).FirstOrDefault();
            return subject;
        }
        public Schedule IsScheduleExits(int studentID,string type)
        {
            var schedule = DataBaseObject.db.schedules.Where(x => x.studentId == studentID&&x.type==type).FirstOrDefault();
            return schedule;
        }
        public Schedule SearchAboutScheduleById(int id)
        {
            return DataBaseObject.db.schedules.Include(x=>x.days).Where(x => x.id == id).FirstOrDefault();
        }
    }
}
