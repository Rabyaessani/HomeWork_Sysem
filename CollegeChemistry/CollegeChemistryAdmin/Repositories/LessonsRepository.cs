using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Newtonsoft.Json;
using System.Reflection.Metadata;

namespace CollegeChemistryAdmin.Repositories
{
    public class LessonsRepository: Interface_Lessons
    {
        private CollegeChemistryLibrary.CollegeChemistryLessonsLibrary _hllWebApi = new CollegeChemistryLibrary.CollegeChemistryLessonsLibrary();
        private IConfiguration _appConfig { get; }
        private string _webApibaseUrl;
        string _hlabApiKey;
        string _ApiHeader;
        public LessonsRepository(IConfiguration appConfig)
        {
            _appConfig = appConfig;
            _webApibaseUrl = _appConfig["AppSettings:CollegeChemistryWebApiBaseUrl"];
            _hlabApiKey = _appConfig["AppSettings:CollegeChemistryApiKey"];
            _ApiHeader = _appConfig["AppSettings:ApiHeaderKey"];
        }

        public IEnumerable<Lessons> GetAllLessons()
        {
            var jsonList = _hllWebApi.GetAllLessons(_webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<List<Lessons>>(jsonList);
            return response;
        }

        public Lessons GetLessonById(int LessonId)
        {
            var jsonList = _hllWebApi.GetLessonsById(_webApibaseUrl, _hlabApiKey, _ApiHeader,LessonId);
            var response = JsonConvert.DeserializeObject<Lessons>(jsonList);
            return response;
        }

        public int AddLesson(Lessons lesson)
        {
            var jsonList = _hllWebApi.AddLesson(lesson, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<int>(jsonList);
            return response;
        }

        public bool UpdateLesson(Lessons lesson)
        {
            var jsonList = _hllWebApi.UpdateLesson(lesson, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<bool>(jsonList);
            return response;
        }

        public bool DeleteLesson(Lessons lesson)
        {
            var responseJson = _hllWebApi.DeleteLesson(lesson, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<bool>(responseJson);
            return response;
        }
    }
}
