using System;
using System.Collections.Generic;

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
                    break;
                case LibraryActions.AddReader:
                    AddNewReader();
                    break;
                case LibraryActions.AddBook:
                    break;
                default:
                    break;
            }

            return true;
        }

        private static void AddNewReader()
        {
            Console.WriteLine(_emptyLine);
            Console.WriteLine("Podaj imię nowego cztelnika:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Podaj nazwisko nowego cztelnika:");
            string lastName = Console.ReadLine();

            Model.Reader reader = _libraryManager.AddReader(firstName, lastName);
            Console.WriteLine();
            Console.WriteLine($"Dodałem czytelnika: {reader}");
            Console.WriteLine(_emptyLine);
        }
    }
}
