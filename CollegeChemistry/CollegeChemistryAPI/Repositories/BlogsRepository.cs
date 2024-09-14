using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace CollegeChemistryAPI.Repositories
{
    public class BlogsRepository : Interface_Blogs
    {
        private readonly CollegeChemistryDbContext _college_chemistry_Db_Context;
        private readonly ILogger<BlogsRepository> _logger;
        public BlogsRepository(CollegeChemistryDbContext college_chemistry_Db_Context
            , ILogger<BlogsRepository> logger)
        {
            _college_chemistry_Db_Context = college_chemistry_Db_Context;
            _logger = logger;
        }

        public int AddBlog(Blogs blog)
        {
            
            try
            {
                _college_chemistry_Db_Context.Blogs.Add(blog);
                _college_chemistry_Db_Context.SaveChanges();
                return blog.id;
            }
            catch (Exception exc)
            {
                _logger.LogError($"BlogsRepository > AddBlog() {exc.ToString()}");
                return 0;
            }
        }

        public bool DeleteBlog(Blogs blog)
        {
            try
            {
                _college_chemistry_Db_Context.Blogs.Remove(blog);
                _college_chemistry_Db_Context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {

                _logger.LogError($"BlogsRepository > DeleteBlog() {exc.ToString()}");
                return false;
            }
        }

        public IEnumerable<Blogs> GetAllBlogs()
        {
            try
            {
                return _college_chemistry_Db_Context.Blogs.ToList();
            }
            catch (Exception exc)
            {
                _logger.LogError($"BlogsRepository > GetAllBlogs() {exc.ToString()}");
                return null;
            }
        }

        public Blogs GetBlogById(int blogid)
        {
            try
            {
                return _college_chemistry_Db_Context.Blogs.Where(x=>x.id==blogid).FirstOrDefault();
            }
            catch (Exception exc)
            {
                _logger.LogError($"BlogsRepository > GetBlogById() {exc.ToString()}");
                return null;
            }
        }

        public bool UpdateBlog(Blogs blog)
        {
            try
            {
                _college_chemistry_Db_Context.Blogs.Update(blog);
                _college_chemistry_Db_Context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {

                _logger.LogError($"BlogsRepository > UpdateBlog() {exc.ToString()}");
                return false;
            }
        }

        public bool PublishBlog(int id, bool ispublish, DateTime? published_at)
        {
            try
            {
                // Find the lesson by its ID
                var blog = _college_chemistry_Db_Context.Blogs.FirstOrDefault(b => b.id == id);


                if (blog != null)
                {
                    blog.ispublish = ispublish; // Update only the isPublish field
                    blog.published_at = published_at;
                    _college_chemistry_Db_Context.SaveChanges(); // Save changes to the database
                    return true;
                }
                else
                {

                    _logger.LogError($"Blog with ID {id} not found.");
                    return false;
                }
            }
            catch (Exception exc)
            {

                _logger.LogError($"blogRepository > PublishBlog() {exc.ToString()}");
                return false;
            }
        }
        public IEnumerable<Blogs> GetAllPublishBlogs(bool ispublish)
        {
            try
            {
                return _college_chemistry_Db_Context.Blogs
                  .Where(b => b.ispublish == ispublish)
                  .ToList();
            }
            catch (Exception exc)
            {
                _logger.LogError($"blogsRepository > GetAllPublishblogs() {exc.ToString()}");
                return null;
            }
        }
    }
}
