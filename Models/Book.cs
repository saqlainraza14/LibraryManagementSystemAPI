using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        public string? ISBN { get; set; }

        // true when not currently borrowed
        public bool IsAvailable { get; set; } = true;
    }
}
