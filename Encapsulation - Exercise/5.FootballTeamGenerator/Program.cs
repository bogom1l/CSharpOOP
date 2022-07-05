using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                try
                {
                    string[] tokens = command.Split(';');

                    ProcessInput(teams, tokens);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException iox)
                {
                    Console.WriteLine(iox.Message);
                }
                catch (IndexOutOfRangeException ie)
                {
                    Console.WriteLine(ErrorMessages.NullOrWhitespaceName);
                }
            }

        }

        static void ProcessInput(List<Team> teams, string[] tokens)
        {
            string action = tokens[0];
            string teamName = tokens[1];

            if (action == "Team")
            {
                Team team = new Team(teamName);
                teams.Add(team);
            }
            else
            {
                Team team = teams.FirstOrDefault(t => t.Name == teamName);
                if (team == null)
                {
                    throw new InvalidOperationException(String.Format(ErrorMessages.TeamNotExists, teamName));
                }

                if (action == "Add")
                {
                    string playerName = tokens[2];

                    Stats playerStats = GeneratePlayerStats(tokens.Skip(3).ToArray());
                    Player player = new Player(playerName, playerStats);

                    team.AddPlayer(player);
                }
                else if (action == "Remove")
                {
                    string playerName = tokens[2];

                    team.RemovePlayer(playerName);
                }
                else if (action == "Rating")
                {
                    Console.WriteLine(team);
                }
            }

        }

        static Stats GeneratePlayerStats(string[] stats)
        {
            int endurance = int.Parse(stats[0]);
            int sprint = int.Parse(stats[1]);
            int dribble = int.Parse(stats[2]);
            int passing = int.Parse(stats[3]);
            int shooting = int.Parse(stats[4]);

            Stats generatedStats = new Stats(endurance, sprint, dribble, passing, shooting);
            return generatedStats;
        }

    }
}
