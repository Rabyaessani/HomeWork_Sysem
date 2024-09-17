using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CollegeChemistryAPI.Repositories
{
    public class QuestionRepository :Interface_Questions
    {
        private readonly CollegeChemistryDbContext _college_chemistry_Db_Context;
        private readonly ILogger<QuestionRepository> _logger;
        public QuestionRepository(CollegeChemistryDbContext college_chemistry_Db_Context
            , ILogger<QuestionRepository> logger)
        {
            _college_chemistry_Db_Context = college_chemistry_Db_Context;
            _logger = logger;
        }

        public int AddQuestion(Questions question)
        {

            try
            {
                _college_chemistry_Db_Context.Questions.Add(question);
                _college_chemistry_Db_Context.SaveChanges();
                return question.id;
            }
            catch (Exception exc)
            {
                _logger.LogError($"QuestionsRepository > AddQuestion() {exc.ToString()}");
                return 0;
            }
        }

        public bool DeleteQuestion(Questions question)
        {
            try
            {
                _college_chemistry_Db_Context.Questions.Remove(question);
                _college_chemistry_Db_Context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {

                _logger.LogError($"QuestionRepository > DeleteQuestion() {exc.ToString()}");
                return false;
            }
        }

        public IEnumerable<Questions> GetAllQuestions()
        {
            try
            {
                return _college_chemistry_Db_Context.Questions.ToList();
            }
            catch (Exception exc)
            {
                _logger.LogError($"QuestionsRepository > GetAllQuestion() {exc.ToString()}");
                return null;
            }
        }

        public IEnumerable<Questions> GetAllPublishQuestion()
        {
            try
            {
                return _college_chemistry_Db_Context.Questions
                  .Where(q => q.ispublish == true)
                  .ToList();
            }
            catch (Exception exc)
            {
                _logger.LogError($"QuestionsRepository > GetAllQuestions() {exc.ToString()}");
                return null;
            }
        }

        public Questions GetQuestionById(int Questionid)
        {
            try
            {
                return _college_chemistry_Db_Context.Questions.Where(x => x.id == Questionid).FirstOrDefault();
            }
            catch (Exception exc)
            {
                _logger.LogError($"QuestionsRepository > GetQuestionsById() {exc.ToString()}");
                return null;
            }
        }

        public bool UpdateQuestion(Questions question)
        {
            try
            {
                _college_chemistry_Db_Context.Questions.Update(question);
                _college_chemistry_Db_Context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {

                _logger.LogError($"QuestiosRepository > UpdateQuestions() {exc.ToString()}");
                return false;
            }
        }

        public bool PublishQuestions(int id, bool ispublish, DateTime? published_at)
        {
            try
            {
                // Find the lesson by its ID
                var questions = _college_chemistry_Db_Context.Questions.FirstOrDefault(q => q.id == id);


                if (questions != null)
                {
                    questions.ispublish = ispublish; // Update only the isPublish field
                    questions.published_at = published_at;
                    _college_chemistry_Db_Context.SaveChanges(); // Save changes to the database
                    return true;
                }
                else
                {

                    _logger.LogError($"question with ID {id} not found.");
                    return false;
                }
            }
            catch (Exception exc)
            {

                _logger.LogError($"QuestionRepository > PublishQuestion() {exc.ToString()}");
                return false;
            }
        }
    }
}
