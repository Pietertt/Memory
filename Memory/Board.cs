using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    class Board
    {
        /// <summary>
        /// Returns a random list of cards all pointed down
        /// </summary>
        /// <returns>Returns a random list of cards all pointed down</returns>
        public List<List<List<int>>> Generate()
        {
            List<List<List<int>>> board = new List<List<List<int>>>();
            Random rnd = new Random();

            List<int> allCards = new List<int>()
            {
                1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8
            };

            for (int i = 0; i < 4; i++) // looping through the rows
            {
                List<List<int>> row = new List<List<int>>();

                for (int j = 0; j < 4; j++) // looping through the columns
                {
                    int randomValue = rnd.Next(0, allCards.Count());
                    int randomCard = allCards[randomValue];
                    allCards.RemoveAt(randomValue);

                    row.Add(new List<int>() { randomCard, 0 });
                }
                board.Add(row);
            }
            return board;
        }

        /// <summary>
        /// Returns a random list of cards which are randomly pointed down
        /// </summary>
        /// <returns>Returns a random list of cards which are randomly pointed down</returns>
        public List<List<List<int>>> Random()
        {
            List<List<List<int>>> board = new List<List<List<int>>>();
            Random rnd = new Random();

            List<int> allCards = new List<int>()
            {
                1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8
            };

            for (int i = 0; i < 4; i++) // looping through the rows
            {
                List<List<int>> row = new List<List<int>>();

                for (int j = 0; j < 4; j++) // looping through the columns
                {
                    int randomValue = rnd.Next(0, allCards.Count());
                    int randomCard = allCards[randomValue];
                    allCards.RemoveAt(randomValue);

                    row.Add(new List<int>() { randomCard, rnd.Next(0, 2) });
                }
                board.Add(row);
            }
            return board;
        }
    }
}
