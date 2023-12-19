
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ООО_СТОЛОВЫЕ_ПРИБОРЫ.Tools;
using ООО_СТОЛОВЫЕ_ПРИБОРЫ.View;

namespace ООО_СТОЛОВЫЕ_ПРИБОРЫ.ViewModel
{
    class MainVM : BaseVM
    {
        public Page CurrentPage 
        {
            get => Navigation.CurrentPage;
        }
        public MainVM()
        {
            Navigation.CurrentPage = new LoginPage();

            Navigation.CurrentPageChanged += NavigationChanged;

        }

        public void NavigationChanged(object? sender, Page e)
        {
            Signal(nameof(CurrentPage));
        }
    }
}
