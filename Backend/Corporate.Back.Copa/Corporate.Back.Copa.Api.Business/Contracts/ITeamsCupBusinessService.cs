﻿using Corporate.Back.Copa.Api.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Back.Copa.Api.Business.Contracts
{
    public interface ITeamsCupBusinessService
    {
        /// <summary>
        /// Find winners podium
        /// </summary>
        bool DoMatchGames(Team[] teams, out Team firstWinner, out Team secondWinner, out string message);
    }
}
