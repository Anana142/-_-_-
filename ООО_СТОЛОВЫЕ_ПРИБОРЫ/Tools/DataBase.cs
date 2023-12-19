using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ООО_СТОЛОВЫЕ_ПРИБОРЫ.DataBase;

namespace ООО_СТОЛОВЫЕ_ПРИБОРЫ.Tools
{
    class DataBase
    {
        private static TradeContext instance1;

        public DataBase() { }
        public static TradeContext instance
        {
            get
            {
                if (instance1 == null)
                    instance1 = new TradeContext();
                return instance1;
            }
            set => instance1 = value;
        }

    }
}
