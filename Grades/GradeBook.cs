using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games;

namespace Grades
{
    public class GradeBook: GradeTracker
    {
        public GradeBook()
        {
            grades = new List<float>();
        }

        protected List<float> grades;

        public event EventHandler<NameChangeEventArgs> NameChanged;

        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook::ComputeStatistics");
            GradeStatistics stats = new GradeStatistics();
            float sum = 0;
            foreach (float grade in grades)
            {
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count;
            return stats;
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        public void WriteGradesInReverse(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }
    }
}