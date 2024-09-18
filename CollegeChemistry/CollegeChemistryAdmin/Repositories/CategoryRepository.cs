using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Newtonsoft.Json;
using System.Reflection.Metadata;

namespace CollegeChemistryAdmin.Repositories
{
    public class CategoryRepository : Interface_Category
    {
        private CollegeChemistryLibrary.CollegeChemistryCategoryLibrary _hllWebApi = new CollegeChemistryLibrary.CollegeChemistryCategoryLibrary();
        private IConfiguration _appConfig { get; }
        private string _webApibaseUrl;
        string _hlabApiKey;
        string _ApiHeader;
        public CategoryRepository(IConfiguration appConfig)
        {
            _appConfig = appConfig;
            _webApibaseUrl = _appConfig["AppSettings:CollegeChemistryWebApiBaseUrl"];
            _hlabApiKey = _appConfig["AppSettings:CollegeChemistryApiKey"];
            _ApiHeader = _appConfig["AppSettings:ApiHeaderKey"];
        }
        public int AddCategory(Category category)
        {
            var jsonList = _hllWebApi.AddCategory(category, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<int>(jsonList);
            return response;
        }

        public bool DeleteCategory(Category category)
        {
            var responseJson = _hllWebApi.DeleteCategory(category, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<bool>(responseJson);
            return response;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            var jsonList = _hllWebApi.GetAllCategory(_webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<List<Category>>(jsonList);
            return response;
        }

        public IEnumerable<Category> GetAllPublishCategory()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int categoryid)
        {
            var jsonList = _hllWebApi.GetCategoryById(categoryid, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<Category>(jsonList);
            return response;
        }

        public bool PublishCategory(int id, bool ispublish, DateTime? published_at)
        {
            var responseJson = _hllWebApi.PublishCategory(id, ispublish, published_at, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<bool>(responseJson);
            return response;
        }

        public bool UpdateCategory(Category category)
        {
            var jsonList = _hllWebApi.UpdateCategory(category, _webApibaseUrl, _hlabApiKey, _ApiHeader);
            var response = JsonConvert.DeserializeObject<bool>(jsonList);
            return response;
        }
    }
}
