using Academy_LibraryProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Academy_LibraryProject
{
    internal static class SaveLoadService
    {
        private const string ReadersDatabaseName = "Readers.json";
        private const string BooksDatabaseName = "Books.json";
        private const string BorrowingDatabaseName = "Borrowing.json";


        public static bool LoadDatabase(ref List<Reader> readers, ref List<Book> books, ref List<Borrowing> borrowings)
        {
            readers = LoadListFromFile<Reader>(ReadersDatabaseName);
            books = LoadListFromFile<Book>(BooksDatabaseName);
            borrowings = LoadListFromFile<Borrowing>(BorrowingDatabaseName);

            return true;
        }

        internal static void SaveDatabase(List<Reader> readers, List<Book> books, List<Borrowing> borrowings)
        {
            SaveListAsJson(readers, ReadersDatabaseName);
            SaveListAsJson(books, BooksDatabaseName);
            SaveListAsJson(borrowings, BorrowingDatabaseName);
        }

        private static bool SaveListAsJson<T>(List<T> inputList, string filePath)
        {
            string json = JsonSerializer.Serialize(inputList);

            System.IO.File.WriteAllText(filePath, json);

            return true;
        }

        private static List<T> LoadListFromFile<T>(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return new List<T>();
            }

            string json = System.IO.File.ReadAllText(filePath);
            List<T> result = (List<T>)JsonSerializer.Deserialize(json, typeof(List<T>));

            return result;
        }
    }
}
