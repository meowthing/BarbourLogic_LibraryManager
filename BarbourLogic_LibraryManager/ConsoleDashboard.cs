using BarbourLogic_LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbourLogic_LibraryManager
{
    internal class ConsoleDashboard
    {
        ILibraryManager libraryManager;

        public ConsoleDashboard()
        {
            List<Book> initialBookStock = new List<Book>()
            {
                new Book() { Id = 1, Author= "James Authorby", Title="Book 1", ISBN="AB1", Available=true},
                new Book() { Id = 2, Author= "Johan Booksbury", Title="Book 2", ISBN="AB2", Available=true},
                new Book() { Id = 3, Author= "Jack Newsly", Title="Book 3", ISBN="AB3", Available=true},
                new Book() { Id = 4, Author= "Jean Paperback", Title="Book 4", ISBN="AB4", Available=true},
                new Book() { Id = 5, Author= "June Novella", Title="Book 5", ISBN="AB5", Available=true}
            };

            List<User> initialUserList = new List<User>();
            {
                new User() { Id = 1, Name = "Ben Borrower" };
                new User() { Id = 2, Name = "Larry Lender" };
            }

            libraryManager = new LibraryManager(initialBookStock, initialUserList);
        }

        public ConsoleDashboard(List<Book> initialBookStock, List<User> initialUserList)
        {
            libraryManager = new LibraryManager(initialBookStock, initialUserList);
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. User management");
                Console.WriteLine("2. Book management");
                Console.WriteLine("3. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        UserManagementOptions();
                        break;
                    case "2":
                        BookManagementOptions();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option selected.");
                        break;
                }
            }
        }

        private void UserManagementOptions()
        {
            Console.WriteLine("User Management");
            Console.WriteLine("===============");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Get user details");
            Console.WriteLine("3. Edit user");
            Console.WriteLine("4. Delete user");
            Console.WriteLine("5. Return to previous menu");

            switch (Console.ReadLine())
            {
                case "1":
                    AddUser();
                    break;
                case "2":
                    GetUserDetails();
                    break;
                case "3":
                    EditUserDetails();
                    break;
                case "4":
                    DeleteUser();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option selected. Returning to previous menu.");
                    return;
            }
        }

        private void BookManagementOptions()
        {
            Console.WriteLine("Book Management");
            Console.WriteLine("===============");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Borrow a book");
            Console.WriteLine("2. Return a book");
            Console.WriteLine("3. List books currently in library");
            Console.WriteLine("4. Return to previous menu.");

            switch (Console.ReadLine())
            {
                case "1":
                    BorrowBook();
                    break;
                case "2":
                    ReturnBook();
                    break;
                case "3":
                    ListBooks();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option selected. Returning to previous menu.");
                    return;
            }
        }

        private void BorrowBook()
        {
            libraryManager.GetBookList();
            Console.WriteLine("Input Book ID");
            string bookId = Console.ReadLine();

            // TODO: Check if book is available.    
            Console.WriteLine("Input user ID");

            libraryManager.BorrowBook(user, bookId);
        }

        private void ReturnBook()
        {

        }
        private void ListBooks()
        {
            libraryManager.GetBookList();
        }

        private void AddUser()
        {

        }

        private void EditUserDetails()
        {

        }

        private void GetUserDetails()
        {

        }

        private void DeleteUser()
        {

        }
    }
}

