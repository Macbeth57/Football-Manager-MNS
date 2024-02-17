namespace MnsFC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Game game = new Game();

            //Creation d'équipes
            Generator generator = new Generator();
            Team team1 = new Team();
            Team team2 = new Team();

            team1 = generator.TeamGenerator("CDA-Csharp",game);
            team2 = generator.TeamGenerator("CDA-Java", game);

            //Test
            Referee.GiveRedCard(team1.StartingPlayers[0]);
            team1.OrganizeTeam(); 

            //Game
            Menu.RunMainMenu(team1, game);

            //Tester un transfert
            //Regler problème de l'attribution des numéros lors d'un transfert
        }
    }
}
