using Corporate.Back.Copa.Api.Business.Contracts;
using Corporate.Back.Copa.Api.Business.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Corporate.Back.Copa.Api.Business.Services
{
    public class TeamsCupBusinessService : ITeamsCupBusinessService
    {

        #region ITeamsCupBusinessService Members

        /// <summary>
        /// Find winners podium
        /// </summary>
        public bool DoMatchGames(Team[] teams, out Team firstWinner, out Team secondWinner, out string message)
        {
            firstWinner = new Team();
            secondWinner = new Team();
            message = "";
            if (!ValidateRuleSameName(teams, ref message))
            {
                return false;
            }
            if (teams == null || teams.Length == 0)
            {
                message = "No has teams to matches!";
                return false;
            }
            if (teams.Length > 8)
            {
                message = "Has more of eight (8) teams in cup game!";
                return false;
            }
            /** !th round */
            List<Match> lsWinners = new List<Match>();
            List<Match> lsMatchs = teams.Select(t => new Match() { Team = t, NormName = Normalize(t.Name) }).ToList();
            lsMatchs.Sort(new Comparison<Match>((m1, m2) => m1.NormName.CompareTo(m2.NormName)));
            CheckInitialRound(lsMatchs, ref lsWinners);
            lsMatchs.Clear();
            lsMatchs.AddRange(lsWinners);
            lsWinners.Clear();
            /** Semifinal round */
            CheckSemifinalRound(lsMatchs, ref lsWinners);
            if (lsWinners.Count != 2)
            {
                message = "Has more or less of eight (8) teams in cup game!";
                return false;
            }
            /** Final round */
            Match winner;
            Match player1 = lsWinners[0];
            Match player2 = lsWinners[1];
            if (player1.Goals == player2.Goals)
            {
                winner = (player1.NormName.CompareTo(player2.NormName) < 0 ? player1 : player2);
            }
            else
            {
                winner = (player1.Goals > player2.Goals ? player1 : player2);
            }
            firstWinner = winner.Team;
            secondWinner = (winner.Team.Id == player1.Team.Id ? player2.Team : player1.Team);
            return true;
        }

        #endregion ITeamsCupBusinessService Members

        /// <summary>
        /// Validate teams has duplicate name
        /// </summary>
        private bool ValidateRuleSameName(Team[] teams, ref string message)
        {
            List<Team> distTeams = teams
                .GroupBy(p => p.Name)
                .Select(g => g.First())
                .ToList();
            return (teams.Length == distTeams.Count);
        }

        private char[] tokens = new char[] { ' ', '_', '-', '/', '|' };

        /// <summary>
        /// Normalize name of team
        /// </summary>
        private string Normalize(string name)
        {
            string sentence = "";
            string[] parts = name.Split(new char[] { ' ' });
            for (int i = 0; i < parts.Length; i++)
            {
                if (Int32.TryParse(parts[i], out int number))
                {
                    sentence += (!string.IsNullOrWhiteSpace(sentence) ? " " : "") + "".PadLeft(30 - number.ToString().Length, '0') + number.ToString();
                    continue;
                }
                sentence += (!string.IsNullOrWhiteSpace(sentence) ? " " : "") + (parts[i].Length > 30 ? parts[i].Substring(0, 30) : parts[i] + "".PadRight(30 - parts[i].Length, ' '));
            }
            return sentence;
        }

        /// <summary>
        /// Check game round of teams in initial round
        /// </summary>
        private void CheckInitialRound(List<Match> lsmatchs, ref List<Match> lswinners)
        {
            Match winner;
            int cnt = lsmatchs.Count;
            int len = (int)Math.Floor((decimal)(cnt / 2));
            for (int i = 0; i < len; i++)
            {
                Match player1 = lsmatchs[i];
                Match player2 = lsmatchs[cnt - (i +1)];
                if (player1.Goals == player2.Goals)
                {
                    winner = (player1.NormName.CompareTo(player2.NormName) < 0 ? player1 : player2);
                }
                else
                {
                    winner = (player1.Goals > player2.Goals ? player1 : player2);
                }
                lswinners.Add(winner);
            }
        }

        /// <summary>
        /// Check game round of teams in semifinal round
        /// </summary>
        private void CheckSemifinalRound(List<Match> lsmatchs, ref List<Match> lswinners)
        {
            Match winner;
            Match player1 = null, player2 = null;
            int len = lsmatchs.Count;
            for (int i = 0; i <= len; i+=2)
            {
                if (i == 0) continue;
                player1 = lsmatchs[i - 2];
                player2 = lsmatchs[i - 1];
                if (player1.Goals == player2.Goals)
                {
                    winner = (player1.NormName.CompareTo(player2.NormName) < 0 ? player1 : player2);
                }
                else
                {
                    winner = (player1.Goals > player2.Goals ? player1 : player2);
                }
                lswinners.Add(winner);
            }
        }

    }

    internal class Match
    {
        public string NormName { get; set; } = "";
        public int Goals { get => Team.Goals; }
        public Team Team { get; set; }
    }
}
