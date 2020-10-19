namespace LW7.People.Person.Student.AdvancedStudent
{
    public interface IAdvancedStudent: IStudent
    {
        public string DissertationTopic { get; }

        public void ChangeDissertationTopic(string newTopic)
        {
        }
    }
}