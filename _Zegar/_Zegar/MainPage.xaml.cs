using _Zegar.FileManager;
using _Zegar.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _Zegar
{
    public partial class MainPage : TabbedPage
    {
        TimeSpan time = new TimeSpan(0);
        public MainPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {

                Device.BeginInvokeOnMainThread(() =>
                {
                    DateTime now = DateTime.Now;
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
            time = TimeSpan.FromMinutes(double.Parse(AlarmTime.Text));
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (time.Ticks <= 0)
                {
                    DisplayAlert("Koniec czasu", "Czas sie zakonczyl", "OK");
                    TimeLeft.Text = "00:00:00";
                    return false;
                }
                Device.BeginInvokeOnMainThread(() =>
                {
                    time = time.Subtract(TimeSpan.FromSeconds(1));

                    TimeLeft.Text = new DateTime(time.Ticks).ToString("HH:mm:ss");
                });
                return true;
            });
        }
        bool counting = false;
        TimeSpan time2 = new TimeSpan(0);
        List<string> timestamps = new List<string>();
        private void ButtonAction_Clicked(object sender, EventArgs e)
        {
            counting = !counting;
            ButtonAction.Text = ButtonAction.Text == "Start" ? "Stop" : "Start";
            Reset.Text = counting == true ? "Pomiar" : "Reset";
            Device.StartTimer(TimeSpan.FromMilliseconds(1), () =>
            {
                if (!counting) return false;
                Device.BeginInvokeOnMainThread(() =>
                {
                    time2 = time2.Add(TimeSpan.FromMilliseconds(1));
                    StoperTime.Text = new DateTime(time2.Ticks).ToString("HH:mm:ss:ff");
                });
                return true;
            });
        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            if (!counting)
            {
                time2 = new TimeSpan(0);
                StoperTime.Text = "00:00:00";
                timestamps.Clear();
                Times.ItemsSource = new List<string>(timestamps);
            }
            else
            {
                timestamps.Add(new DateTime(time2.Ticks).ToString("HH:mm:ss:ff"));
                Times.ItemsSource = new List<string>(timestamps);
            }
        }

        private void TimeStampTimer_Clicked(object sender, EventArgs e)
        {

        }
    }
}
