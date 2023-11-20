using BlazorApp7.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp7.Services
{



    public class BorrowService : IBorrowService
    {

        public void BorrowBook(string isbn, User user, Dictionary<User, List<Book>> borrowedBooks, List<Book> availableBooks)
        {
            // Example usage on List<Book>
            var bookToBorrow = availableBooks.FirstOrDefault(book => book.ISBN == isbn);

            if (bookToBorrow != null)
            {
                // Remove the book from available books
                availableBooks.Remove(bookToBorrow);

                // Example usage on Dictionary<User, List<Book>>
                if (!borrowedBooks.ContainsKey(user))
                {
                    borrowedBooks[user] = new List<Book>();
                }

                borrowedBooks[user].Add(bookToBorrow);
            }
        }

        public bool BorrowBook(User user, Book book)
        {

            if (user != null && book != null && book.AvailableCopies > 0)
            {
                // Decrease the available copies of the book
                book.AvailableCopies--;

                // Add the book to the user's borrowed books
               
                
                user.BorrowedBooks.Add(book);

                return true;
            }

            return false;
        }

        public bool BorrowBook(string isbn, int userId, Dictionary<User, List<Book>> borrowedBooks, List<Book> availableBooks)
        {
            // Implement the logic for borrowing a book by ISBN and user ID
            var user = borrowedBooks.Keys.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                BorrowBook(isbn, user, borrowedBooks, availableBooks);
                return true;
            }

            return false;
        }


        public bool ReturnBook(User user, Book book)
        {
            if (user != null && book != null)
            {
                book.AvailableCopies++;
                user.BorrowedBooks.Remove(book);
                return true;
            }

            return false;
        }

        public bool HasBorrowedBooks(User user)
        {
            return user != null && user.BorrowedBooks.Any();
        }

        public List<Book> GetBorrowedBooks(User user)
        {
            return user?.BorrowedBooks.ToList() ?? new List<Book>();
        }

    }
}
