using LibraryManagementSystemAPI.Data;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly LibraryContext _context;

        public LoansController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetLoans()
        {
            var loans = await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Member)
                .ToListAsync();
            return Ok(loans);
        }

        [HttpPost("borrow")]
        public async Task<IActionResult> Borrow([FromBody] BorrowRequest req)
        {
            var book = await _context.Books.FindAsync(req.BookId);
            if (book == null) return NotFound(new { message = "Book not found" });
            if (!book.IsAvailable) return BadRequest(new { message = "Book is currently not available" });

            var member = await _context.Members.FindAsync(req.MemberId);
            if (member == null) return NotFound(new { message = "Member not found" });

            var loan = new Loan
            {
                BookId = book.Id,
                MemberId = member.Id,
                BorrowedDate = DateTime.UtcNow
            };

            book.IsAvailable = false;
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return Ok(loan);
        }

        [HttpPost("return")]
        public async Task<IActionResult> Return([FromBody] BorrowRequest req)
        {
            var loan = await _context.Loans
                .Where(l => l.BookId == req.BookId && l.MemberId == req.MemberId && l.ReturnedDate == null)
                .FirstOrDefaultAsync();

            if (loan == null) return NotFound(new { message = "Active loan not found for given book and member" });

            loan.ReturnedDate = DateTime.UtcNow;

            var book = await _context.Books.FindAsync(req.BookId);
            if (book != null) book.IsAvailable = true;

            await _context.SaveChangesAsync();
            return Ok(loan);
        }
    }
}
