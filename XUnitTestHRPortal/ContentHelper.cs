﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace XUnitTestHRPortal
{
    public static class ContentHelper
    {
        public static StringContent GetStringContent(object obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
    }
}
