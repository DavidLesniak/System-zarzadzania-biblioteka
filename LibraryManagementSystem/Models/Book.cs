using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        [ValidateNever]
        public Author Author { get; set; }

        public int Year { get; set; }

        [MaxLength(20)]
        public string ISBN { get; set; }

        // Klucz obcy
        public int CategoryId { get; set; }

        // Relacja N:1
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
    }
}
