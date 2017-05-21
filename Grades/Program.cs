using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();

            book.NameChanged += OnNameChange;

            //            book.Name = "Scott's Grade Book";
            //            book.Name = "Grade Book";

            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteGrades(book);
        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteGrades(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }
            WriteResult("Avreage", stats.AverageGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name.");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }

        static void OnNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }
    }
}