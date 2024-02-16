using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnsFC
{
    public static class Menu
    {
        public static void RunMainMenu(Team team)
        {
            string userChoice = "";
            Console.Clear();

            while (userChoice != "0"
                && userChoice != "1"
                && userChoice != "2"
                && userChoice != "3")
            {
                Console.WriteLine("[0] - Consultez votre équipe");
                Console.WriteLine("[1] - Effectuer des changements");
                Console.WriteLine("[2] - Lancer un match");
                Console.WriteLine("[3] - Quitter");

                userChoice = Console.ReadLine();
            }

            switch(userChoice)
            {
                case "0":
                    team.DisplayTeam();
                    break;
                case "1":
                    OrganisationMenu(team);
                    break;
                case "2":
                    //A faire
                    break;
                default:
                    break;
            }
        }  
        public static void OrganisationMenu(Team team)
        {
            string userChoice = "";
            while(userChoice != "1" &&  userChoice != "2" &&  userChoice != "3")
            {
                Console.Clear();
                Console.WriteLine("[1] - Transférer un joueur des titulaires aux remplaçants");
                Console.WriteLine("[2] - Transférer un joueur des remplaçants aux titulaires");
                Console.WriteLine("[3] - Revenir au menu principal");
                userChoice = Console.ReadLine();
            }
            switch (userChoice)
            {
                case "1":
                    MovePlayerFromStartingToSubstituteMenu(team);
                    break;
                case "2":
                    MovePlayerFromSubstituteToStartingMenu(team);
                    break;
                case "3":
                    Menu.RunMainMenu(team);
                    break;
                default:
                    break;
            }

        }
        public static void MovePlayerFromSubstituteToStartingMenu(Team team)
        {
            Console.Clear();
            Console.WriteLine("Entrez le nom du joueur à envoyer chez les remplaçants : ");
            string userChoiceLastname = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Entrez le prénom du joueur à envoyer chez les remplaçants : ");
            string userChoiceFirstname = Console.ReadLine();

            team.MovePlayerFromSubstituteToStarting(team.SearchForPlayer(userChoiceLastname,userChoiceFirstname));
            Menu.RunMainMenu(team);
        }
        public static void MovePlayerFromStartingToSubstituteMenu(Team team)
        {
            Console.Clear();
            Console.WriteLine("Entrez le nom du joueur à envoyer dans l'équipe principale : ");
            string userChoiceLastname = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Entrez le prénom du joueur à envoyer dans l'équipe principale : ");
            string userChoiceFirstname = Console.ReadLine();

            team.MovePlayerFromStartingToSubstitute(team.SearchForPlayer(userChoiceLastname, userChoiceFirstname));
            Menu.RunMainMenu(team);
        }
    }
}
