using BlazorApp7.Data;
namespace BlazorApp7.Services
{
   
  
    using System.Collections.Generic;

    public interface IBorrowService
    {
        bool BorrowBook(string isbn, int userId, Dictionary<User, List<Book>> borrowedBooks, List<Book> availableBooks);
        bool BorrowBook(User user, Book book);
        bool ReturnBook(User user, Book book);

        bool HasBorrowedBooks(User user);
        List<Book> GetBorrowedBooks(User user);
    }

}
