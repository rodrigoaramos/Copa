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
        Task<IEnumerable<TeamViewModel>> AllTeams();

        Task<CupResultViewModel> DoGamming(Team[] teams);
    }
}
