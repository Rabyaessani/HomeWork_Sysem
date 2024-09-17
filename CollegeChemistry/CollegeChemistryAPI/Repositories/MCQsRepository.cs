using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CollegeChemistryAPI.Repositories
{
    public class MCQsRepository:MCQs_Interface
    {
        private readonly CollegeChemistryDbContext _college_chemistry_Db_Context;
        private readonly ILogger<MCQsRepository> _logger;
        public MCQsRepository(CollegeChemistryDbContext college_chemistry_Db_Context
            , ILogger<MCQsRepository> logger)
        {
            _college_chemistry_Db_Context = college_chemistry_Db_Context;
            _logger = logger;
        }

        public int AddMCQ(MCQs mcq)
        {

            try
            {
                _college_chemistry_Db_Context.MCQs.Add(mcq);
                _college_chemistry_Db_Context.SaveChanges();
                return mcq.id;
            }
            catch (Exception exc)
            {
                _logger.LogError($"MCQSRepository > AddMcq() {exc.ToString()}");
                return 0;
            }
        }

        public bool DeleteMCQ(MCQs mcq)
        {
            try
            {
                _college_chemistry_Db_Context.MCQs.Remove(mcq);
                _college_chemistry_Db_Context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {

                _logger.LogError($"MCQsRepository > Deletemcq() {exc.ToString()}");
                return false;
            }
        }

        public IEnumerable<MCQs> GetAllMCQs()
        {
            try
            {
                return _college_chemistry_Db_Context.MCQs.ToList();
            }
            catch (Exception exc)
            {
                _logger.LogError($"mcqsRepository > GetAllMCQs() {exc.ToString()}");
                return null;
            }
        }

        public MCQs GetMCQsById(int MCQid)
        {
            try
            {
                return _college_chemistry_Db_Context.MCQs.Where(x => x.id == MCQid).FirstOrDefault();
            }
            catch (Exception exc)
            {
                _logger.LogError($"MCQSRepository > GetMCQById() {exc.ToString()}");
                return null;
            }
        }

        public bool UpdateMCQ(MCQs mcq)
        {
            try
            {
                _college_chemistry_Db_Context.MCQs.Update(mcq);
                _college_chemistry_Db_Context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {

                _logger.LogError($"MCQRepository > UpdateMCQ() {exc.ToString()}");
                return false;
            }
        }

        public bool PublishMCQ(int id, bool ispublish, DateTime? published_at)
        {
            try
            {
                // Find the lesson by its ID
                var mcq = _college_chemistry_Db_Context.MCQs.FirstOrDefault(b => b.id == id);


                if (mcq != null)
                {
                   mcq.ispublish = ispublish; // Update only the isPublish field
                    mcq.published_at = published_at;
                    _college_chemistry_Db_Context.SaveChanges(); // Save changes to the database
                    return true;
                }
                else
                {

                    _logger.LogError($"MCQ with ID {id} not found.");
                    return false;
                }
            }
            catch (Exception exc)
            {

                _logger.LogError($"mcqRepository > PublishMCQ() {exc.ToString()}");
                return false;
            }
        }
        public IEnumerable<MCQs> GetAllPublishMCQs()
        {
            try
            {
                return _college_chemistry_Db_Context.MCQs
                  .Where(b => b.ispublish == true)
                  .ToList();
            }
            catch (Exception exc)
            {
                _logger.LogError($"MCQRepository > GetAllPublishmcqs() {exc.ToString()}");
                return null;
            }
        }
    }
}
