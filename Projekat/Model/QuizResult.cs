using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Model
{
    internal class QuizRessult
    {
        public QuizRessult()
        {
            Question = "";
            Answer = "";
            CorrectAnswer = "";
            IsCorrect = true;
        }
        public string Question { set; get; }
        public string Answer { set; get; }
        public string CorrectAnswer { set; get; }
        public bool IsCorrect { set; get; }
    }
}
