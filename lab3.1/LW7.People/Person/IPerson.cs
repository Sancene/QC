namespace LW7.People.Person
{
    public interface IPerson
    {
        public string Name { get; }
        public string SurName { get; }
        public string Patronymic { get; }
        public string Address { get; }
    }
}