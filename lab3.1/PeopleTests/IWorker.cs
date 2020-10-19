namespace LW7.People.Person.Worker
{
    public interface IWorker: IPerson
    {
        public string Speciality { get; }
    }
}