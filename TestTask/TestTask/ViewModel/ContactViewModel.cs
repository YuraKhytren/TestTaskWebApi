using TestTask.Models;

namespace TestTask.ViewModel
{
    public class ContactViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
