using exam2.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam2.Factory
{
   public abstract class QuizCreator
    {
        public abstract IQuiz Create(string log);
    }
}
