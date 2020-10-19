using System.Buffers.Text;

namespace LW7.People.Person.Teacher
{
    public class Teacher: PersonImpl, ITeacher
    {
        public string SubjectName { get; }

        public Teacher(string name, string surName, string patronymic, string address, string subjectName) : base(name, surName, patronymic, address)
        {
            SubjectName = subjectName;
        }
    }
}