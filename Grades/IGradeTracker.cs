using System;
using System.Collections;
using System.IO;
using Games;

namespace Grades
{
    internal interface IGradeTracker : IEnumerable
    {
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter destination);
        string Name { get; set; }
        event EventHandler<NameChangeEventArgs> NameChanged;
    }
}