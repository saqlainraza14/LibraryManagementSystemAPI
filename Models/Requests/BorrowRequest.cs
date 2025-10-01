namespace LibraryManagementSystemAPI.Models.Requests
{
    public class BorrowRequest
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
    }
}
