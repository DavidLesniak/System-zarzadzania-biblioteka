namespace LibraryManagementSystem.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}