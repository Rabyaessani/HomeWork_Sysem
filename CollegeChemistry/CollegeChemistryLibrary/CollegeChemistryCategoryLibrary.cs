using CollegeChemistryLibrary.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeChemistryLibrary
{
    public class CollegeChemistryCategoryLibrary
    {
        private CollegeChemistryLibrary.WebApiLibrary _colchemWebApi = new CollegeChemistryLibrary.WebApiLibrary();
        private string col_chem_api_controller_name = "/api/category";
        public string GetAllCategory(string baseUrl, string ApiKey, string ApiHeader)
        {
            return _colchemWebApi.GetRecords(baseUrl + col_chem_api_controller_name + "/allcategory/", ApiKey, ApiHeader);
        }

        public string GetAllPublishCategory(string baseUrl, string ApiKey, string ApiHeader)
        {
            string url = $"{baseUrl}{col_chem_api_controller_name}/allPublishedCategory";
            return _colchemWebApi.GetRecords(url, ApiKey, ApiHeader);
        }

        public string GetCategoryById(int categoryId, string baseUrl, string ApiKey, string ApiHeader)
        {
            return _colchemWebApi.GetRecords(baseUrl + col_chem_api_controller_name + "/getcategorybyid?id=" + categoryId, ApiKey, ApiHeader);
        }

        public string AddCategory(Category category, string baseUrl, string ApiKey, string ApiHeader)
        {
            var dataAsString = JsonConvert.SerializeObject(category);
            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, baseUrl + col_chem_api_controller_name + "/addcategory", ApiKey, ApiHeader);
        }

        public string DeleteCategory(Category category, string baseUrl, string ApiKey, string ApiHeader)
        {
            var dataAsString = JsonConvert.SerializeObject(category);
            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, baseUrl + col_chem_api_controller_name + "/deletecategory", ApiKey, ApiHeader);
        }

        public string UpdateCategory(Category category, string baseUrl, string ApiKey, string ApiHeader)
        {
            var dataAsString = JsonConvert.SerializeObject(category);
            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, baseUrl + col_chem_api_controller_name + "/updatecategory", ApiKey, ApiHeader);
        }

        public string PublishCategory(int id, bool ispublish, DateTime? published_at, string baseUrl, string ApiKey, string ApiHeader)
        {
            var publishData = new
            {
                id,
                ispublish,
                published_at
            };

            // Serialize the object to JSON
            var dataAsString = JsonConvert.SerializeObject(publishData);


            string url = $"{baseUrl}{col_chem_api_controller_name}/Publishcategory";


            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, url, ApiKey, ApiHeader);
        }
    }
}
