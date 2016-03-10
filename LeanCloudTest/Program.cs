using LeanCloud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeanCloudTest
{
    class ContentsWithQrcode
    {
        public string printerText { get; set; }
        public string qrcode { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.run();
            Console.ReadLine();
        }

        async void run()
        {
            // 初始化
            AVClient.Initialize("", "");
            // 云函数参数
            Dictionary<string, object> paramters = new Dictionary<string, object> { { "printerText", null } };
            try
            {
                //调用云函数
                var res = await AVCloud.CallFunctionAsync<ContentsWithQrcode>("createDeliverTask", paramters);
                Console.WriteLine(res.qrcode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
