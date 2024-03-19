using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _Zegar
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {

                Device.BeginInvokeOnMainThread(() =>
                {
                    DateTime now=DateTime.Now;
                    Timer.Text = $"{now.Hour}:{now.Minute}:{now.Second}";
                });

                return true;
            });
        }
        private void Save_Clicked(object sender, EventArgs e)
        {

        }

        private void Show_Clicked(object sender, EventArgs e)
        {

        }
    }
}
