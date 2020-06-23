using Corporate.Back.Copa.Api.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Back.Copa.Api.Client.ViewModel
{
    public class CupResultViewModel
    {
        /// <summary>
        /// First winner of cup
        /// </summary>
        public Team First { get; set; }

        /// <summary>
        /// Second winner of cup
        /// </summary>
        public Team Second { get; set; }

        /// <summary>
        /// Error on match game
        /// </summary>
        public bool Error { get; set; } = false;

        /// <summary>
        /// Message of error
        /// </summary>
        public string MsgError { get; set; } = "";
    }
}
