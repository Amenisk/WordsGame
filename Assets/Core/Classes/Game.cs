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

        private string _typeQuestion;

        public int CountLetters { get; set; }
        public Game()
        {
            ChangeQuestion();
        }

        public Game(string typeQuestion)
        {
            _typeQuestion = typeQuestion;
            ChangeQuestion();
        }

        public void ChangeQuestion()
        {
            if(_typeQuestion != null)
            {
                CurrentQuestion = _list.GetRandomQuestion(_typeQuestion);
            }
            else
            {
                CurrentQuestion = _list.GetRandomQuestion();
            }
        }

        public bool CheckAnswer()
        {
            return CountLetters == CurrentQuestion.AnswerText.Length;
        }

        public void SetType(string typeQuestion)
        {
            _typeQuestion = typeQuestion;
        }
    }
}
