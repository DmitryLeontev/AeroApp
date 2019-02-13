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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Aero
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            myFrame.Navigate(typeof(home), this);
            TitleTextBlock.Text = "Главная";
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (home.IsSelected)
            {
                myFrame.Navigate(typeof(home), this);
                TitleTextBlock.Text = "Главная";
            }
            else if (flights.IsSelected)
            {
                myFrame.Navigate(typeof(flights), this);
                TitleTextBlock.Text = "Рейсы";
            }
            else if (orders.IsSelected)
            {
                myFrame.Navigate(typeof(orders), this);
                TitleTextBlock.Text = "Заказы";
            }
            else if (myPortal.IsSelected)
            {
                myFrame.Navigate(typeof(myPortal), this);
                TitleTextBlock.Text = "Личный кабинет";
            }
            else if(discountPage.IsSelected)
            {
                myFrame.Navigate(typeof(discountPage),this);
                TitleTextBlock.Text = "Акции и скидки";
            }
            mySplitView.IsPaneOpen = false;
        }
        public void changeScreen(int i)
        {
            this.menu.SelectedIndex = i;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
