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
using System.Collections.ObjectModel;
using System.Collections.Specialized;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Aero
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    /// 
    public class FlClass
    {
        public Visibility vis { get; set; }
        public int id;
        public FlClass( Visibility vi, int ID)
        {
            vis = vi;
            id = ID;
        }
    }
    public sealed partial class flights : Page
    {
        ObservableCollection<FlClass> Fls = new ObservableCollection<FlClass>();
        public flights()
        {
            this.InitializeComponent();
            itemsFlights.CanBeScrollAnchor = true;
            itemsFlights.SelectionMode = ListViewSelectionMode.None;
            add();
        }
        private void add()
        {
            Fls = new ObservableCollection<FlClass> { new FlClass(Visibility.Collapsed, 1), new FlClass(Visibility.Collapsed, 2), new FlClass(Visibility.Visible, 3) };
            itemsFlights.ItemsSource = Fls;
        }
        private void MoreInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem item = (ListViewItem)((StackPanel)((VariableSizedWrapGrid)((StackPanel)
                (((HyperlinkButton)e.OriginalSource)
                .Parent)).Parent).Parent).Parent;
            FlClass fl = (FlClass)item.DataContext;
            if (fl.vis == Visibility.Collapsed)
            {
                fl.vis = Visibility.Visible;
            }
            else fl.vis = Visibility.Collapsed;

            FlClass ind=  Fls.FirstOrDefault(q=>q.id==fl.id);
            int index = Fls.IndexOf(ind);
            Fls[index] = fl;
            itemsFlights.ItemsSource = Fls;
        }
    }
}
