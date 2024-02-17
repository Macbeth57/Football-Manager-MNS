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

            //Game
            Referee.GiveRedCard(team1.StartingPlayers[0]);
            team1.OrganizeTeam();
            Menu.RunMainMenu(team1, game);

            //Ajouter une nouvelle equipe
            //Afficher les joueurs de toutes les equipes
            //Tester un transfert
            //Regler problème de l'attribution des numéros lors d'un transfert
        }
    }
}
