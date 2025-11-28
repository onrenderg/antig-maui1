using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseTemp
{
    public partial class App : Application
    {
       
        


        public App()
        {
            InitializeComponent();

           
        }

        

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var nav = new NavigationPage(new MainPage());
            nav.BarBackgroundColor = Colors.White;
            nav.BarTextColor = Colors.Black;
            return new Window(nav);
        }
    }
}