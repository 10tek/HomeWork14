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
        public List<Karta> Cards { get; set; }

        public void ShowCards()
        {
            foreach(var card in Cards)
            {
                Console.WriteLine($"{card.Suit} - {card.CardType}");
            }
        }
    }
}
