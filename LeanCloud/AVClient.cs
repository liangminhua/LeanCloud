using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeanCloud
{
    public class AVClient
    {
        internal static string AppId;
        internal static string AppKey;
        public static void Initialize(string appId, string appKey)
        {
            AppId = appId;
            AppKey = appKey;
            AVUser.CurrentUser = new AVUser();
            AVUser.CurrentUser.Reload();
        }
    }
}
