
using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace CollegeChemistryAdmin.Repositories
{
    public class BlogsRepository : Interface_Blogs
    {
        private CollegeChemistryLibrary.CollegeChemistryBlogsLibrary _hllWebApi = new CollegeChemistryLibrary.CollegeChemistryBlogsLibrary();
        private IConfiguration _appConfig { get; }
        private string _webApibaseUrl;
        string _hlabApiKey;
        string _ApiHeader;

        public BlogsRepository(IConfiguration appConfig)
        {
            _appConfig = appConfig;
            _webApibaseUrl = _appConfig["AppSettings:CollegeChemistryWebApiBaseUrl"];
            _hlabApiKey = _appConfig["AppSettings:CollegeChemistryApiKey"];
            _ApiHeader = _appConfig["AppSettings:ApiHeaderKey"];
        }
        public int AddBlog(Blogs blog)
        {
            
            var responseJson = _hllWebApi.AddBlog(blog, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var addedBlogId = JsonConvert.DeserializeObject<int>(responseJson);
            return addedBlogId;
            
        }

        public bool DeleteBlog(Blogs blog)
        {
            var responseJson = _hllWebApi.DeleteBlog(blog, _webApibaseUrl, _hlabApiKey, _ApiHeader);

            var response = JsonConvert.DeserializeObject<bool>(responseJson);
            return response;
        }

        public IEnumerable<Blogs> GetAllBlogs()
        {
            var jsonList = _hllWebApi.GetAllBlogs( _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var customerTicketsList = JsonConvert.DeserializeObject<List<Blogs>>(jsonList);
            return customerTicketsList;
        }

        public Blogs GetBlogById(int blogid)
        {
            

            var responseJson = _hllWebApi.GetBlogById(_webApibaseUrl,_hlabApiKey, _ApiHeader, blogid);

            Console.WriteLine($"API Response: {responseJson}");
            var getblog = JsonConvert.DeserializeObject<Blogs>(responseJson);
            if (string.IsNullOrWhiteSpace(responseJson))
            {
                // _logger.LogWarning($"No data returned for Blog ID: {blogId}");
                return null;
            }
            return getblog;
        }

        public bool UpdateBlog(Blogs blog)
        {
            var responseJson = _hllWebApi.UpdateBlog(blog, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            
            var response = JsonConvert.DeserializeObject<bool>(responseJson);
            return response;
        }
    }
}
