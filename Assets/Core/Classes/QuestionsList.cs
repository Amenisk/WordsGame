using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Core.Classes
{
    public class QuestionsList
    {
        private List<Question> _questions = new List<Question>() 
        { 
            new Question("Самая тонкая природная нить", "Паутина"), 
            new Question("Волки это единственные животныеб способные на ...", "Месть"),
            new Question("По форме чего отличают хищников и их жертв?", "Зрачок"),
            new Question("У одного из 200 людей есть дополнительное ...", "Ребро"),
            new Question("Что замедляют прыщи?", "Старение")
        };

        public Question GetRandomQuestion()
        {
            Random rnd = new Random();
            var number = rnd.Next(0, _questions.Count);
            int count = 0;

            foreach(var q in _questions)
            {
                if(count == number)
                {
                    return q;
                }
                count++;
            }

            return null;
        }

        public void AddQuestion(Question question)
        {
            _questions.Add(question);
        }
    }
}
