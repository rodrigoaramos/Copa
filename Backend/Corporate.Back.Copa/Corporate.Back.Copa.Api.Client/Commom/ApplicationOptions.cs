using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Back.Copa.Api.Client.Commom
{
    public class ApplicationOptions
    {
        public const string Property = "AppSettings";
        public string HttpConfig { get; set; } = "";
        public string BaseAddress { get; set; } = "";
        public string UrlAllTeams { get; set; } = "";
    }
}
