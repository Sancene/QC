using LW7.People.Person;
using LW7.People.Person.Pupil;
using LW7.People.Person.Student;
using LW7.People.Person.Student.AdvancedStudent;
using LW7.People.Person.Teacher;
using LW7.People.Person.Worker;
using Xunit;

namespace LW7.People.Tests
{
    public class CommonTests
    {
        private const string Name = "Иван";
        private const string SurName = "Иванов";
        private const string Patronymic = "Иванович";
        private const string Address = "Ленинский проспект д. 1";

        [Fact]
        public void Pupil_TestData_ExpectedClassState()
        {
            var school = "Школа №555";
            var className = "7Б";
            var pupil = new Pupil(Name, SurName, Patronymic, Address, school, className);
            
            Assert.Equal(Name, pupil.Name);
            Assert.Equal(SurName, pupil.SurName);
            Assert.Equal(Patronymic, pupil.Patronymic);
            Assert.Equal(Address, pupil.Address);
            Assert.Equal(school, pupil.SchoolName);
            Assert.Equal(className, pupil.ClassName);
            Assert.True(pupil is IPerson);
            Assert.True(pupil is IPupil);
        }
        
        [Fact]
        public void Worker_TestData_ExpectedClassState()
        {
            var speciality = "Столяр";
            var worker = new Worker(Name, SurName, Patronymic, Address, speciality);
            
            Assert.Equal(Name, worker.Name);
            Assert.Equal(SurName, worker.SurName);
            Assert.Equal(Patronymic, worker.Patronymic);
            Assert.Equal(Address, worker.Address);
            Assert.Equal(speciality, worker.Speciality);
            Assert.True(worker is IPerson);
            Assert.True(worker is IWorker);
        }
        
        [Fact]
        public void Teacher_TestData_ExpectedClassState()
        {
            var subject = "Математика";
            var teacher = new Teacher(Name, SurName, Patronymic, Address, subject);
            
            Assert.Equal(Name, teacher.Name);
            Assert.Equal(SurName, teacher.SurName);
            Assert.Equal(Patronymic, teacher.Patronymic);
            Assert.Equal(Address, teacher.Address);
            Assert.Equal(subject, teacher.SubjectName);
            Assert.True(teacher is IPerson);
            Assert.True(teacher is ITeacher);
        }
        
        [Fact]
        public void Student_TestData_ExpectedClassState()
        {
            var university = "Политех";
            uint id = 2222;
            var student = new Student(Name, SurName, Patronymic, Address, university, id);
            
            Assert.Equal(Name, student.Name);
            Assert.Equal(SurName, student.SurName);
            Assert.Equal(Patronymic, student.Patronymic);
            Assert.Equal(Address, student.Address);
            Assert.Equal(id, student.IdNumber);
            Assert.True(student is IPerson);
            Assert.True(student is IStudent);
        }
        
        [Fact]
        public void AdvStudent_TestData_ExpectedClassState()
        {
            var university = "Политех";
            uint id = 2222;
            var topic = "Образование и экономика";
            var newTopic = "Методология";
            var advStudent = new AdvancedStudent(Name, SurName, Patronymic, Address, university, id, topic);
            
            Assert.Equal(Name, advStudent.Name);
            Assert.Equal(SurName, advStudent.SurName);
            Assert.Equal(Patronymic, advStudent.Patronymic);
            Assert.Equal(Address, advStudent.Address);
            Assert.Equal(id, advStudent.IdNumber);
            Assert.Equal(topic, advStudent.DissertationTopic);
            Assert.Equal(university, advStudent.UniversityName);
            advStudent.ChangeDissertationTopic(newTopic);
            Assert.Equal(newTopic, advStudent.DissertationTopic);
            Assert.True(advStudent is IPerson);
            Assert.True(advStudent is IStudent);
            Assert.True(advStudent is IAdvancedStudent);
        }
    }
}