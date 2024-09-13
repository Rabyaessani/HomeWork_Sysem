using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollegeChemistryAPI.Repositories
{
    public class LessonsRepository : Interface_Lessons
    {
        private readonly CollegeChemistryDbContext _college_chemistry_Db_Context;
        private readonly ILogger<LessonsRepository> _logger;
        public LessonsRepository(CollegeChemistryDbContext college_chemistry_Db_Context
            , ILogger<LessonsRepository> logger)
        {
            _college_chemistry_Db_Context = college_chemistry_Db_Context;
            _logger = logger;
        }

        public int AddLesson(Lessons lessons)
        {
            try
            {
                _college_chemistry_Db_Context.Lessons.Add(lessons);
                _college_chemistry_Db_Context.SaveChanges();
                return lessons.id;
            }
            catch (Exception exc)
            {
                _logger.LogError($"LessonRepository > AddLesson() {exc.ToString()}");
                return 0;
            }
        }

        public bool DeleteLesson(Lessons lessons)
        {
            try
            {
                _college_chemistry_Db_Context.Lessons.Remove(lessons);
                _college_chemistry_Db_Context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {

                _logger.LogError($"LessonsRepository > Deletelessons() {exc.ToString()}");
                return false;
            }
        }

        public IEnumerable<Lessons> GetAllLessons()
        {
            try
            {
                return _college_chemistry_Db_Context.Lessons.ToList();
            }
            catch (Exception exc)
            {
                _logger.LogError($"essonsRepository > GetAllLessons() {exc.ToString()}");
                return null;
            }
        }

        public IEnumerable<Lessons> GetAllPublishLessons(bool ispublish)
        {
            try
            {
                return _college_chemistry_Db_Context.Lessons
                  .Where(l => l.ispublish == ispublish)
                  .ToList();
            }
            catch (Exception exc)
            {
                _logger.LogError($"essonsRepository > GetAllLessons() {exc.ToString()}");
                return null;
            }
        }

        public Lessons GetLessonById(int LessonId)
        {
            try
            {
                return _college_chemistry_Db_Context.Lessons.Where(x => x.id == LessonId).FirstOrDefault();
            }
            catch (Exception exc)
            {
                _logger.LogError($"lessonsRepository > GetLessonsById() {exc.ToString()}");
                return null;
            }
            throw new System.NotImplementedException();
        }

        public bool UpdateLesson(Lessons lessons)
        {
            try
            {
                _college_chemistry_Db_Context.Lessons.Update(lessons);
                _college_chemistry_Db_Context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {

                _logger.LogError($"LessonsRepository > UpdateLessons() {exc.ToString()}");
                return false;
            }
        }

        public bool PublishLesson(int id, bool ispublish, DateTime? published_at)
        {
            try
            {
                // Find the lesson by its ID
                var lesson = _college_chemistry_Db_Context.Lessons.FirstOrDefault(l => l.id == id);

                
                if (lesson != null)
                {
                    lesson.ispublish = ispublish; // Update only the isPublish field
                    lesson.published_at = published_at;
                    _college_chemistry_Db_Context.SaveChanges(); // Save changes to the database
                    return true;
                }
                else
                {
                    
                    _logger.LogError($"Lesson with ID {id} not found.");
                    return false;
                }
            }
            catch (Exception exc)
            {
                
                _logger.LogError($"LessonsRepository > PublishLesson() {exc.ToString()}");
                return false;
            }
        }

    }
}
