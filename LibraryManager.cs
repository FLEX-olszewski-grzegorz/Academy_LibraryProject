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

        public Reader AddReader(string firstName, string lastName)
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
        }
    }
}
