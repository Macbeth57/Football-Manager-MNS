namespace MnsFC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;    
            //Creation d'équipes
            Generator generator = new Generator();
            List<Player> startingPlayerList = new List<Player>();
            List<Player> substitutePlayerList = new List<Player>();
            string menuReturn = "";

            for (int i = 0; i < 11; i++)
            {
                startingPlayerList.Add(generator.PlayerGenerator());
            }
            for(int i = 0; i < 6; i++)
            {
                substitutePlayerList.Add(generator.PlayerGenerator());
            }
            Team team = new Team("MNS FC", startingPlayerList,substitutePlayerList);

            //Game
            Referee.GiveRedCard(team.StartingPlayers[0]);
            team.OrganizeTeam();
            Menu.RunMainMenu(team);
        }
    }
}
