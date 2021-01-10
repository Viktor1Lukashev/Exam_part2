using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam2.Quiz
{
    class GeographyQuiz:quiz
    {
        public GeographyQuiz(string login)
        {
            Count = 0;
            PathQuestons = "GeographyQuiz.txt";
            PathAnswers = "GeographyAnswer.txt";
            PathResultsAll = "ResultAll.txt";
            PathResultThis = "GeographyResults.txt";
            _Login = login;
            _Name = "География";
        }

    }
}
