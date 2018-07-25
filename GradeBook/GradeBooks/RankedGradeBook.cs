using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:StandardGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            List<double> gradeList = Students.Select(x => x.AverageGrade).ToList();
            gradeList=gradeList.OrderByDescending(g=>g).ToList();
            int studentCount = Students.Count;
            int TwentyPrecent = studentCount / 5;
            
            if (studentCount < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            if (gradeList.Take(TwentyPrecent).Contains(averageGrade))
            {
                return 'A';
            }
            gradeList.Skip(TwentyPrecent);
            if (gradeList.Take(TwentyPrecent).Contains(averageGrade))
            {
                return 'B';
            }
            gradeList.Skip(TwentyPrecent);
            if (gradeList.Take(TwentyPrecent).Contains(averageGrade))
            {
                return 'C';
            }
            gradeList.Skip(TwentyPrecent);
            if (gradeList.Take(TwentyPrecent).Contains(averageGrade))
            {
                return 'D';
            }
           
            return 'F';
        }
    }
}
