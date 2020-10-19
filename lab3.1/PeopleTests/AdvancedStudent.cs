namespace LW7.People.Person.Student.AdvancedStudent
{
    public class AdvancedStudent: Student, IAdvancedStudent
    {
        public string DissertationTopic { get; set; }

        public AdvancedStudent(string name, string surName, string patronymic, string address, string universityName, uint idNumber, string dissertationTopic) 
            : base(name, surName, patronymic, address, universityName, idNumber)
        {
            DissertationTopic = dissertationTopic;
        }

        public void ChangeDissertationTopic(string newTopic)
        {
            DissertationTopic = newTopic;
        }
    }
}