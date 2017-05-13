using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            AverageGrade = 0;
            LowestGrade = float.MaxValue;
            HighestGrade = float.MinValue;
        }


        public float AverageGrade;
        public float LowestGrade;
        public float HighestGrade;
    }
}
