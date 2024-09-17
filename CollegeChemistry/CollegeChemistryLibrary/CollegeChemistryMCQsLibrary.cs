using CollegeChemistryLibrary.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeChemistryLibrary
{
    public class CollegeChemistryMCQsLibrary
    {
        private CollegeChemistryLibrary.WebApiLibrary _colchemWebApi = new CollegeChemistryLibrary.WebApiLibrary();
        private string col_chem_api_controller_name = "/api/mcqs";

        public string GetAllMCQs(string baseUrl, string ApiKey, string ApiHeader)
        {
            return _colchemWebApi.GetRecords(baseUrl + col_chem_api_controller_name + "/allmcqs/", ApiKey, ApiHeader);
        }

        public string GetAllPublishMCQs(string baseUrl, string ApiKey, string ApiHeader)
        {
            string url = $"{baseUrl}{col_chem_api_controller_name}/allPublishedMCQs";
            return _colchemWebApi.GetRecords(url, ApiKey, ApiHeader);
        }

        public string GetMCQsById(int MCQid, string baseUrl, string ApiKey, string ApiHeader)
        {
            return _colchemWebApi.GetRecords(baseUrl + col_chem_api_controller_name + "/getmcqbyid?id=" + MCQid, ApiKey, ApiHeader);
        }

        public string AddMCQ(MCQs mcq, string baseUrl, string ApiKey, string ApiHeader)
        {
            var dataAsString = JsonConvert.SerializeObject(mcq);
            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, baseUrl + col_chem_api_controller_name + "/addMcq", ApiKey, ApiHeader);
        }

        public string DeleteMCQ(MCQs mcq, string baseUrl, string ApiKey, string ApiHeader)
        {
            var dataAsString = JsonConvert.SerializeObject(mcq);
            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, baseUrl + col_chem_api_controller_name + "/deleteMCQ", ApiKey, ApiHeader);
        }

        public string UpdateMCQ(MCQs mcq, string baseUrl, string ApiKey, string ApiHeader)
        {
            var dataAsString = JsonConvert.SerializeObject(mcq);
            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, baseUrl + col_chem_api_controller_name + "/updateMCQ", ApiKey, ApiHeader);
        }

        public string PublishMCQ(int id, bool ispublish, DateTime? published_at, string baseUrl, string ApiKey, string ApiHeader)
        {
            var publishData = new
            {
                id,
                ispublish,
                published_at
            };

            // Serialize the object to JSON
            var dataAsString = JsonConvert.SerializeObject(publishData);


            string url = $"{baseUrl}{col_chem_api_controller_name}/PublishMCQ";


            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, url, ApiKey, ApiHeader);
        }
    }
}
