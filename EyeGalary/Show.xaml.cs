using EyeGalary.model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace EyeGalary
{
    /// <summary>
    /// Interaction logic for Show.xaml
    /// </summary>
    public partial class Show : Page
    {
        public int index;
        private DispatcherTimer PictureTimer = new DispatcherTimer();
        public Show(MainWindow t,int index)
        {
            InitializeComponent();
            this.index = index;
            DataContext = t;    
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (index == 0)
            {
                index= (DataContext as MainWindow).Photos.Count-1;
            }
            else
            {
                index--;
            }
            (DataContext as MainWindow).sPhoto= ((DataContext as MainWindow).Photos[index] as Photo).path;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (index == (DataContext as MainWindow).Photos.Count - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
            (DataContext as MainWindow).sPhoto = ((DataContext as MainWindow).Photos[index] as Photo).path;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Name == "Play")
            {
                PictureTimer.Interval = TimeSpan.FromSeconds(3);
                PictureTimer.Tick += Tick;
                PictureTimer.Start();
            }
            else
            {
                PictureTimer.Stop();
            }
        }
        public void Tick(object sender,EventArgs e)
        {
            Button_Click_1(sender, (e as RoutedEventArgs));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
