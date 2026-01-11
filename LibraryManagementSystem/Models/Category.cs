using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Relacja 1:N – jedna kategoria ma wiele książek
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
