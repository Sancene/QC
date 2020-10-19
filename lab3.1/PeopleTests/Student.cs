namespace LW7.People.Person.Student
{
    public class Student: PersonImpl, IStudent
    {
        public string UniversityName { get; }
        public uint IdNumber { get; }
        
        public Student(string name, string surName, string patronymic, string address, string universityName, uint idNumber) 
            : base(name, surName, patronymic, address)
        {
            UniversityName = universityName;
            IdNumber = idNumber;
        }
    }
}