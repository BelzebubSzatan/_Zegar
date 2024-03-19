using _Zegar.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _Zegar.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClockList : ContentPage
    {
        public ClockList()
        {
            InitializeComponent();
            ClockListXaml.ItemsSource = new List<string>(FileHandling.ReadFromFile());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}