using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Opdracht1
{
    class Profession
    {
        public string name;
        public int grade;
        public PraticalGrade pgrade;

        public bool CheckGradePositive()
        {
            return grade >= 6;
        }

        public bool CheckGradeCumLaude()
        {
            return grade >= 8;
        }
    }

}
