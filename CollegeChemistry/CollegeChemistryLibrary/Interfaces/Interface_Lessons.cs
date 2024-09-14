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
        bool UpdateLesson(Lessons lessons);
        bool DeleteLesson(Lessons lessons);

        bool PublishLesson(int id, bool ispublish, DateTime? published_at);

        IEnumerable<Lessons> GetAllPublishLessons(bool ispublish);

    }
}
