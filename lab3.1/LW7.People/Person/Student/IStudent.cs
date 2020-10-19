namespace LW7.People.Person.Student
{
    public interface IStudent: IPerson
    {
        public string UniversityName { get; }
        public uint IdNumber { get; }
    }
}