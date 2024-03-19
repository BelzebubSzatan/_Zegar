using _Zegar.FileManager;
using _Zegar.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _Zegar
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {

                Device.BeginInvokeOnMainThread(() =>
                {
                    DateTime now=DateTime.Now;
                    Timer.Text = now.ToString("HH:mm:ss");
                });

                return true;
            });
        }
        private void Save_Clicked(object sender, EventArgs e)
        {
            FileHandling.SaveToFile(DateTime.Now.ToString("HH:mm:ss"));
        }

        private async void Show_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClockList());
        }

        private void StartTimer_Clicked(object sender, EventArgs e)
        {

        }
    }
}
