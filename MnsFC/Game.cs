using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnsFC
{
    public class Game
    {
        public List<Team> Teams { get; set; }

        public Game() 
        {
            Teams = new List<Team>();
        }
        public void PlayerTransfer(Player player, Team teamPlayerLeaving, Team teamPlayerJoining)
        {
            for (int i = 0; i < teamPlayerLeaving.StartingPlayers.Count; i++)
            {
                if (teamPlayerLeaving.StartingPlayers.Contains(player))
                {
                    teamPlayerLeaving.StartingPlayers.Remove(player);
                }
                if (teamPlayerLeaving.SubstitutePlayers.Contains(player))
                {
                    teamPlayerLeaving.SubstitutePlayers.Remove(player);
                }

                teamPlayerJoining.SubstitutePlayers.Add(player);
                player.ActualTeam = teamPlayerJoining;
                player.Teams.Add(teamPlayerJoining);
            }
        }
        public Team WhichTeamIsThisPlayerIn(string lastname, string firstname)
        {
            foreach (Team team in Teams)
            {
                foreach(Player player in team.StartingPlayers)
                {
                    if(player.Lastname == lastname && player.Firstname == firstname)
                    {
                        return team;
                    }
                }
                foreach (Player player in team.SubstitutePlayers)
                {
                    if (player.Lastname == lastname && player.Firstname == firstname)
                    {
                        return team;
                    }
                }

            }
            throw new Exception("Aucun joueur trouvé avec ce nom");
        }
        public Team SearchATeamByName(string name) 
        {
            foreach(Team team in Teams)
            {
                if(team.Name == name)
                {
                    return team;
                }
            }
            throw new Exception("Aucune équipe ne porte ce nom.");
        }
    }

}
