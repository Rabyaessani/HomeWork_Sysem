using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Newtonsoft.Json;

namespace CollegeChemistryAdmin.Repositories
{
    public class MCQRepository:MCQs_Interface
    {
        private CollegeChemistryLibrary.CollegeChemistryMCQsLibrary _hllWebApi = new CollegeChemistryLibrary.CollegeChemistryMCQsLibrary();
        private IConfiguration _appConfig { get; }
        private string _webApibaseUrl;
        string _hlabApiKey;
        string _ApiHeader;

        public MCQRepository(IConfiguration appConfig)
        {
            _appConfig = appConfig;
            _webApibaseUrl = _appConfig["AppSettings:CollegeChemistryWebApiBaseUrl"];
            _hlabApiKey = _appConfig["AppSettings:CollegeChemistryApiKey"];
            _ApiHeader = _appConfig["AppSettings:ApiHeaderKey"];
        }

        public int AddMCQ(MCQs mcq)
        {
            var jsonList = _hllWebApi.AddMCQ(mcq, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<int>(jsonList);
            return response;
        }

        public bool DeleteMCQ(MCQs mcq)
        {
            var responseJson = _hllWebApi.DeleteMCQ(mcq, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<bool>(responseJson);
            return response;
        }

        public IEnumerable<MCQs> GetAllMCQs()
        {
            var jsonList = _hllWebApi.GetAllMCQs(_webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<List<MCQs>>(jsonList);
            return response;
        }

        public MCQs GetMCQsById(int MCQid)
        {
            var jsonList = _hllWebApi.GetMCQsById(MCQid, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<MCQs>(jsonList);
            return response;
        }

        public bool UpdateMCQ(MCQs mcq)
        {
            var jsonList = _hllWebApi.UpdateMCQ(mcq, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<bool>(jsonList);
            return response;
        }

        public IEnumerable<MCQs> GetAllPublishMCQs()
        {
            throw new NotImplementedException();
        }

        public bool PublishMCQ(int id, bool ispublish, DateTime? published_at)
        {
            var responseJson = _hllWebApi.PublishMCQ(id, ispublish, published_at, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<bool>(responseJson);
            return response;
        }
    }
}
