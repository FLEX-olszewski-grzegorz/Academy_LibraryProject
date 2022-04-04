using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Academy_LibraryProject.Model;

namespace Academy_LibraryProject
{
    internal static class SaveLoadService
    {
        private const string DatabaseDirectory = "Data";

        private const string ReadersDatabaseName = "Readers.json";
        private const string BooksDatabaseName = "Books.json";
        private const string BorrowingDatabaseName = "Borrowing.json";

        public static bool LoadDatabase(ref List<Reader> readers, ref List<Book> books, ref List<Borrowing> borrowings)
        {

            readers = LoadListFromFile<Reader>(GetDatabaseFilePath(ReadersDatabaseName));
            books = LoadListFromFile<Book>(GetDatabaseFilePath(BooksDatabaseName));
            borrowings = LoadListFromFile<Borrowing>(GetDatabaseFilePath(BorrowingDatabaseName));

            return true;
        }

        internal static void SaveDatabase(List<Reader> readers, List<Book> books, List<Borrowing> borrowings)
        {
            CreateSaveDirectory();

            SaveListAsJson(readers, GetDatabaseFilePath(ReadersDatabaseName));
            SaveListAsJson(books, GetDatabaseFilePath(BooksDatabaseName));
            SaveListAsJson(borrowings, GetDatabaseFilePath(BorrowingDatabaseName));
        }

        private static string GetDatabaseFilePath(string databaseName)
        {
            return Path.Combine(DatabaseDirectory, databaseName);
        }

        private static void CreateSaveDirectory()
        {
            if (!System.IO.Directory.Exists(DatabaseDirectory))
            {
                System.IO.Directory.CreateDirectory(DatabaseDirectory);
            }
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
