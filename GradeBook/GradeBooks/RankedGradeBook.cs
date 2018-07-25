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
            int TwentyPercent = studentCount / 5;
            int BGradeNumber = (studentCount / 5) * 2;
            int CGradeNumber = (studentCount / 5) * 3;
            int DGradeNumber = (studentCount / 5) * 4;
            if (studentCount < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            if (gradeList.Take(TwentyPercent).Contains(averageGrade))
            {
                return 'A';
            }

            if (gradeList.Skip(TwentyPercent).Take(TwentyPercent).Contains(averageGrade))
            {
                return 'B';
            }

            if (gradeList.Skip(BGradeNumber).Take(TwentyPercent).Contains(averageGrade))
            {
                return 'C';
            }
            if (gradeList.Skip(CGradeNumber).Take(TwentyPercent).Contains(averageGrade))
            {
                return 'D';
            }
           
            return 'F';
        }

        public override void CalculateStatistics()
        {
            int studentCount = Students.Count;
            if (studentCount < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            int studentCount = Students.Count;
            if (studentCount < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
