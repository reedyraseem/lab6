using BlazorApp7.Data;

namespace BlazorApp7.Services
{
    public interface IBookService
    {
      public  List<Book> GetBooks();
      public  void AddBook(Book book);
      public  void EditBook(Book book);
       public void DeleteBook(int bookId);

        Book GetBookByISBN(string isbn);
        void AddBooks(List<Book> books);
    }
}
