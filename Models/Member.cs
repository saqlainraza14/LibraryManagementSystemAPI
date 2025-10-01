using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        public DateTime JoinedDate { get; set; } = DateTime.UtcNow;
    }
}
