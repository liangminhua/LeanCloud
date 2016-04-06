using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace LeanCloud
{
    public class AVUser : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        public string Username
        {
            get { return (string)this["UserName"]; }
            set { this["UserName"] = value; }
        }
        [UserScopedSetting()]
        public string SessionToken
        {
            get { return (string)this["SessionToken"]; }
            set
            {
                this["SessionToken"] = value;
                Save();
            }
        }
        public string MobilePhoneNumber { get; set; }
        public bool IsAuthenticated { get { return string.IsNullOrEmpty(SessionToken)? false:true; } }
        public static AVUser CurrentUser;
        public string ObjectId;
        public bool EmailVerified;
        public bool MobilePhoneVerified;

        public static async Task LogInAsync(string username, string password, CancellationToken cancellationToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-LC-Id", AVClient.AppId);
            client.DefaultRequestHeaders.Add("X-LC-Key", AVClient.AppKey);
            try
            {
                HttpResponseMessage response = await client.GetAsync(string.Format("https://api.leancloud.cn/1.1/login?username={0}&password={1}", username, password));
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    CurrentUser = Newtonsoft.Json.JsonConvert.DeserializeObject<AVUser>(responseBody);
                    CurrentUser.Save();
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
            }
        }
        public static async Task LogInAsync(string username, string password)
        {
            await LogInAsync(username, password, CancellationToken.None);
        }
        public static void LogOut()
        {
            CurrentUser.Reset();
        }
    }
}
