using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystemAPI.Models
{
    public class Loan
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public int MemberId { get; set; }

        public DateTime BorrowedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnedDate { get; set; }

        // Navigation properties (optional)
        public Book? Book { get; set; }
        public Member? Member { get; set; }
    }
}
