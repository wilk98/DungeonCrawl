using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl.src.Core.View
{
    public class ProgressBar
    {
        public string block = "■";

        public int CountBlock(int currentValue, int maxValue)
        {
            int maxBlockQuantity = 28;
            int currentBlockQuantity = maxBlockQuantity * currentValue / maxValue;
            return currentBlockQuantity;
        }

        public string DrawBar(int currentValue, int maxValue)
        {
            int numberOfBlocks = CountBlock(currentValue, maxValue);
            string bar = new String('■', numberOfBlocks);
            return bar;
        }
    }
}
