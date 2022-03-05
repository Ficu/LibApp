using LibApp.Models;
using System.Collections.Generic;

namespace LibApp.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();

        Book GetBookById(int bookId);

        void AddBook(Book book);

        void UpdateBook(Book book);

        void DeleteBookById(int bookId);

        Book SingleOrDefault(int bookId);

        IEnumerable<Book> GetAvailableBooksBy(string query);

        public void SaveChanges();
    }
}
