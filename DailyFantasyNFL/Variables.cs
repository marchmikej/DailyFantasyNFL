using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyFantasyNFL
{
    class Variables
    {
        public static int minPlayerPoints = 2;
        public static int threads = 3;
        public static int minPointLineup = 127;
        public static int gameCost = 60000;
        public static int minQBValue = 1;
        public static List<int> excludePlayer = new List<int>();
        public static Dictionary<string, bool> teamEligible = new Dictionary<string, bool>();
    }
}
