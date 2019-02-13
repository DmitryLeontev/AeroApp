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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Aero
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class home : Page
    {
       static  MainPage myframe;
        public home()
        {
            this.InitializeComponent();
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
                myframe = e.Parameter as MainPage;
        }
        private void GoFlight_Click(object sender, RoutedEventArgs e)
        {
            myframe.changeScreen(1);
        }

        private void OrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            myframe.changeScreen(2);
        }

        private void DiscountBtn_Click(object sender, RoutedEventArgs e)
        {
            myframe.changeScreen(4);
        }

        private void MyPortalBtn_Click(object sender, RoutedEventArgs e)
        {
            myframe.changeScreen(3);
        }
    }
}
