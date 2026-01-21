using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Reader
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię czytelnika jest wymagane")]
        [RegularExpression(@"^[a-zA-ZĄąĆćĘęŁłŃńÓóŚśŹźŻż ]+$", ErrorMessage = "To pole może zawierać tylko litery")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko czytelnika jest wymagane")]
        [RegularExpression(@"^[a-zA-ZĄąĆćĘęŁłŃńÓóŚśŹźŻż ]+$", ErrorMessage = "To pole może zawierać tylko litery")]
        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        [Phone(ErrorMessage = "Błędny format numeru telefonu")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Numer telefonu musi składać się z dokładnie 9 cyfr")]
        public string PhoneNumber { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}