using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14
{
    class Player
    {
        public string Name { get; set; }
        public List<Karta> Cards { get; set; } = new List<Karta>();

        public void ShowCards(int xPos = 0)
        {
            var i = 0;
            foreach(var card in Cards)
            {
                Console.SetCursorPosition(xPos, i++);
                Console.Write($"{i}) {card.Suit} - {card.CardType}");
            }
        }
    }
}
