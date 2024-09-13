using CollegeChemistryLibrary.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CollegeChemistryLibrary
{
    public class CollegeChemistryLessonsLibrary
    {
        private CollegeChemistryLibrary.WebApiLibrary _colchemWebApi = new CollegeChemistryLibrary.WebApiLibrary();
        private string col_chem_api_controller_name = "/api/lessons";

        public string GetAllLessons(string baseUrl, string ApiKey, string ApiHeader)
        {
            return _colchemWebApi.GetRecords(baseUrl + col_chem_api_controller_name + "/allLessons/", ApiKey, ApiHeader);
        }
        public string GetLessonsById(string baseUrl, string ApiKey, string ApiHeader, int LessonId)
        {
            string url = $"{baseUrl}{col_chem_api_controller_name}/getlessonbyid?id={LessonId}";
            return _colchemWebApi.GetRecords(url, ApiKey, ApiHeader);
        }

        public string GetAllPublishLessons(string baseUrl, string ApiKey, string ApiHeader, bool ispublish)
        {
            string url = $"{baseUrl}{col_chem_api_controller_name}/allPublishedLessons?ispublish={ispublish}";
            return _colchemWebApi.GetRecords(url, ApiKey, ApiHeader);
        }

        public string AddLesson(Lessons lesson,string baseUrl, string ApiKey, string ApiHeader)
        {
            var dataAsString = JsonConvert.SerializeObject(lesson);
            string url = $"{baseUrl}{col_chem_api_controller_name}/addlesson";
            return _colchemWebApi.CommitPostActionWithReturn(dataAsString,url, ApiKey, ApiHeader);

        }

        public string UpdateLesson(Lessons lessons, string baseUrl, string ApiKey, string ApiHeader)
        {
            var dataAsString = JsonConvert.SerializeObject(lessons);
            string url = $"{baseUrl}{col_chem_api_controller_name}/updatelessons";
            return _colchemWebApi.CommitPostActionWithReturn(dataAsString,url, ApiKey, ApiHeader);
        }

        public string DeleteLesson(Lessons lessons, string baseUrl, string ApiKey, string ApiHeader)
        {
            var dataAsString = JsonConvert.SerializeObject(lessons);
            string url = $"{baseUrl}{col_chem_api_controller_name}/deletelessons";
            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, url, ApiKey, ApiHeader);
        }

        public string PublishLesson(int id, bool ispublish, DateTime? published_at, string baseUrl, string ApiKey, string ApiHeader)
        {
            var publishData = new
            {
                id,
                ispublish,
                published_at
            };

            // Serialize the object to JSON
            var dataAsString = JsonConvert.SerializeObject(publishData);

            
            string url = $"{baseUrl}{col_chem_api_controller_name}/Publishlesson";

            
            return _colchemWebApi.CommitPostActionWithReturn(dataAsString, url, ApiKey, ApiHeader);
        }

    }
}
