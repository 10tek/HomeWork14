using System;
using System.Collections.Generic;
using System.Threading;

namespace HW14
{
    class Game
    {
        private List<Player> players;
        private List<Karta> cards;

        public Game()
        {
            players = new List<Player>();
            cards = new List<Karta>();
            players.Add(new Player() { Name = "James" });
            players.Add(new Player() { Name = "Thomas" });
            for (var i = 0; i < Constants.SuitCnt; i++)
            {
                for (var j = 0; j < Constants.TypeCnt; j++)
                {
                    cards.Add(new Karta() { Suit = (Suit)i, CardType = (CardTypes)j });
                }
            }
        }

        public void Shuffle()
        {
            for (int i = 0, j = 0; i < Constants.CardCnt; i++)
            {
                j = Constants.Random.Next(Constants.CardCnt);
                var tmp = cards[j];
                cards[j] = cards[i];
                cards[i] = tmp;
            }
        } 

        public void Play()
        {
            Distribution();
            var isFirst = (Constants.Random.Next(2) == 1 ? true : false);
            var isWin = false;
            var tmp = players[0].Cards[0];
            while (!isWin)
            {
                Console.Clear();
                players[0].ShowCards();
                players[1].ShowCards(30);
                Thread.Sleep(3000);
                if (players[0].Cards[0] > players[1].Cards[0])
                {
                    tmp = players[0].Cards[0];
                    players[0].Cards.Add(players[1].Cards[0]);
                    players[0].Cards.RemoveAt(0);
                    players[1].Cards.RemoveAt(0);
                    players[0].Cards.Add(tmp);
                }
                else if (players[0].Cards[0] == players[1].Cards[0])
                {
                    if (isFirst)
                    {
                        tmp = players[0].Cards[0];
                        players[0].Cards.Add(players[1].Cards[0]);
                        players[0].Cards.RemoveAt(0);
                        players[1].Cards.RemoveAt(0);
                        players[0].Cards.Add(tmp);
                    }
                    else
                    {
                        tmp = players[1].Cards[0];
                        players[1].Cards.Add(players[0].Cards[0]);
                        players[1].Cards.RemoveAt(0);
                        players[0].Cards.RemoveAt(0);
                        players[1].Cards.Add(tmp);
                    }
                }
                else
                {
                    tmp = players[1].Cards[0];
                    players[1].Cards.Add(players[0].Cards[0]);
                    players[1].Cards.RemoveAt(0);
                    players[0].Cards.RemoveAt(0);
                    players[1].Cards.Add(tmp);
                }
                isFirst = !isFirst;
                if(players[0].Cards.Count == 0 || players[0].Cards.Count == Constants.CardCnt)
                {
                    isWin = true;
                }
            }

            Console.Write("\nПобедил ");
            Console.WriteLine((players[0].Cards.Count > players[1].Cards.Count ? players[0].Name : players[1].Name));

        }

        private void Distribution()
        {
            Shuffle();
            for (var i = 0; i < Constants.CardCnt;)
            {
                players[0].Cards.Add(cards[i++]);
                players[1].Cards.Add(cards[i++]);
            }
        }
    }
}
