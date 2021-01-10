using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam2.Quiz
{
    class BiologyQuiz: quiz
    {
        public BiologyQuiz(string login)
        {
            Count = 0;
            PathQuestons = "BiologyQuiz.txt";
            PathAnswers = "BiologyAnswer.txt";
            PathResultsAll = "ResultAll.txt";
            PathResultThis = "BiologyResults.txt";
            _Login = login;
            _Name = "Биология";
        }
    }
}
