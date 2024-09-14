using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Newtonsoft.Json;
namespace CollegeChemistryAdmin.Repositories
{
    public class QuestionsRepository :Interface_Questions
    {
        private CollegeChemistryLibrary.CollegeChemistryQuestionsLibrary _hllWebApi = new CollegeChemistryLibrary.CollegeChemistryQuestionsLibrary();
        private IConfiguration _appConfig { get; }
        private string _webApibaseUrl;
        string _hlabApiKey;
        string _ApiHeader;

        public QuestionsRepository(IConfiguration appConfig)
        {
            _appConfig = appConfig;
            _webApibaseUrl = _appConfig["AppSettings:CollegeChemistryWebApiBaseUrl"];
            _hlabApiKey = _appConfig["AppSettings:CollegeChemistryApiKey"];
            _ApiHeader = _appConfig["AppSettings:ApiHeaderKey"];
        }

        public int AddQuestion(Questions question)
        {
            var jsonList = _hllWebApi.AddQuestion(question, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<int>(jsonList);
            return response;
        }

        public bool DeleteQuestion(Questions question)
        {
            var responseJson = _hllWebApi.DeleteQuestion(question, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<bool>(responseJson);
            return response;
        }

        public IEnumerable<Questions> GetAllQuestions()
        {
            var jsonList = _hllWebApi.GetAllQuestions(_webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<List<Questions>>(jsonList);
            return response;
        }

        public IEnumerable<Questions> GetAllPublishQuestion(bool ispublish)
        {
            throw new NotImplementedException();
        }

        public Questions GetQuestionById(int questionid)
        {
            var jsonList = _hllWebApi.GetQuestionById( _webApibaseUrl, _hlabApiKey, _ApiHeader , questionid);
            var response = JsonConvert.DeserializeObject<Questions>(jsonList);
            return response;
        }

        public bool UpdateQuestion(Questions question)
        {
            var jsonList = _hllWebApi.UpdateQuestion(question, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<bool>(jsonList);
            return response;
        }

        public bool PublishQuestions(int id, bool ispublish, DateTime? published_at)
        {
            var responseJson = _hllWebApi.PublishQuestions(id, ispublish, published_at, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<bool>(responseJson);
            return response;
        }
    }
}
