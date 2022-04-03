using System;
using System.Collections.Generic;
using Academy_LibraryProject.Model;

namespace Academy_LibraryProject
{
    internal class Program
    {
        private static string _emptyLine = "---------------------";

        static void Main(string[] args)
        {
            LibraryManager libraryManager = new LibraryManager();


            Console.WriteLine("Hello in LMA (Library Management App)!");
            Console.WriteLine("How can I serve you?");
            Console.WriteLine(_emptyLine);

            foreach (var availableAction in libraryManager.GetAvailableActions())
            {
                Console.WriteLine(availableAction);
            }

            Console.WriteLine(_emptyLine);

            string userArgument = Console.ReadLine();
            if (string.IsNullOrEmpty(userArgument))
            {

            }



        }
    }
}
