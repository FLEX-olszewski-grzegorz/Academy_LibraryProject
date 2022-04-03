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

        public LibraryManager()
        {
            InitalizeAvailableActions();
        }

        public IEnumerable<string> GetAvailableActions()
        {
            foreach (var availableAction in _availableActions)
            {
                yield return $"{(int)availableAction.Key}. {availableAction.Value}";
            }
        }

        private void InitalizeAvailableActions()
        {
            _availableActions = new Dictionary<LibraryActions, string>();
            _availableActions.Add(LibraryActions.BorrowOrReturn, "Borrow/return a book");
            _availableActions.Add(LibraryActions.AddReader, "Add new reader");
            _availableActions.Add(LibraryActions.AddBook, "Add new book");
        }
    }
}
