using TestTask.Models;

namespace TestTask.ViewModel
{
    public class AccountViewModel
    {
        public string Name { get; set; }
        public string IncidentName { get; set; }
        public Incident Incident { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
