using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
     public abstract  class StandardGradeBook :BaseGradeBook
    {
        public StandardGradeBook(string name):base(name)
        {
            Type = GradeBookType.Standard;
        }
    }
}
