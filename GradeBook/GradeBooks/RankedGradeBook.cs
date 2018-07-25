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
            int AGradeNumber = studentCount / 5;
            int BGradeNumber = (studentCount / 5) * 2;
            int CGradeNumber = (studentCount / 5) * 3;
            int DGradeNumber = (studentCount / 5) * 4;
            if (studentCount < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            if (gradeList.Take(AGradeNumber).Contains(averageGrade))
            {
                return 'A';
            }
            if (gradeList.Skip(AGradeNumber).Take(BGradeNumber).Contains(averageGrade))
            {
                return 'B';
            }
            if (gradeList.Skip(BGradeNumber).Take(CGradeNumber).Contains(averageGrade))
            {
                return 'C';
            }
            if (gradeList.Skip(CGradeNumber).Take(DGradeNumber).Contains(averageGrade))
            {
                return 'D';
            }
           
            return 'F';
        }
    }
}
