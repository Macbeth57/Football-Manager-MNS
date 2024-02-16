using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MnsFC
{
    public class Team
    {
        public string Name { get; set; }
        public List<Player> StartingPlayers {  get; set; }
        public List<Player> SubstitutePlayers { get; set; }
        public List<int> AvailableNumbers { get; set; }

        public Team(string name, List<Player> startingPlayersList, List<Player> substitutePlayersList) 
        {
            Name = name;
            StartingPlayers = startingPlayersList;
            SubstitutePlayers = substitutePlayersList;
            AvailableNumbers = new List<int>
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30
            };
        }
        public void AddPlayer(Player player)
        {
            Random random = new Random();
            int randomIndex = random.Next(1, AvailableNumbers.Count);
            player.Number = AvailableNumbers[randomIndex];
            AvailableNumbers.Remove(AvailableNumbers[randomIndex]);

            SubstitutePlayers.Add(player);
        }
        public void RemovePlayer(Player player)
        {
            AvailableNumbers.Add(player.Number);
            foreach (Player playerInList in SubstitutePlayers)
            {
                if(playerInList == player)
                {
                    SubstitutePlayers.Remove(player);
                }
            }
            foreach(Player playerInList in StartingPlayers)
            {
                if (playerInList == player)
                {
                    StartingPlayers.Remove(player);
                }
            }
        }
        public Player SearchForPlayer(string lastname,string firstname)
        {
            foreach (Player player in SubstitutePlayers)
            {
                if(player.Firstname ==  firstname && player.Lastname == lastname)
                {
                    return player;
                }
            }
            foreach (Player player in StartingPlayers)
            {
                if (player.Firstname == firstname && player.Lastname == lastname)
                {
                    return player;
                }
            }
            throw new Exception("Error : Joueur introuvable.");
        }
        public void MovePlayerFromStartingToSubstitute(Player playerToMove)
        {
            StartingPlayers.Remove(playerToMove);
            SubstitutePlayers.Add(playerToMove);
        }
        public void MovePlayerFromSubstituteToStarting(Player playerToMove)
        {
            SubstitutePlayers.Remove(playerToMove);
            StartingPlayers.Add(playerToMove);
        }
        public void OrganizeTeam()
        {
            for(int i = 0; i < StartingPlayers.Count; i++)
            {
                if (!Referee.IsThisPlayerLegit(StartingPlayers[i]))
                {
                    MovePlayerFromStartingToSubstitute(StartingPlayers[i]);
                }
            }
            for(int i = 0; i < SubstitutePlayers.Count; i++)
            {
                if (Referee.IsThisPlayerLegit(SubstitutePlayers[i]))
                {
                    MovePlayerFromSubstituteToStarting(SubstitutePlayers[i]);
                }
            }
            for(int i = 0; i < StartingPlayers.Count; i++)
            {
                if(StartingPlayers.Count <= 11)
                {
                    break;
                }
                MovePlayerFromStartingToSubstitute(StartingPlayers[i]);
            }
        }
        public void AssignNumbers()
        {
            foreach (Player player in StartingPlayers)
            {
                player.ActualTeam = this; //Truc de fou furieux
                player.Teams.Add(this); //Truc de fou furieux
                Random random = new Random();
                int randomIndex = random.Next(0, AvailableNumbers.Count);
                player.Number = AvailableNumbers[randomIndex];
                AvailableNumbers.Remove(AvailableNumbers[randomIndex]);
            }
            foreach (Player player in SubstitutePlayers)
            {
                player.ActualTeam = this; //Truc de fou furieux
                player.Teams.Add(this); //Truc de fou furieux
                Random random = new Random();
                int randomIndex = random.Next(0, AvailableNumbers.Count);
                player.Number = AvailableNumbers[randomIndex];
                AvailableNumbers.Remove(AvailableNumbers[randomIndex]);
            }
        }
    }
}
