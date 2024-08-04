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

        public void BorrowBook(User user, int bookId)
        {
            Book bookToBorrow = Books.Where(b => b.Id == bookId).FirstOrDefault();
            if (bookToBorrow != null && bookToBorrow.Available == true)
            {
                bookToBorrow.Available = false;
                bookToBorrow.LoanExpiryDate = DateTime.Today.AddDays(7); //Could be an adjustable variable as a future feature implementation
                user.BookIds.Add(bookToBorrow.Id);
                Console.WriteLine($"Book successfully loaned to {user.Name} for {(bookToBorrow.LoanExpiryDate - DateTime.Today).TotalDays} days.");
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

        public void ReturnBook(User user, int bookId)
        {
            Book bookToReturn = Books.Where(b => b.Id == bookId).FirstOrDefault();
            if (bookToReturn != null && bookToReturn.Available == false)
            {
                bookToReturn.Available = true;
                user.BookIds.Remove(bookToReturn.Id);
                Console.WriteLine("Book successfully returned to library.");
            }
        }
    }
}
