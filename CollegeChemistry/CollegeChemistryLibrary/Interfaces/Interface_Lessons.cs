using CollegeChemistryLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeChemistryLibrary.Interfaces
{
    public interface Interface_Lessons
    {
        IEnumerable<Lessons> GetAllLessons();
        Lessons GetLessonById(int Lessonid);
        int AddLesson(Lessons lesson);
        bool UpdateLesson(Lessons lesson);
        bool DeleteLesson(Lessons lesson);
    }
}
