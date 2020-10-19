namespace LW7.People.Person.Worker
{
    public class Worker: PersonImpl, IWorker
    {
        public string Speciality { get; }
        public Worker(string name, string surName, string patronymic, string address, string speciality) : base(name, surName, patronymic, address)
        {
            Speciality = speciality;
        }
    }
}