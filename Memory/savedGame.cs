using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class savedGame
    {
        public string GameName
        {
            get; set;
        }
        public List<List<List<int>>> Status
        {
            get; set;
        }

        public players Players
        {
            get; set;
        }

        public string Score1
        {
            get; set;
        }

        public string Score2
        {
            get; set;
        }

        public string Turn
        {
            get; set;
        }
    }
}
