using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam2.Quiz
{
  public class HistoryQuiz : quiz
    {
        
       public HistoryQuiz(string login)
        {
            Count = 0;
            PathQuestons = "HistoryQuiz.txt";
            PathAnswers = "HistoryAnswer.txt";
            PathResultsAll = "ResultAll.txt";
            PathResultThis = "HistoryResults.txt";
            _Login = login;
            _Name = "История";
    }

    }
}
