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
            team.AssignNumbers();
            game.Teams.Add(team);

            //Game
            Referee.GiveRedCard(team.StartingPlayers[0]);
            team.OrganizeTeam();
            Menu.RunMainMenu(team, game);

            //Ajouter une nouvelle equipe
            //Afficher les joueurs de toutes les equipes
            //Tester un transfert
            //Regler problème de l'attribution des numéros 
            //Voir pour modifier constructeur de la classe Team
            //Regler problème menu organisation d'équipe impossible de revenir menu principal
        }
    }
}
