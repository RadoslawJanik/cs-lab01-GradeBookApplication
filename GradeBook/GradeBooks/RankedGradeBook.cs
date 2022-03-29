using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name,bool isWeighted) : base(name,isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students ");

            int belowInput = 0;

            for (int i = 0; i < Students.Count; i++)
            {
                if (averageGrade > Students[i].AverageGrade)
                {
                    belowInput++;
                }
            }

            int oneFiftOfStudents = Students.Count / 5;

            if (belowInput >= oneFiftOfStudents * 4)
                return 'A';
            else if (belowInput < oneFiftOfStudents * 4 && belowInput >= oneFiftOfStudents * 3)
                return 'B';
            else if (belowInput < oneFiftOfStudents * 3 && belowInput >= oneFiftOfStudents * 2)
                return 'C';
            else if (belowInput < oneFiftOfStudents * 2 && belowInput >= oneFiftOfStudents * 1)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }


    }
}

       

