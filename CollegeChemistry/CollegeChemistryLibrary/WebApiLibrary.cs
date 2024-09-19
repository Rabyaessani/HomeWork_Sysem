using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CollegeChemistryLibrary
{
    public class WebApiLibrary
    {
        public static string username = "11195716";
        public static string password = "60-dayfreetrial";
        public static string authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));

        public string GetRecords(string url, string ApiKey, string ApiHeader)
        {
            string stringData;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add(ApiHeader, ApiKey);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                HttpResponseMessage response = client.GetAsync(url).Result;
                stringData = response.Content.ReadAsStringAsync().Result;
            }
            return stringData;
        }

        public string GetRecordsPost(string dataAsString, string url, string ApiKey, string ApiHeader)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var post_url = new Uri(url);
                    var content = new StringContent(dataAsString);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    client.DefaultRequestHeaders.Add(ApiHeader, ApiKey);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                    //HTTP POST
                    var postTask = client.PostAsync(post_url, content);
                    postTask.Wait();

                    var result = postTask.Result;
                    return result.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception xc)
            {
                return "Exception Error: " + xc;
            }
        }

        public string CommitPostActionWithReturn(string dataAsString, string url, string ApiKey, string ApiHeader)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var post_url = new Uri(url);
                    var content = new StringContent(dataAsString);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    client.DefaultRequestHeaders.Add(ApiHeader, ApiKey);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                    //HTTP POST
                    var postTask = client.PostAsync(post_url, content);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return result.Content.ReadAsStringAsync().Result;
                    }
                    return null;
                }
            }
            catch (Exception xc)
            {
                return "Exception Error: " + xc;
            }
        }

        public string CommitPostAction(string dataAsString, string url, string ApiKey, string ApiHeader)
        {
            if (string.IsNullOrEmpty(dataAsString)) return "data string is empty";
            try
            {
                using (var client = new HttpClient())
                {
                    var post_url = new Uri(url);
                    var content = new StringContent(dataAsString);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    client.DefaultRequestHeaders.Add(ApiHeader, ApiKey);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                    //HTTP POST
                    var postTask = client.PostAsync(post_url, content);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return "success";
                    }
                    return "CommitPostAction failed.";
                }
            }
            catch (Exception xc)
            {
                return "Exception Error: " + xc;
            }
        }
    }

}
