using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Aero.Models;
using System.Threading;
using System.Data.SqlClient;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Aero
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class FindFlights : Page
    {

        public FindFlights()
        {
            this.InitializeComponent();
        }

        private void CountPass_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            
        }

        private void CountPass_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new parusaContext())
            {
               var qwer = context.Cities.Where(q=>q.IdCountryNavigation.Name=="Россия");
                this.Frame.Navigate(typeof(flights));
            }
        }

        private void CountPass_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            int i = int.MinValue;
            bool flag = int.TryParse(sender.Text, out i);
            if (!flag || sender.Text.Contains('+')|| sender.Text.Contains('-'))
            {
                string result = "";
                foreach (char ch in sender.Text.ToCharArray())
                    if (char.IsDigit(ch)) result += ch;
                sender.Text = result;
            }

        }

        private void FromBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.CheckCurrent())
            {
                using (var context = new parusaContext())
                {
                    List<string> result = new List<string>();
                    string term = fromBox.Text.ToLower();
                    if (term == "") return;
                    var cities = context.Cities.Where(i => i.Name.StartsWith(term)).ToList();
                    if(cities.Count!=0)
                    {
                        List<Airports> ports= new List<Airports>();
                        foreach (var city in cities)
                        {
                           ports.AddRange(context.Airports.Where(i => i.City == city));
                        }
                        foreach(var air in ports)
                        {
                            string country = context.Countries.FirstOrDefault(q=>q.Id==air.City.IdCountry).Name;
                            string item = string.Format("{0}, {1}, {2}",air.City.Name, country, air.Iatacode);
                            result.Add(item);
                        }
                    }
                   // var airports = context.Airports.Where(i => i.Name.ToLower().Contains(term)).ToList();
                    fromBox.ItemsSource = result;
                    fromBox.IsSuggestionListOpen = true;
                }
            }
        }

        private void ReverseLink_Click(object sender, RoutedEventArgs e)
        {
            string buf = fromBox.Text;
            fromBox.Text = toBox.Text;
            toBox.Text = buf;
        }

        private void ToBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.CheckCurrent())
            {
                using (var context = new parusaContext())
                {
                    List<string> result = new List<string>();
                    string term = toBox.Text.ToLower();
                    if (term == "") return;
                    var cities = context.Cities.Where(i => i.Name.StartsWith(term)).ToList();
                    if (cities.Count != 0)
                    {
                        List<Airports> ports = new List<Airports>();
                        foreach (var city in cities)
                        {
                            ports.AddRange(context.Airports.Where(i => i.City == city));
                        }
                        foreach (var air in ports)
                        {
                            string country = context.Countries.FirstOrDefault(q => q.Id == air.City.IdCountry).Name;
                            string item = string.Format("{0}, {1}, {2}", air.City.Name, country, air.Iatacode);
                            result.Add(item);
                        }
                    }
                    // var airports = context.Airports.Where(i => i.Name.ToLower().Contains(term)).ToList();
                    toBox.ItemsSource = result;
                    toBox.IsSuggestionListOpen = true;
                }
            }
        }
    }
}
