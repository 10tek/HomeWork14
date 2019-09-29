using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14
{
    public class Karta
    {
        public Suit Suit { get; set; }
        public CardTypes CardType { get; set; }

        public static bool operator >(Karta fKarta, Karta sKarta) => fKarta.CardType > sKarta.CardType;

        public static bool operator <(Karta fKarta, Karta sKarta) => fKarta.CardType < sKarta.CardType;

        public static bool operator ==(Karta fKarta, Karta sKarta) => fKarta.CardType == sKarta.CardType;

        public static bool operator !=(Karta fKarta, Karta sKarta) => fKarta.CardType != sKarta.CardType;
    }
}
