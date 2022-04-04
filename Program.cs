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

            InteractWithUserAtMainMenu();
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("Welcome in LMA (Library Management App)!");
            Console.WriteLine("How can I serve you?");
            Console.WriteLine(_emptyLine);

            foreach (var availableAction in _libraryManager.GetAvailableActions())
            {
                Console.WriteLine(availableAction);
            }

            Console.WriteLine(_emptyLine);
        }

        private static void InteractWithUserAtMainMenu()
        {
            string userInput = Console.ReadLine();

            int? isNumericInput = GetInputAsInteger(userInput);

            if (isNumericInput.HasValue)
            {


            }
            else
            {
                return;
            }
        }

        private static int? GetInputAsInteger(string userInput)
        {
            int numericInput;

            if (int.TryParse(userInput, out numericInput))
            {
                return numericInput;
            }
            else
            {
                return null;
            }
        }
    }
}
