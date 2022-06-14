namespace TestTask.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IncidentName { get; set; }
        public Incident Incident { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
