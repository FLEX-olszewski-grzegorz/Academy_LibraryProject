using System;
using System.Collections.Generic;
using Academy_LibraryProject.Model;

namespace Academy_LibraryProject
{
    internal class Program
    {
        private static LibraryManager _libraryManager = new LibraryManager();

        private static string _emptyLine = "---------------------";

        static void Main(string[] args)
        {
            ShowMainMenu();

            while (InteractWithUserAtMainMenu())
            {

            }

            _libraryManager.SaveDatabase();
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("Witaj w ADZB (Aplikacji do zarządzania biblioteką)!");
            Console.WriteLine("Jak mogę Ci pomóc?");
            Console.WriteLine(_emptyLine);

            foreach (var availableAction in _libraryManager.GetAvailableActions())
            {
                Console.WriteLine(availableAction);
            }

            Console.WriteLine(_emptyLine);
        }

        private static bool InteractWithUserAtMainMenu()
        {
            string userInput = Console.ReadLine();

            int? isNumericInput = userInput.ParseToInteger();

            if (!isNumericInput.HasValue)
            {
                return false;
            }

            if (!Enum.IsDefined(typeof(LibraryActions), isNumericInput.Value))
            {
                Console.WriteLine("Wskaż jedną z dostępnych akcji");
                Console.WriteLine(_emptyLine);
                return true;
            }

            LibraryActions action = (LibraryActions)isNumericInput.Value;
            switch (action)
            {
                case LibraryActions.BorrowOrReturn:
                    PerformBorrowOrReturn();
                    break;
                case LibraryActions.AddReader:
                    AddNewReader();
                    break;
                case LibraryActions.AddBook:
                    AddNewBook();
                    break;
                default:
                    break;
            }

            return true;
        }

        private static void PerformBorrowOrReturn()
        {
            Console.WriteLine(_emptyLine);

            Reader reader = GetReaderFromUser();
            if (reader == null)
            {
                Console.WriteLine("Czytelnik nie został odnaleziony w bazie");
            }

            Book book = GetBookFromUser();
            if (book == null)
            {
                Console.WriteLine("Ksiązka nie została odnaleziona w bazie");
            }

            _libraryManager.BorrowOrReturnBook(book, reader);

            Console.WriteLine();
            Console.WriteLine($"Użytkownik: {reader} wypożyczył książkę: {book}");
            Console.WriteLine(_emptyLine);
        }

        private static void AddNewReader()
        {
            Console.WriteLine(_emptyLine);
            Console.WriteLine("Podaj imię nowego cztelnika:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Podaj nazwisko nowego cztelnika:");
            string lastName = Console.ReadLine();

            Reader reader = _libraryManager.AddReader(firstName, lastName);
            Console.WriteLine();
            Console.WriteLine($"Dodałem czytelnika: {reader}");
            Console.WriteLine(_emptyLine);
        }

        private static void AddNewBook()
        {
            Console.WriteLine(_emptyLine);
            Console.WriteLine("Podaj tytuł nowej książki:");
            string title = Console.ReadLine();

            Console.WriteLine("Podaj autora nowej książki:");
            string author = Console.ReadLine();

            Book book = _libraryManager.AddBook(title, author);
            Console.WriteLine();
            Console.WriteLine($"Dodałem książkę: {book}");
            Console.WriteLine(_emptyLine);
        }

        private static Reader GetReaderFromUser()
        {
            Reader reader = null;
            do
            {
                Console.WriteLine("Podaj id cztelnika:");
                string readerIdAsString = Console.ReadLine();
                if (string.IsNullOrEmpty(readerIdAsString))
                {
                    break;
                }

                int? readerId = readerIdAsString.ParseToInteger();
                if (readerId.HasValue)
                {
                    reader = _libraryManager.GetReader(readerId.Value);
                    break;
                }
            } while (true);
            return reader;
        }

        private static Book GetBookFromUser()
        {
            Book book = null;
            do
            {
                Console.WriteLine("Podaj id książki:");
                string readerIdAsString = Console.ReadLine();
                if (string.IsNullOrEmpty(readerIdAsString))
                {
                    break;
                }

                int? readerId = readerIdAsString.ParseToInteger();
                if (readerId.HasValue)
                {
                    book = _libraryManager.GetBook(readerId.Value);
                    break;
                }
            } while (true);
            return book;
        }
    }
}
