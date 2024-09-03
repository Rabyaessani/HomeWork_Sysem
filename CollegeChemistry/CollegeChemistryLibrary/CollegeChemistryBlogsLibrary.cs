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
            string url = $"{baseUrl}{col_chem_api_controller_name}/{blogId}";
            return _colchemWebApi.GetRecords(url , ApiKey, ApiHeader);
        }

        public int AddBlog(string baseUrl, string ApiKey, string ApiHeader, Blogs blog)
        {
            string blogData = JsonSerializer.Serialize(blog, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            
            string url = $"{baseUrl}{col_chem_api_controller_name}/postblog";


            string response = _colchemWebApi.CommitPostActionWithReturn(blogData, url, ApiKey, ApiHeader);
            if (int.TryParse(response, out int blogId))
            {
                return blogId;
            }
            else
            {
                // Handle the case where the response is not a valid integer (e.g., log an error or throw an exception)
                throw new InvalidOperationException("The API response did not return a valid blog ID.");
            }
        }

        public bool DeleteBlog(string baseUrl, string ApiKey, string ApiHeader, Blogs blog)
        {
            string blogData = JsonSerializer.Serialize(blog, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });


            string url = $"{baseUrl}{col_chem_api_controller_name}";

            // Send the request to the delete endpoint
            string response = _colchemWebApi.CommitPostActionWithReturn(blogData, url, ApiKey, ApiHeader);

            // Determine if the deletion was successful
            if (!string.IsNullOrEmpty(response) && response.Contains("success", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public bool UpdateBlog(string baseUrl, string ApiKey, string ApiHeader, Blogs blog)
        {
            string blogData = JsonSerializer.Serialize(blog, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            string url = $"{baseUrl}{col_chem_api_controller_name}";
            string response = _colchemWebApi.CommitPostActionWithReturn(blogData, url, ApiKey, ApiHeader);

            if (!string.IsNullOrEmpty(response) && response.Contains("success", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}
