using System;
using System.Collections.Generic;

namespace Algorithms.Algoexpert.Easy;

public partial class Solution
{
    /// O(n) time | O(k) space where k is the number of teams
    public string TournamentWinner(List<List<string>> competitions, List<int> results)
    {
        const int HOME_TEAM_WON = 1;
        const int POINTS = 3;
        var scores = new Dictionary<string, int>();
        string currentBestTeam = String.Empty;
        scores.Add(currentBestTeam, 0);

        for (int i = 0; i < competitions.Count; ++i)
        {
            int result = results[i];

            string firstTeam = competitions[i][0];
            string secondTeam = competitions[i][1];
            string winnerTeam = (result == HOME_TEAM_WON) ? firstTeam : secondTeam;

            UpdateScore(winnerTeam, POINTS, scores);

            if (scores[currentBestTeam] < scores[winnerTeam])
            {
                currentBestTeam = winnerTeam;
            }
        }

        return currentBestTeam;

        void UpdateScore(string team, int points, Dictionary<string, int> scores)
        {
            if (!scores.ContainsKey(team))
            {
                scores.Add(team, 0);
            }

            scores[team] += points;
        }
    }
}
