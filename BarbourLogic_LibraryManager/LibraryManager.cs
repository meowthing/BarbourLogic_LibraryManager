using BarbourLogic_LibraryManager.Models;

namespace BarbourLogic_LibraryManager
{
    public class LibraryManager : ILibraryManager
    {
        List<User> Users;
        List<Book> Books;

        public LibraryManager(List<Book> books, List<User> users)
        {
            if (books == null)
            {
                this.Books = new List<Book>();
            }
            else
            {
                this.Books = books;
            }

            if (users == null)
            {
                this.Users = new List<User>();
            }
            else
            {
                this.Users = users;
            }
        }

        public void GetBookList()
        {
            Console.WriteLine("Listing books:");
            foreach (Book book in Books)
            {
                Console.WriteLine($"ID:{book.Id}, Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Available: {(book.Available ? "Yes" : "No")}");
            }
        }

        public void AddBook(Book book)
        {
            int latestId = Books.Max(b => (int?)b.Id) ?? 0;
            book.Id = latestId + 1;
            Books.Add(book);
            Console.WriteLine("Book added.");
        }

        public void BorrowBook(int userId, int bookId)
        {
            Book bookToBorrow = Books.Where(b => b.Id == bookId).FirstOrDefault();
            User targetUser = Users.Where(u => u.Id == userId).FirstOrDefault();

            if (bookToBorrow != null && bookToBorrow.Available == true)
            {
                bookToBorrow.Available = false;
                bookToBorrow.LoanExpiryDate = DateTime.Today.AddDays(7); //Could be an adjustable variable as a future feature implementation
                targetUser.BookIds.Add(bookToBorrow.Id);
                Console.WriteLine($"Book successfully loaned to {targetUser.Name} for {(bookToBorrow.LoanExpiryDate - DateTime.Today).TotalDays} days.");
            }
            else
            {
                User userBorrowingBook = Users.Where(u => u.Id == bookToBorrow.BorrowedBy).FirstOrDefault();
                if (userBorrowingBook != null)
                {
                    Console.WriteLine($"Book is currently on loan to {userBorrowingBook.Name} (ID: {userBorrowingBook.Id})");
                }
                else
                {
                    Console.WriteLine("This book appears to be missing. Ruh-roh.");
                }
            }
        }

        public void ReturnBook(int userId, int bookId)
        {
            Book bookToReturn = Books.Where(b => b.Id == bookId).FirstOrDefault();
            User targetUser = Users.Where(u => u.Id == userId).FirstOrDefault();

            if (bookToReturn != null && bookToReturn.Available == false && targetUser.BookIds.Contains(bookId))
            {
                bookToReturn.Available = true;
                targetUser.BookIds.Remove(bookId);
                Console.WriteLine("Book successfully returned to library.");
            }
            else
            {
                throw new Exception("Error encountered while trying to return book to Library");
            }
        }

        public void AddUser(string name)
        {
            int id = Users.Max(u => u.Id);
            Users.Add(new User { Id = id + 1, Name = name, BookIds = new List<int>() });
        }

        public void EditUser(int userId, string newName)
        {
            User user = Users.Where(u => u.Id == userId).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.Name = newName;
        }

        public User GetUser(int userId)
        {
            User user = Users.Where(u => u.Id == userId).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public void DeleteUser(int userId)
        {
            User user = Users.Where(u => u.Id == userId).FirstOrDefault();
            if (!Users.Remove(user))
            {
                throw new Exception("User not found");
            }
        }

        public List<User> ListUsers()
        {
            return Users;
        }
    }
}
