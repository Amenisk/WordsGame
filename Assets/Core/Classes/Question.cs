using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Classes
{
    public class Question
    {
        public string QuestionText { get; private set; }
        public string AnswerText { get; private set; }
        public string Type { get; private set; }

        public Question(string questionText, string answerText, string type)
        {
            QuestionText = questionText;
            AnswerText = answerText;
            Type = type;
        }

        public Question()
        {

        }
    }
}
