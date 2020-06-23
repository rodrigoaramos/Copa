using Corporate.Back.Copa.Api.Business.Entities;
using Corporate.Back.Copa.Api.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Back.Copa.Core.Contracts
{
    public interface ITeamsCupClientService
    {
        /// <summary>
        /// List all teams
        /// </summary>
        Task<IEnumerable<TeamViewModel>> AllTeams();

        /// <summary>
        /// Do gamming matching
        /// </summary>
        Task<CupResultViewModel> DoGamming(Team[] teams);
    }
}
