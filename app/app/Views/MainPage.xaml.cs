using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BottomBar.XamarinForms;

namespace app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : BottomBarPage
    {
        public MainPage()
        {
            InitializeComponent();
            init();
        }

        void init()
        {
            // Initialize pages
            this.Children.Add(new MusicPlayer() { IconImageSource = "player_ico.png" });
        }
    }
}