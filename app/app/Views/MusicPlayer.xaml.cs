using app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MusicPlayer : ContentPage
    {
        public MusicPlayer()
        {
            InitializeComponent();
            init();
        }

        void init()
        {
            AudioSlider.MinimumTrackColor = Constants.ActiveOrangeColor;
            AudioSlider.MaximumTrackColor = Constants.PasiveColor;
        }
    }
}