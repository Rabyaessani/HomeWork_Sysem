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

        public string GetAllPublishBlogs(string baseUrl, string ApiKey, string ApiHeader, bool ispublish)
        {
            string url = $"{baseUrl}{col_chem_api_controller_name}/allPublishedBlogs?ispublish={ispublish}";
            return _colchemWebApi.GetRecords(url, ApiKey, ApiHeader);
        }

        public string GetBlogById(int blogId,string baseUrl,string ApiKey, string ApiHeader)
        {
            return _colchemWebApi.GetRecords(baseUrl + col_chem_api_controller_name+ "/getblogbyid?id=" + blogId, ApiKey, ApiHeader);
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

        public string PublishBlog(int id, bool ispublish, DateTime? published_at, string baseUrl, string ApiKey, string ApiHeader)
        {
            var publishData = new
            {
                id,
                ispublish,
                published_at
            };

            // Serialize the object to JSON
            var dataAsString = JsonConvert.SerializeObject(publishData);


            string url = $"{baseUrl}{col_chem_api_controller_name}/Publishblog";


            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, url, ApiKey, ApiHeader);
        }
    }
}
