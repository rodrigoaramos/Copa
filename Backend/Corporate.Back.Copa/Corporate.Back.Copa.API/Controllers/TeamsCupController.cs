using Corporate.Back.Copa.Api.Client.TO;
using Corporate.Back.Copa.Api.Client.ViewModel;
using Corporate.Back.Copa.Core.Contracts;
using Corporate.Back.Copa.Api.Business.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Net.Http;
using System.Threading.Tasks;

namespace Corporate.Back.Copa.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsCupController : ControllerBase
    {
        [HttpGet("index")]
        public async Task<IActionResult> Get()
        {
            return new EmptyResult();
        }

        /// <summary>
        /// List all teams of cup
        /// </summary>
        [HttpPost("allteams")]
        public async Task<IEnumerable<TeamViewModel>> Post([FromServices] ITeamsCupClientService teamsCupService)
        {
            return await teamsCupService.AllTeams();
        }

        /// <summary>
        /// Do gaming
        /// </summary>
        [HttpPost("dogaming")]
        public async Task<CupResultViewModel> Post([FromServices] ITeamsCupClientService teamsCupService, TeamsTO teams)
        {
            var result = await teamsCupService.DoGamming(teams.Teams);


            return new CupResultViewModel()
            {
                First = new Team() { Id = "cd8f6b48-97cf-48d8-ba62-6f1d42639c55", Name = "Equipe 13", Initials = "EQP13", Goals = 1 },
                Second = new Team() { Id = "a90b4fd8-9860-44d1-9420-47d4ce5da52d", Name = "Equipe 11", Initials = "EQP11", Goals = 6 }
            };
        }
    }
}
