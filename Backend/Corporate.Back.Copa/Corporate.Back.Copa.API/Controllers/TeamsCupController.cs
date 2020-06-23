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
        /// <summary>
        /// Default service
        /// </summary>
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
            return await teamsCupService.DoGamming(teams.Teams);
        }
    }
}
