namespace LW7.People.Person.Pupil
{
    public interface IPupil: IPerson
    {
        public string SchoolName { get; }
        public string ClassName { get; }
    }
}