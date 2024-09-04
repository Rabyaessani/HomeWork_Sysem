using CollegeChemistryLibrary.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CollegeChemistryLibrary
{
    public class CollegeChemistryBlogsLibrary
    {
        private CollegeChemistryLibrary.WebApiLibrary _colchemWebApi = new CollegeChemistryLibrary.WebApiLibrary();
        private string col_chem_api_controller_name = "/api/blogs";
        public string GetAllBlogs( string baseUrl, string ApiKey, string ApiHeader)
        {
            return _colchemWebApi.GetRecords(baseUrl + col_chem_api_controller_name + "/allblogs/", ApiKey, ApiHeader);
        }

        public string GetBlogById(string baseUrl,string ApiKey, string ApiHeader, int blogId)
        {
            return _colchemWebApi.GetRecords(baseUrl + col_chem_api_controller_name+ "/getblogbyid?id" + "=" + blogId, ApiKey, ApiHeader);
        }

        public string AddBlog(Blogs blog,string baseUrl, string ApiKey, string ApiHeader)
        {
            var dataAsString = JsonConvert.SerializeObject(blog);
            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, baseUrl+ col_chem_api_controller_name+ "/addblog", ApiKey, ApiHeader);
        }

        public string DeleteBlog(Blogs blog,string baseUrl, string ApiKey, string ApiHeader)
        {
           var dataAsString = JsonConvert.SerializeObject(blog);
           return _colchemWebApi.CommitPostActionWithReturn(dataAsString, baseUrl + col_chem_api_controller_name + "/deleteblog", ApiKey, ApiHeader);
        }

        public string UpdateBlog(Blogs blog,string baseUrl, string ApiKey, string ApiHeader)
        {
            var dataAsString = JsonConvert.SerializeObject(blog);
            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, baseUrl + col_chem_api_controller_name + "/updateblog", ApiKey, ApiHeader);
        }
    }
}
