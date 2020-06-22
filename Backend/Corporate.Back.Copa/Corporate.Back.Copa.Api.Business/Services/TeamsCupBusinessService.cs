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
            /** 1th round */
            List<Team> lsWinners = new List<Team>();
            List<Team> lsTeams = teams.ToList();
            lsTeams.Sort(new Comparison<Team>((t1, t2) => t1.Name.CompareTo(t2.Name)));
            while (true)
            {
                CheckGameRound(lsTeams, ref lsWinners);
                if (lsWinners.Count <= 2)
                {
                    break;
                }
                lsTeams.Clear();
                lsTeams.AddRange(lsWinners);
                lsWinners.Clear();
            }
            if (lsWinners.Count == 2)
            {
                Team winner1 = lsWinners[0];
                Team winner2 = lsWinners[1];
                Debug.WriteLine($"----------------> First  Winner #1: { winner1.Name }");
                Debug.WriteLine($"----------------> Second Winner #2: { winner2.Name }");
            }
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

        /// <summary>
        /// Check game round of teams
        /// </summary>
        private void CheckGameRound(List<Team> lsteams, ref List<Team> lswinners)
        {
            Team winner;
            int len = (int)Math.Floor((decimal)(lsteams.Count / 2));
            for (int i = 0; i < len; i++)
            {
                Team player1 = lsteams[i];
                Team player2 = lsteams[lsteams.Count - i];
                if (player1.Goals == player2.Goals)
                {
                    winner = NormalizeAndTestNames(player1, player2);
                }
                else
                {
                    winner = (player1.Goals > player2.Goals ? player1 : player2);
                }
                lswinners.Add(winner);
            }
        }

        /// <summary>
        /// Normalize names of teams and compare
        /// </summary>
        private Team NormalizeAndTestNames(Team player1, Team player2)
        {
            char[] tokens = new char[] { ' ', '_', '-', '/', '|' };
            string name1 = player1.Name;
            string name2 = player2.Name;
            string[] parts1 = name1.Split(tokens);
            string[] parts2 = name2.Split(tokens);
            string sentence = "";
            if (parts1.Length == parts2.Length)
            {
                for (int i = 0; i < parts1.Length; i++)
                {
                    if (Int32.TryParse(parts1[i], out int number1))
                    {
                        if (Int32.TryParse(parts2[i], out int number2))
                        {
                            sentence += (!string.IsNullOrWhiteSpace(sentence) ? " " : "") + (number1 > number2 ? parts1[i] : parts2[i]);
                            continue;
                        }
                    }
                    if (parts1[i] == parts1[2])
                    {
                        sentence += (!string.IsNullOrWhiteSpace(sentence) ? " " : "") + parts1[i];
                    }
                    else
                    {
                        sentence += (!string.IsNullOrWhiteSpace(sentence) ? " " : "") + (parts1[i].CompareTo(parts2[i]) < 0 ? parts1[i] : parts2[i]);
                    }
                }
            }
            else
            {
                sentence = (name1.CompareTo(name2) < 0 ? name1 : name2);
            }
            name1 = ConvertCharactersTokens(name1, tokens);
            name2 = ConvertCharactersTokens(name2, tokens);
            return (sentence == name1 ? player1 : (sentence == name2 ? player2 : player1));
        }

        /// <summary>
        /// Convert tokens characters of name
        /// </summary>
        private string ConvertCharactersTokens(string text, char[] tokens)
        {
            string sentence = "";
            for (int i = 0; i < tokens.Length; i++)
            {
                sentence = text.Replace(tokens[i], ' ');
            }
            return sentence;
        }
    }
}
