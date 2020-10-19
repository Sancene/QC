namespace LW7.People.Person.Pupil
{
    public class Pupil: PersonImpl, IPupil
    {
        public string SchoolName { get; }
        public string ClassName { get; }
        
        public Pupil(string name, string surName, string patronymic, string address, string schoolName, string className) : base(name, surName, patronymic, address)
        {
            SchoolName = schoolName;
            ClassName = className;
        }
    }
}