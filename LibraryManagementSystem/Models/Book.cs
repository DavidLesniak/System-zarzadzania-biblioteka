using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tytuł jest obowiązkowy")]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        [ValidateNever]
        public Author Author { get; set; }

        [Required(ErrorMessage = "Rok wydania jest wymagany")]
        [Range(1000, 2026, ErrorMessage = "Podaj poprawny rok (1000-2026)")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Numer ISBN jest wymagany")]
        [MaxLength(20)]
        public string ISBN { get; set; }

        [Required]
        // Klucz obcy
        public int CategoryId { get; set; }

        // Relacja N:1
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
    }
}
