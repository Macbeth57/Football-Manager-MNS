using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnsFC
{
    static class Referee
    {
        public static void GiveYellowCard(Player player)
        {
            Card yellowCard = new Card(CardColor.yellow);
            player.CurrentCards.Add(yellowCard);
        }
        public static void GiveYellowCard(List<Player> playerList, string lastname, string firstname)
        {
            Card yellowCard = new Card(CardColor.yellow);
            foreach(Player player in playerList)
            {
                if(player.Firstname == firstname && player.Lastname == lastname)
                {
                    player.CurrentCards.Add(yellowCard);
                }
            }

        }
        public static void GiveRedCard(Player player)
        {
            Card redCard = new Card(CardColor.red);
            player.CurrentCards.Add(redCard);
        }
        public static void GiveRedCard(List<Player> playerList, string lastname, string firstname)
        {
            Card redCard = new Card(CardColor.red);
            foreach (Player player in playerList)
            {
                if (player.Firstname == firstname && player.Lastname == lastname)
                {
                    player.CurrentCards.Add(redCard);
                }
            }

        }
        public static bool IsThisPlayerLegit(Player player)
        {
            int totalValueCards = 0;

            foreach (Card card in player.CurrentCards)
            {
                totalValueCards += card.value;
            }
            if(totalValueCards >= 2 || player.IsInjured == true)
            {
                return false;
            }
            return true;
        }
        public static bool DoesHaveTooManyCards(Player player)
        {
            int valueCards = 0;

            foreach (Card card in player.CurrentCards)
            {
                valueCards += card.value;
            }

            return valueCards >= 2 ? true : false;
        }
    }
}
