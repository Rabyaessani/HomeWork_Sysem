using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace CollegeChemistryAPI.Repositories
{
    public class CategoryRepository : Interface_Category
    {
        private readonly CollegeChemistryDbContext _college_chemistry_Db_Context;
        private readonly ILogger<CategoryRepository> _logger;
        public CategoryRepository(CollegeChemistryDbContext college_chemistry_Db_Context
            , ILogger<CategoryRepository> logger)
        {
            _college_chemistry_Db_Context = college_chemistry_Db_Context;
            _logger = logger;
        }
        public int AddCategory(Category category)
        {
            try
            {
                _college_chemistry_Db_Context.Category.Add(category);
                _college_chemistry_Db_Context.SaveChanges();
                return category.id;
            }
            catch (Exception exc)
            {
                _logger.LogError($"CategoryRepository > AddCategory() {exc.ToString()}");
                return 0;
            }
        }

        public bool DeleteCategory(Category category)
        {
            try
            {
                _college_chemistry_Db_Context.Category.Remove(category);
                _college_chemistry_Db_Context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {

                _logger.LogError($"CategoryRepository > DeleteCategory() {exc.ToString()}");
                return false;
            }
        }

        public IEnumerable<Category> GetAllCategory()
        {
            try
            {
                return _college_chemistry_Db_Context.Category.ToList();
            }
            catch (Exception exc)
            {
                _logger.LogError($"CategoryRepository > GetAllCategory() {exc.ToString()}");
                return null;
            }
        }

        public IEnumerable<Category> GetAllPublishCategory()
        {
            try
            {
                return _college_chemistry_Db_Context.Category
                  .Where(b => b.ispublish == true)
                  .ToList();
            }
            catch (Exception exc)
            {
                _logger.LogError($"CategoryRepository > GetAllPublishCategory() {exc.ToString()}");
                return null;
            }
        }

        public Category GetCategoryById(int categoryid)
        {
            try
            {
                return _college_chemistry_Db_Context.Category.Where(x => x.id == categoryid).FirstOrDefault();
            }
            catch (Exception exc)
            {
                _logger.LogError($"CategoryRepository > GetCategoryById() {exc.ToString()}");
                return null;
            }
        }

        public bool PublishCategory(int id, bool ispublish, DateTime? published_at)
        {
            try
            {
                // Find the lesson by its ID
                var category = _college_chemistry_Db_Context.Category.FirstOrDefault(b => b.id == id);


                if (category != null)
                {
                    category.ispublish = ispublish; // Update only the isPublish field
                    category.published_at = published_at;
                    _college_chemistry_Db_Context.SaveChanges(); // Save changes to the database
                    return true;
                }
                else
                {

                    _logger.LogError($"Category with ID {id} not found.");
                    return false;
                }
            }
            catch (Exception exc)
            {

                _logger.LogError($"CategoryRepository > PublishCategory() {exc.ToString()}");
                return false;
            }
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                _college_chemistry_Db_Context.Category.Update(category);
                _college_chemistry_Db_Context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {

                _logger.LogError($"CategoryRepository > UpdateCategory() {exc.ToString()}");
                return false;
            }
        }
    }
}
