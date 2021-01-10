using exam2.Factory;
using exam2.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam2
{
   public class CreateQuiz
    {
      public  static IQuiz Create(int i,string log)
        {
            IQuiz quiz = null;
            switch (i)
            {
                case 1:
                     quiz = new HistoryQuizCreate().Create(log);

                    break;
                case 2:
                  quiz = new GeographyQuizCreator().Create(log);
                  break;
                case 3:
                  quiz = new BiologyQuizCreator().Create(log);
                  break;
            }
            return quiz;
        }
    }
}
