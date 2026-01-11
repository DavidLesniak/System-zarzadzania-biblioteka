using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Author
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Imię autora jest wymagane")]
        //[MaxLength(100, ErrorMessage = "Imię może mieć maksymalnie 100 znaków")]
        //[RegularExpression(@"^[a-zA-ZąćęłńóśżźĄĆĘŁŃÓŚŻŹ- ]+$",
            //ErrorMessage = "Imię może zawierać tylko litery")]
        //[Display(Name = "Imię")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Nazwisko autora jest wymagane")]
        //[MaxLength(100, ErrorMessage = "Nazwisko może mieć maksymalnie 100 znaków")]
        //[RegularExpression(@"^[a-zA-ZąćęłńóśżźĄĆĘŁŃÓŚŻŹ- ]+$",
            //ErrorMessage = "Nazwisko może zawierać tylko litery")]
        //[Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        // Relacja 1:N (Autor -> Książki)
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}