using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ООО_СТОЛОВЫЕ_ПРИБОРЫ.Tools
{
    class Navigation
    {
        private static Page currentPage;

        public static Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                CurrentPageChanged?.Invoke(null, CurrentPage);

            }
        }
        public static EventHandler<Page> CurrentPageChanged;
    }
}
