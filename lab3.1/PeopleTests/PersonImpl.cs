namespace LW7.People.Person
{
    public abstract class PersonImpl: IPerson
    {
        public string Name { get; }
        public string SurName { get; }
        public string Patronymic { get; }
        public string Address { get; }

        public PersonImpl(string name, string surName, string patronymic, string address)
        {
            Name = name;
            SurName = surName;
            Patronymic = patronymic;
            Address = address;
        }
    }
}