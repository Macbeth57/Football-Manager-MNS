using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MnsFC
{
    public static class Menu 
    {
        public static void RunMainMenu(Team team, Game game)
        {
            string userChoice = "";
            Console.Clear();

            while (userChoice != "0"
                && userChoice != "1"
                && userChoice != "2"
                && userChoice != "3"
                && userChoice != "4")
            {
                Console.WriteLine("[0] - Consultez votre équipe");
                Console.WriteLine("[1] - Effectuer des changements");
                Console.WriteLine("[2] - Lancer un match");
                Console.WriteLine("[3] - Effectuer un transfert");
                Console.WriteLine("[4] - Quitter");

                userChoice = Console.ReadLine();
            }

            switch(userChoice)
            {
                case "0":
                    DisplayTeam(team, game);
                    break;
                case "1":
                    OrganisationMenu(team, game);
                    break;
                case "2":
                    //A faire - Lancer un match
                    break;
                case "3":
                    TransfertMenu(game, team);
                    break;
                default:
                    break;
            }
        }  
        public static void TransfertMenu(Game game, Team team)
        {
            string userInput = "";
            Console.Clear();
            Console.WriteLine("Entrez le nom du joueur à transférer :");
            string lastnameFromPlayerToTransfer = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Entrez le prénom du joueur à transférer :");
            string firstnameFromPlayerToTransfer = Console.ReadLine();
            Team teamPlayerIn = game.WhichTeamIsThisPlayerIn(lastnameFromPlayerToTransfer,firstnameFromPlayerToTransfer);
            Console.Clear();
            Console.WriteLine("Ce joueur se trouve actuellement dans l'équipe : " + teamPlayerIn.Name );
            Console.WriteLine("Dans quelle équipe souhaitez vous le transferer ? [nom]");
            string teamNameToTransferThePlayerIn = Console.ReadLine();
            Team teamPlayerIsGoing = game.SearchATeamByName(teamNameToTransferThePlayerIn);
            Player player = teamPlayerIn.SearchForPlayer(lastnameFromPlayerToTransfer, firstnameFromPlayerToTransfer);
            teamPlayerIn.RemovePlayer(player);
            teamPlayerIsGoing.AddPlayer(player);

            RunMainMenu(team, game);
        }
        public static void OrganisationMenu(Team team, Game game)
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
                    MovePlayerFromStartingToSubstituteMenu(team, game);
                    break;
                case "2":
                    MovePlayerFromSubstituteToStartingMenu(team, game);
                    break;
                case "3":
                    Menu.RunMainMenu(team, game);
                    break;
                default:
                    break;
            }

        }
        public static void MovePlayerFromSubstituteToStartingMenu(Team team, Game game)
        {
            Console.Clear();
            Console.WriteLine("Entrez le nom du joueur à envoyer chez les remplaçants : ");
            string userChoiceLastname = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Entrez le prénom du joueur à envoyer chez les remplaçants : ");
            string userChoiceFirstname = Console.ReadLine();

            team.MovePlayerFromSubstituteToStarting(team.SearchForPlayer(userChoiceLastname,userChoiceFirstname));
            Menu.RunMainMenu(team, game);
        }
        public static void MovePlayerFromStartingToSubstituteMenu(Team team, Game game)
        {
            Console.Clear();
            Console.WriteLine("Entrez le nom du joueur à envoyer dans l'équipe principale : ");
            string userChoiceLastname = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Entrez le prénom du joueur à envoyer dans l'équipe principale : ");
            string userChoiceFirstname = Console.ReadLine();

            team.MovePlayerFromStartingToSubstitute(team.SearchForPlayer(userChoiceLastname, userChoiceFirstname));
            Menu.RunMainMenu(team, game);
        }
        public static void DisplayTeam(Team team, Game game)
        {
            string userChoice = "";

            while (userChoice != "0")
            {
                Console.Clear();
                Console.WriteLine("## " + team.Name + " ##");
                Console.WriteLine();
                Console.WriteLine("## Starting Players ##");
                Console.WriteLine();

                foreach (Player player in team.StartingPlayers)
                {
                    if (player.IsInjured && Referee.DoesHaveTooManyCards(player))
                    {
                        Console.Write(player.Firstname + " " + player.Lastname + " " + player.Number);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" INJURED");
                        Console.Write(" - REDCARD");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                    }
                    else if (player.IsInjured && !Referee.DoesHaveTooManyCards(player))
                    {
                        Console.Write(player.Firstname + " " + player.Lastname + " " + player.Number);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" INJURED");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();

                    }
                    else if (!player.IsInjured && Referee.DoesHaveTooManyCards(player))
                    {
                        Console.Write(player.Firstname + " " + player.Lastname + " " + player.Number);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" REDCARD");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine(player.Firstname + " " + player.Lastname + " " + player.Number);

                    }
                }

                Console.WriteLine();
                Console.WriteLine("## Substitutes Players ##");
                Console.WriteLine();

                foreach (Player player in team.SubstitutePlayers)
                {
                    if (player.IsInjured && Referee.DoesHaveTooManyCards(player))
                    {
                        Console.Write(player.Firstname + " " + player.Lastname + " " + player.Number);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" INJURED");
                        Console.Write(" - REDCARD");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                    }
                    else if (player.IsInjured && !Referee.DoesHaveTooManyCards(player))
                    {
                        Console.Write(player.Firstname + " " + player.Lastname + " " + player.Number);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" INJURED");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();

                    }
                    else if (!player.IsInjured && Referee.DoesHaveTooManyCards(player))
                    {
                        Console.Write(player.Firstname + " " + player.Lastname + " " + player.Number);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" REDCARD");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine(player.Firstname + " " + player.Lastname + " " + player.Number);

                    }
                }
                Console.WriteLine();
                Console.WriteLine("[RETOUR MENU]: 0");
                Console.WriteLine();
                userChoice = Console.ReadLine();
            }
            Menu.RunMainMenu(team, game);
        }
    }
}
