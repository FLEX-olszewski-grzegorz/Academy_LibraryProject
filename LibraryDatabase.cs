using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Academy_LibraryProject.Model;

namespace Academy_LibraryProject
{
    internal class LibraryDatabase
    {
        private List<Reader> _readers;
        private List<Book> _books;
        private List<Borrowing> _borrowings;

        public LibraryDatabase()
        {
            SaveLoadService.LoadDatabase(ref _readers, ref _books, ref _borrowings);
        }

        public bool SaveDatabase()
        {
            SaveLoadService.SaveDatabase(_readers, _books, _borrowings);

            return true;
        }

        public void AddReader(Reader reader)
        {
            _readers.Add(reader);
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void AddNewBorrowing(Borrowing borrowing)
        {
            _borrowings.Add(borrowing);
        }

        public void CloseBorrowing(Borrowing borrowing)
        {
            _borrowings.Remove(borrowing);
        }
    }
}
