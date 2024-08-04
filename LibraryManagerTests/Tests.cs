using BarbourLogic_LibraryManager;
using BarbourLogic_LibraryManager.Models;

namespace LibraryManagerTests
{
    public class Tests
    {
        LibraryManager libraryManager;

        [SetUp]
        public void Setup()
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

        [Test]
        public void AddUser()
        {
            Assert.Pass();
        }



        [Test]
        public void EditUser()
        {
            Assert.Pass();
        }



        [Test]
        public void DeleteUser()
        {
            Assert.Pass();
        }




        [Test]
        public void BorrowBook()
        {
            Assert.Pass();
        }



        [Test]
        public void ReturnBook()
        {
            Assert.Pass();
        }



        [Test]
        public void BorrowUnavailableBook()
        {
            Assert.Pass();
        }

        public void ReturnUnborrowedBook()
        {

        }
    }
}