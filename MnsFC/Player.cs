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
        public bool IsInjured { get; set; }
        public bool IsLegit { get; set; }
        public List<Card> CurrentCards { get; set; }
        public Team ActualTeam { get; set; }
        public List<Team> Teams { get; set; }

        public Player(string lastname, string firstname) 
        {
            Lastname = lastname;
            Firstname = firstname;
            IsInjured = false;
            CurrentCards = new List<Card>();
            Teams = new List<Team>();
        }
        public Player(string lastname, string firstname, int number)
        {
            Lastname = lastname;
            Firstname = firstname;
            Number = number;
            IsInjured = false;
            CurrentCards = new List<Card>();
            Teams = new List<Team>();
        }
        public Player(string lastname, string firstname, Team actualTeam)
        {
            Lastname = lastname;
            Firstname = firstname;
            IsInjured = false;
            CurrentCards = new List<Card>();
            ActualTeam = actualTeam;
        }
    }
}
