
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
            var jsonList = _hllWebApi.AddBlog(blog, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<int>(jsonList);
            return response;
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
            var response = JsonConvert.DeserializeObject<List<Blogs>>(jsonList);
            return response;
        }

        public Blogs GetBlogById(int blogid)
        {
            var jsonList = _hllWebApi.GetBlogById(blogid,_webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<Blogs>(jsonList);
            return response;
        }

        public bool UpdateBlog(Blogs blog)
        {
            var jsonList = _hllWebApi.UpdateBlog(blog, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<bool>(jsonList);
            return response;
        }

        public IEnumerable<Blogs> GetAllPublishBlogs(bool ispublish)
        {
            throw new NotImplementedException();
        }

        public bool PublishBlog(int id, bool ispublish, DateTime? published_at)
        {
            var responseJson = _hllWebApi.PublishBlog(id, ispublish, published_at, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<bool>(responseJson);
            return response;
        }
    }
}
