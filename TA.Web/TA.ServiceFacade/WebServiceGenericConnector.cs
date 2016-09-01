using Newtonsoft.Json;
using Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TA.ServiceFacade
{
    public class WebServiceGenericConnector<T>
    {
      
        readonly static string baseURL = "http://localhost:13822/"; //TO DO get it from the config
        public string Resource { get; set; }

        public T GetData(int id = -1)
        {
            //string uri = webUrl;
            string uri = baseURL + Resource;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                var data = JsonConvert.DeserializeObjectAsync<T>(response.Result).Result;
                return data;
            }
        }

        public List<T> GetDataList(int id = -1)
        {
            //string uri = webUrl;
            string uri = baseURL + Resource;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                var data = JsonConvert.DeserializeObjectAsync<List<T>>(response.Result).Result;
                return data == null ? new List<T>() : data; ;
            }
        }

        public T GetDataById(int id = -1)
        {
            string uri = baseURL + Resource + id;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                var data = JsonConvert.DeserializeObjectAsync<T>(response.Result).Result;
                return data;
            }
        }

        public List<T> GetDataByName(string name)
        {
            //string uri = webUrl;
            string uri = baseURL + Resource + name;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                var data = JsonConvert.DeserializeObjectAsync<List<T>>(response.Result).Result;
                return data == null ? new List<T>() : data; ;
            }
        }

        public List<T> GetDataListById(int id)
        {
            //string uri = webUrl;
            string uri = baseURL + Resource + id;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                var data = JsonConvert.DeserializeObjectAsync<List<T>>(response.Result).Result;
                return data == null ? new List<T>() : data; ;
            }
        }


        public void PostData(T data)
        {
            string uri = baseURL + Resource;
            HttpClient client = new HttpClient();
            HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8,
            "application/json");

            client.PostAsync(new Uri(uri), contentPost);

            //.ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
        }

        public string PostFFData(T data)
        {
            string uri = baseURL + Resource;
            HttpClient client = new HttpClient();
            HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8,
            "application/json");

            var response = client.PostAsync(new Uri(uri), contentPost).Result;

            var value = response.Content.ReadAsStringAsync().Result;
            return value;

            //.ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
        }

        public void PutData(T data)
        {
            string uri = baseURL + Resource;
            HttpClient client = new HttpClient();
            HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8,
            "application/json");

            client.PutAsync(new Uri(uri), contentPost);

            //.ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
        }
    }
}

