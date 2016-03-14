using MiniprojektRAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniprojektRAM.Repository
{
    public interface IRepository
    {
        List<Question> GetAllCategorieQuestions();
        List<QuestionCategory> GetAllCategories();
    }
}
