using BarbourLogic_LibraryManager.Models;

namespace BarbourLogic_LibraryManager
{
    public interface ILibraryManager
    {
        public void AddBook(Book book);

        public void BorrowBook(int userId, int bookId);

        public void ReturnBook(int userId, int bookId);

        public void GetBookList();

        public void AddUser(string name);

        public void EditUser(int id, string name);

        public User GetUser(int id);

        public void DeleteUser(int id);

        public List<User> ListUsers();
    }
}
