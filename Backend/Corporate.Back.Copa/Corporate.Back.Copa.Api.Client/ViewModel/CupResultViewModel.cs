using Corporate.Back.Copa.Api.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Back.Copa.Api.Client.ViewModel
{
    public class CupResultViewModel
    {
        public Team? First { get; set; }

        public Team? Second { get; set; }

        public bool Error { get; set; } = false;

        public string MsgError { get; set; } = "";
    }
}
