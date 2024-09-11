using CollegeChemistryLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeChemistryLibrary.Interfaces
{
  public interface Interface_Questions
    {
        IEnumerable<Questions> GetAllQuestions();
        Questions GetQuestionById(int Questionid);
        int AddQuestion(Questions question);
        bool UpdateQuestion(Questions question);
        bool DeleteQuestion(Questions question);
    }
}
