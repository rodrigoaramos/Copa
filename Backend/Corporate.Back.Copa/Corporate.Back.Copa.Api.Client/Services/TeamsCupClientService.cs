using Corporate.Back.Copa.Api.Client.Commom;
using Corporate.Back.Copa.Api.Client.ViewModel;
using Corporate.Back.Copa.Core.Contracts;
using Corporate.Back.Copa.Api.Business.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Corporate.Back.Copa.Api.Business.Contracts;
using Corporate.Back.Copa.Api.Client.Test;

namespace Corporate.Back.Copa.Services
{
    public class TeamsCupClientService : ITeamsCupClientService
    {
        private readonly ApplicationOptions Options;
        private readonly IHttpClientFactory Factory;
        private readonly ITeamsCupBusinessService BusinessService;

        public TeamsCupClientService(IOptions<ApplicationOptions> options, IHttpClientFactory factory, ITeamsCupBusinessService businessService)
        {
            Options = options.Value;
            Factory = factory;
            BusinessService = businessService;
        }

        /// <summary>
        /// List all teams
        /// </summary>
        public async Task<IEnumerable<TeamViewModel>> AllTeams()
        {
            #if DEBUG
            return new MockTeamsSource().GenEquipesTest();  // Mock data source
            #else
            var client = Factory.CreateClient(Options.HttpConfig);
            return await HttpClientExtensions.PostJsonAsync<IEnumerable<TeamViewModel>>(client, Options.UrlAllTeams);
            #endif
        }

        /// <summary>
        /// Do gamming matching
        /// </summary>
        public async Task<CupResultViewModel> DoGamming(Team[] teams)
        {
            BusinessService.DoMatchGames(teams, out Team firstWinner, out Team secondWinner, out string message);
            return new CupResultViewModel() { First = firstWinner, Second = secondWinner, Error = (!string.IsNullOrWhiteSpace(message)), MsgError = message };
        }
    }
}
