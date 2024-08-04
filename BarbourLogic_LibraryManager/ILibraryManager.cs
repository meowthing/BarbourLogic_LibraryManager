using BarbourLogic_LibraryManager.Models;

namespace BarbourLogic_LibraryManager
{
    public interface ILibraryManager
    {
        public void AddBook(Book book);

        public void BorrowBook(User user, int bookId);

        public void ReturnBook(User user, int bookId);

        public void GetBookList();
    }
}
