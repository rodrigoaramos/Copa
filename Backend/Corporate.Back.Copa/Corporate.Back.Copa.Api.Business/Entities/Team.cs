using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Back.Copa.Api.Business.Entities
{
    public class Team
    {
        public string Id { get; set; } = "";

        public string Name { get; set; } = "";

        public string Initials { get; set; } = "";

        public int Goals { get; set; } = 0;

        public bool Checked { get; set; } = false;
    }
}
