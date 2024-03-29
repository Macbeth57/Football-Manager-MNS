﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MnsFC
{
    public class Generator
    {
        public List<string> FirstnameList = new List<string>
        {
            "Sofia",
            "Liam",
            "Aisha",
            "Gabriel",
            "Mei",
            "Alejandro",
            "Fatima",
            "Luca",
            "Leila",
            "Ivan",
            "Ananya",
            "Diego",
            "Nia",
            "Matteo",
            "Jasmine",
            "Aditya",
            "Zara",
            "Omar",
            "Isabella",
            "Amir",
            "Maya",
            "Nikhil",
            "Ingrid",
            "Lucas",
            "Priya",
            "Rafael",
            "Layla",
            "Hiroshi",
            "Emilia",
            "Carlos",
            "Yara",
            "Mattea",
            "Ahmed",
            "Mia",
            "Giuseppe",
            "Arya",
            "Ahmed",
            "Ana",
            "Leo",
            "Yuki",
            "Olivia",
            "Ravi",
            "Chihiro",
            "Tariq",
            "Kira",
            "Lorenzo",
            "Sana",
            "Erika",
            "Youssef",
            "Layla",
            "Julian",
            "Sakura",
            "Ibrahim",
            "Leilani",
            "Maria",
            "Rohan",
            "Svetlana",
            "Mateo",
            "Natasha",
            "Elias",
            "Amara",
            "Dario",
            "Shiori",
            "Alejandro",
            "Neha",
            "Nikolas",
            "Zoe",
            "Yusuf",
            "Maya",
            "Leonardo",
            "Aisha",
            "Tenzin",
            "Priya",
            "Ismail",
            "Yara",
            "Chiara",
            "Juan",
            "Amaya",
            "Pavel",
            "Aria",
            "Selim",
            "Estelle",
            "Daniel",
            "Riya",
            "Marco",
            "Mei",
            "Ahmed",
            "Layla",
            "Luca",
            "Kana",
            "Liam",
            "Ayaka",
            "Sebastian",
            "Noor",
            "Hiroki",
            "Fatima",
            "Amir",
            "Nina",
            "Antonio",
            "Sana"
        };
        public List<string> LastnameList = new List<string>
        {
            "Smith",
            "Garcia",
            "Kim",
            "Martinez",
            "Singh",
            "Müller",
            "Chen",
            "Khan",
            "Anderson",
            "Nguyen",
            "Silva",
            "Hernandez",
            "Lee",
            "Gonzalez",
            "Wong",
            "Lopez",
            "Schmidt",
            "Gupta",
            "Johnson",
            "Wang",
            "Fernandez",
            "Brown",
            "Yamamoto",
            "Ramos",
            "Taylor",
            "Nakamura",
            "Rodriguez",
            "Ivanov",
            "Gomez",
            "Wu",
            "Kumar",
            "O'Connor",
            "Gao",
            "Thomas",
            "Sato",
            "Perez",
            "Wilson",
            "Chang",
            "Morgan",
            "Sánchez",
            "Evans",
            "Takahashi",
            "Walker",
            "Chan",
            "Jensen",
            "Ferrari",
            "García",
            "Jones",
            "Huang",
            "Morales",
            "Li",
            "Gutierrez",
            "Mueller",
            "Williams",
            "Park",
            "Chung",
            "Young",
            "Kawasaki",
            "Santos",
            "Le",
            "Rossi",
            "Brown",
            "Liu",
            "Murphy",
            "Ahmed",
            "Ito",
            "Thompson",
            "Fischer",
            "Ramirez",
            "Olsen",
            "Yilmaz",
            "Torres",
            "Carvalho",
            "Bianchi",
            "Ribeiro",
            "Gonzales",
            "Lam",
            "Ortega",
            "Ruiz",
            "Ferreira",
            "Kovacs",
            "Vasquez",
            "Novak",
            "Kaur",
            "Alves",
            "Yildirim",
            "Nascimento",
            "Liu",
            "Ryan",
            "Hansen",
            "Petrov",
            "Fernandes",
            "Moreno",
            "Molina",
            "Bach",
            "Matsuda",
            "Suzuki",
            "Petrovic",
            "Zhang",
            "Kang"
        };

        public Player PlayerGenerator()
        {
            Random randomSeedForFirstname = new Random();
            Random randomSeedForLastname = new Random();

            int randomIndexForFirstname = randomSeedForFirstname.Next(1, FirstnameList.Count);
            int randomIndexForLastname = randomSeedForLastname.Next(1, LastnameList.Count);
            string randomFirstname = FirstnameList[randomIndexForFirstname];
            string randomLastname = LastnameList[randomIndexForLastname];

            Player player = new Player(randomFirstname, randomLastname);

            return player;
        }
        public List<Player> StartingPlayersListGenerator()
        {
            List<Player> startingPlayerList = new List<Player>();
            for (int i = 0; i < 11; i++)
            {
                startingPlayerList.Add(PlayerGenerator());
            }
            return startingPlayerList;
        }
        public List<Player> SubstitutePlayersListGenerator()
        {
            List<Player> substitutePlayerList = new List<Player>();
            for (int i = 0; i < 6; i++)
            {
                substitutePlayerList.Add(PlayerGenerator());
            }
            return substitutePlayerList;
        }
        public Team TeamGenerator(string teamName, Game game)
        {
            List<Player> startingPlayers = StartingPlayersListGenerator();
            List<Player> substitutePlayers = SubstitutePlayersListGenerator();
            Team team = new Team(teamName,startingPlayers,substitutePlayers);

            team.StartingPlayers = startingPlayers;
            team.SubstitutePlayers = substitutePlayers;
            team.AssignNumbers();

            game.Teams.Add(team);

            return team;
        }
    }
}
