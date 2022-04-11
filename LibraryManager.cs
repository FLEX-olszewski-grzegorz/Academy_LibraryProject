using Academy_LibraryProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_LibraryProject
{
    internal class LibraryManager
    {
        private Dictionary<LibraryActions, string> _availableActions;
        private LibraryDatabase _database;

        public LibraryManager()
        {
            InitalizeAvailableActions();
            _database = new LibraryDatabase();
        }

        public IEnumerable<string> GetAvailableActions()
        {
            foreach (var availableAction in _availableActions)
            {
                yield return $"{(int)availableAction.Key}. {availableAction.Value}";
            }
        }

        internal Reader AddReader(string firstName, string lastName)
        {
            int nextId = _database.GetNextIdFor<Reader>();
            Reader newReader = new Reader()
            {
                Id = nextId,
                FirstName = firstName,
                LastName = lastName
            };

            _database.AddReader(newReader);

            return newReader;
        }

        internal Book AddBook(string title, string author)
        {
            int nextId = _database.GetNextIdFor<Book>();
            Book newBook = new Book()
            {
                Id = nextId,
                Title = title,
                Author = author
            };

            _database.AddBook(newBook);

            return newBook;
        }

        internal Borrowing BorrowOrReturnBook(Book book, Reader reader)
        {
            int nextId = _database.GetNextIdFor<Borrowing>();
            Borrowing borrowing = new Borrowing()
            {
                Id = nextId,
                Book = book,
                Reader = reader
            };

            _database.AddNewBorrowing(borrowing);

            return borrowing;
        }

        public bool SaveDatabase()
        {
            _database.SaveDatabase();

            return true;
        }

        private void InitalizeAvailableActions()
        {
            _availableActions = new Dictionary<LibraryActions, string>();
            _availableActions.Add(LibraryActions.BorrowOrReturn, "Wypożycz/oddaj książkę");
            _availableActions.Add(LibraryActions.AddReader, "Dodaj nowego czytelnika");
            _availableActions.Add(LibraryActions.AddBook, "Dodaj nową książkę");
            _availableActions.Add(LibraryActions.ShowReaders, "Wyświetl użytkowników");
        }

        internal Reader GetReader(int value)
        {
            return _database.GetReader(value);
        }

        internal Book GetBook(int value)
        {
            return _database.GetBook(value);
        }
    }
}
