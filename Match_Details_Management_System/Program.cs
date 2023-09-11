namespace Match_Details_Management_System
{
    internal class Program
    {
        static void Main()
        {
            MatchManagement matchManagement = new MatchManagement();

            // Add at least 6 MatchDetails objects
            matchManagement.AddMatch(new MatchDetails { MatchId = 1, Sport = "Soccer", MatchDateTime = DateTime.Parse("2023-09-07 14:00"), Location = "Stadium A", HomeTeam = "Team A", AwayTeam = "Team B", HomeTeamScore = 0, AwayTeamScore = 0 });

            matchManagement.AddMatch(new MatchDetails { MatchId = 2, Sport = "Basketball", MatchDateTime = DateTime.Parse("2023-09-08 18:30"), Location = "Indoor Arena", HomeTeam = "Team X", AwayTeam = "Team Y", HomeTeamScore = 0, AwayTeamScore = 0 });

            matchManagement.AddMatch(new MatchDetails { MatchId = 3, Sport = "Tennis", MatchDateTime = DateTime.Parse("2023-09-09 12:15"), Location = "Tennis Court 1", HomeTeam = "Player 1", AwayTeam = "Player 2", HomeTeamScore = 0, AwayTeamScore = 0 });

            matchManagement.AddMatch(new MatchDetails { MatchId = 4, Sport = "Cricket", MatchDateTime = DateTime.Parse("2023-09-10 11:00"), Location = "Cricket Ground", HomeTeam = "Team C", AwayTeam = "Team D", HomeTeamScore = 0, AwayTeamScore = 0 });

            matchManagement.AddMatch(new MatchDetails { MatchId = 5, Sport = "Baseball", MatchDateTime = DateTime.Parse("2023-09-11 16:45"), Location = "Field B", HomeTeam = "Team P", AwayTeam = "Team Q", HomeTeamScore = 0, AwayTeamScore = 0 });

            matchManagement.AddMatch(new MatchDetails { MatchId = 6, Sport = "Volleyball", MatchDateTime = DateTime.Parse("2023-09-12 19:30"), Location = "Volleyball Court", HomeTeam = "Team M", AwayTeam = "Team N", HomeTeamScore = 0, AwayTeamScore = 0 });

            // Add more matches here...

            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("\nMenu of all List:");
                Console.WriteLine("1. For Displaying All Matches");
                Console.WriteLine("2. For Displaying match Details");
                Console.WriteLine("3. For Update the match Score");
                Console.WriteLine("4. For Remove the match from List");
                Console.WriteLine("5. For Sort Matches");
                Console.WriteLine("6. For Filter the  Matches");
                Console.WriteLine("7. For Calculate Statistics");
                Console.WriteLine("8. For Search Matches");
                Console.WriteLine("0. Exit");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            matchManagement.DisplayAllMatches();
                            break;
                        case 2:
                            Console.Write("Enter Match ID: ");
                            int matchId = int.Parse(Console.ReadLine());
                            matchManagement.DisplayMatchDetails(matchId);
                            break;
                        case 3:
                            Console.Write("Enter Match ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Home Team Score: ");
                            int homeScore = int.Parse(Console.ReadLine());
                            Console.Write("Enter Away Team Score: ");
                            int awayScore = int.Parse(Console.ReadLine());
                            matchManagement.UpdateMatchScore(id, homeScore, awayScore);
                            break;
                        case 4:
                            Console.Write("Enter the Match ID: ");
                            int removeId = int.Parse(Console.ReadLine());
                            matchManagement.RemoveMatch(removeId);
                            break;
                        case 5:
                            Console.WriteLine("Sortting by : (date/sport/location)");
                            string criteria = Console.ReadLine();
                            Console.WriteLine("Ascending? (true/false)");
                            bool ascending = bool.Parse(Console.ReadLine());
                            matchManagement.SortMatches(criteria, ascending);
                            matchManagement.DisplayAllMatches();
                            break;
                        case 6:
                            Console.WriteLine("Filter by: (sport/location/daterange)");
                            string filterCriteria = Console.ReadLine();
                            Console.WriteLine("Enter value: ");
                            string value = Console.ReadLine();
                            List<MatchDetails> filteredMatches = matchManagement.FilterMatches(filterCriteria, value);
                            Console.WriteLine("\nFiltered Matches:");
                            foreach (var match in filteredMatches)
                            {
                                Console.WriteLine($"Match ID: {match.MatchId}, Sport: {match.Sport}, Date: {match.MatchDateTime}, Location: {match.Location}, Teams: {match.HomeTeam} vs {match.AwayTeam}, Scores: {match.HomeTeamScore} - {match.AwayTeamScore}");
                            }
                            break;
                        case 7:
                            Console.WriteLine("Calculate statistics for: (averagescore/highestscore/lowestscore)");
                            string statisticsCriteria = Console.ReadLine();
                            matchManagement.CalculateStatistics(statisticsCriteria);
                            break;
                        case 8:
                            Console.WriteLine("Search for: ");
                            string keyword = Console.ReadLine();
                            List<MatchDetails> searchedMatches = matchManagement.SearchMatches(keyword);
                            Console.WriteLine("\nSearched Matches:");
                            foreach (var match in searchedMatches)
                            {
                                Console.WriteLine($"Match ID: {match.MatchId}, Sport: {match.Sport}, Date: {match.MatchDateTime}, Location: {match.Location}, Teams: {match.HomeTeam} vs {match.AwayTeam}, Scores: {match.HomeTeamScore} - {match.AwayTeamScore}");
                            }
                            break;
                        case 0:
                            continueRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}