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

            List<User> initialUserList = new List<User>()
            {
                new User() { Id = 1, Name = "Ben Borrower", BookIds = new List<int>() },
                new User() { Id = 2, Name = "Larry Lender", BookIds = new List<int>() }
            };

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
            Console.WriteLine("5. List all users");
            Console.WriteLine("6. Return to previous menu");

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
                    ListUsers();
                    break;
                case "6":
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
            int bookId = int.Parse(Console.ReadLine());

            Console.WriteLine("Input user ID");
            int userId = int.Parse(Console.ReadLine());

            libraryManager.BorrowBook(userId, bookId);
        }

        private void ReturnBook()
        {
            // As an improvement the UI flow should be select user first then book

            libraryManager.GetBookList();
            Console.WriteLine("Input Book ID");
            int bookId = int.Parse(Console.ReadLine());

            Console.WriteLine("Input user ID");
            int userId = int.Parse(Console.ReadLine());

            libraryManager.ReturnBook(userId, bookId);
        }

        private void ListBooks()
        {
            libraryManager.GetBookList();
        }

        private void AddUser()
        {
            Console.WriteLine("Input user name");
            string userName = Console.ReadLine();
            try
            {
                libraryManager.AddUser(userName);
                Console.WriteLine("User added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void EditUserDetails()
        {
            Console.WriteLine("Input user ID.");
            int userId = int.Parse(Console.ReadLine());

            try
            {
                User user = libraryManager.GetUser(userId);
                Console.WriteLine("User found. Edit user name? Y/N");
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    Console.WriteLine("Input new user name");
                    string newName = Console.ReadLine();
                    libraryManager.EditUser(userId, newName);
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void GetUserDetails()
        {
            Console.WriteLine("Input user ID.");
            int userId = int.Parse(Console.ReadLine());

            try
            {
                User user = libraryManager.GetUser(userId);
                Console.WriteLine("User found. Details:");
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Number of books currently borrowed: {user.BookIds.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DeleteUser()
        {
            Console.WriteLine("Input user ID.");
            int userId = int.Parse(Console.ReadLine());
            try
            {
                libraryManager.DeleteUser(userId);
                Console.WriteLine("User deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ListUsers()
        {
            List<User> users = libraryManager.ListUsers();
            foreach (User user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Number of books currently borrowed: {user.BookIds.Count}");
            }
        }
    }
}

