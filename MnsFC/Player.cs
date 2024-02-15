using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnsFC
{
    public class Player
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public int Number { get; set; }
        public List<Card> CurrentCards { get; set; }

        public Player(string lastname, string firstname) 
        {
            Lastname = lastname;
            Firstname = firstname;
            CurrentCards = new List<Card>();
        }
        public Player(string lastname, string firstname, int number)
        {
            Lastname = lastname;
            Firstname = firstname;
            Number = number;
            CurrentCards = new List<Card>();
        }
    }
}
