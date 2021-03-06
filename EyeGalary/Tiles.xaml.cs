using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace EyeGalary
{
    /// <summary>
    /// Interaction logic for Tiles.xaml
    /// </summary>
    public partial class Tiles : Page
    {
        public int index { get; set; } = 0;
        public Tiles(MainWindow t)
        {
            InitializeComponent();
            DataContext = t;
        }

        private void Card_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            index = lst.SelectedIndex;
            (DataContext as MainWindow).index = index;           
            (DataContext as MainWindow).showphoto(index);
        }
    }
}
