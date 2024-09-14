using CollegeChemistryLibrary.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeChemistryLibrary
{
    public class CollegeChemistryQuestionsLibrary
    {
        private CollegeChemistryLibrary.WebApiLibrary _colchemWebApi = new CollegeChemistryLibrary.WebApiLibrary();
        private string col_chem_api_controller_name = "/api/questions";

        public string GetAllQuestions(string baseUrl, string ApiKey, string ApiHeader)
        {
            return _colchemWebApi.GetRecords(baseUrl + col_chem_api_controller_name + "/allQuestions/", ApiKey, ApiHeader);
        }

        public string GetAllPublishQuestion(string baseUrl, string ApiKey, string ApiHeader, bool ispublish)
        {
            string url = $"{baseUrl}{col_chem_api_controller_name}/allPublishedQuestions?ispublish={ispublish}";
            return _colchemWebApi.GetRecords(url, ApiKey, ApiHeader);
        }

        public string GetQuestionById(string baseUrl, string ApiKey, string ApiHeader, int Questionid)
        {
            string url = $"{baseUrl}{col_chem_api_controller_name}/getQuestionbyid?id={Questionid}";
            return _colchemWebApi.GetRecords(url, ApiKey, ApiHeader);
        }

        public string AddQuestion(Questions questions, string baseUrl, string ApiKey, string ApiHeader)
        {
            var dataAsString = JsonConvert.SerializeObject(questions);
            string url = $"{baseUrl}{col_chem_api_controller_name}/addquestions";
            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, url, ApiKey, ApiHeader);

        }

        public string UpdateQuestion(Questions questions, string baseUrl, string ApiKey, string ApiHeader)
        {
            var dataAsString = JsonConvert.SerializeObject(questions);
            string url = $"{baseUrl}{col_chem_api_controller_name}/updatequestion";
            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, url, ApiKey, ApiHeader);
        }

        public string DeleteQuestion(Questions questions, string baseUrl, string ApiKey, string ApiHeader)
        {
            var dataAsString = JsonConvert.SerializeObject(questions);
            string url = $"{baseUrl}{col_chem_api_controller_name}/deletequestion";
            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, url, ApiKey, ApiHeader);
        }

        public string PublishQuestions(int id, bool ispublish, DateTime? published_at, string baseUrl, string ApiKey, string ApiHeader)
        {
            var publishData = new
            {
                id,
                ispublish,
                published_at
            };

            // Serialize the object to JSON
            var dataAsString = JsonConvert.SerializeObject(publishData);


            string url = $"{baseUrl}{col_chem_api_controller_name}/Publishquestions";


            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, url, ApiKey, ApiHeader);
        }
    }
}
