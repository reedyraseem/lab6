using BlazorApp7.Data;
using BlazorApp7.Services;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorApp7.Services
{
    public class BookService : IBookService
    {
        private List<Book> books = new List<Book>();

        public List<Book> GetBooks()
        {
            return books;
        }

        public void AddBook(Book book)
        {
            int id = books.Any() ? books.Max(b => b.Id) + 1 : 1;
            book.Id = id;
            books.Add(book);
            
        }

        public void EditBook(Book book)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
            }
        }

        public void DeleteBook(int bookId)
        {
            var bookToDelete = books.FirstOrDefault(b => b.Id == bookId);
            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);
            }
        }

        public void AddBooks(List<Book> booksToAdd)
        {
            foreach (var book in booksToAdd)
            {
              
                if (!books.Any(b => b.ISBN == book.ISBN))
                {
                    books.Add(book);
                }
            }
        }

        public Book GetBookByISBN(string isbn)
        {
            return books.FirstOrDefault(b => b.ISBN == isbn);
        }

    }
}
