using TestTask.Models;

namespace TestTask.ViewModel
{
    public class IncidentViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
