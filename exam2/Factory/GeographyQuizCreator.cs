using exam2.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam2.Factory
{
    class GeographyQuizCreator: QuizCreator
    {
        public override IQuiz Create(string log)
        {
            return new GeographyQuiz(log);
        }
    }
}
