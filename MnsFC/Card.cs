using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnsFC
{
    public class Card
    {
        public CardColor Color {  get; set; }
        public int value { get; set; }

        public Card(CardColor color) 
        {
            Color = color;
            value = color == CardColor.red ? 2 : 1;
        }
    }
}
