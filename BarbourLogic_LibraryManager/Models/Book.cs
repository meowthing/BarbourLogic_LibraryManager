using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbourLogic_LibraryManager.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Available { get; set; }
        public int BorrowedBy { get; set; }
        public DateTime LoanExpiryDate { get; set; }
    }
}
