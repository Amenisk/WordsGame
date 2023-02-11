using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Classes
{
    public class Game
    {
        public Question CurrentQuestion { get; private set; } = new Question();

        private QuestionsList _list = new QuestionsList();

        public int CountLetters { get; set; }
        public Game()
        {
            ChangeQuestion();
        }

        public void ChangeQuestion()
        {
            CurrentQuestion = _list.GetRandomQuestion();
        }

        public bool CheckAnswer()
        {
            return CountLetters == CurrentQuestion.AnswerText.Length;
        }
    }
}
