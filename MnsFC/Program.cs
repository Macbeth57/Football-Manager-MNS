namespace MnsFC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creation d'équipes
            Generator generator = new Generator();
            List<Player> startingPlayerList = new List<Player>();
            List<Player> substitutePlayerList = new List<Player>();

            for (int i = 0; i <= 11; i++)
            {
                startingPlayerList.Add(generator.PlayerGenerator());
            }
            for(int i = 0; i <= 5; i++)
            {
                substitutePlayerList.Add(generator.PlayerGenerator());
            }
            Team team = new Team("MNS FC", startingPlayerList,substitutePlayerList);

            //Game
            
            team.DisplayTeam();

            Console.ReadLine();
        }
    }
}
