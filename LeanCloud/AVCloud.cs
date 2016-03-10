using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanCloud
{
    public class AVCloud
    {
        public static async Task<string> CallFunctionAsync(string funcName, IDictionary<string, object> parameters, CancellationToken cancellationToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-LC-Id", AVClient.AppId);
            client.DefaultRequestHeaders.Add("X-LC-Key", AVClient.AppKey);
            client.DefaultRequestHeaders.Add("X-LC-Session", AVUser.CurrentUser.SessionToken);
            StringContent content = null;
            if (parameters != null)
            {
                string serializeParameters = Newtonsoft.Json.JsonConvert.SerializeObject(parameters);
                content = new StringContent(serializeParameters, Encoding.UTF8, "application/json");
            }
            try
            {
                HttpResponseMessage response = await client.PostAsync(new Uri(string.Format("https://api.leancloud.cn/1.1/functions/{0}", funcName)), content, cancellationToken);
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    Newtonsoft.Json.Linq.JObject cloundFunctionResult = Newtonsoft.Json.Linq.JObject.Parse(responseBody);
                    return cloundFunctionResult["result"].ToString();
                }
                else
                {
                    Debug.WriteLine(responseBody);
                    throw Newtonsoft.Json.JsonConvert.DeserializeObject<Error>(responseBody).TOAVException();
                }
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(ex.Message);
                var logPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "printWPF.log");
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(logPath, true))
                {
                    file.WriteLine(DateTime.Now.ToString() + "\r\n" + ex.ToString() + "\r\n" + ex.Message + "\r\n");
                }
                return null;
            }
        }
        public static async Task<string> CallFunctionAsync(string funcName, IDictionary<string, object> parameters)
        {
            return await CallFunctionAsync(funcName, parameters, CancellationToken.None);
        }
        public static async Task<T> CallFunctionAsync<T>(string funcName, IDictionary<string, object> parameters)
        {
            try
            {
                var objString = await CallFunctionAsync(funcName, parameters);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(objString);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return default(T);
            }
        }
    }
}
