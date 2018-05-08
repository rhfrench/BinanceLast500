using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last500Trades
{
    public class TradeModel
    {
        public string Symbol { get; set; }
        public long Time { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }

    }
}
