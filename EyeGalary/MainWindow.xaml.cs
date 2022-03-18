using EyeGalary.model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using RadioButton = System.Windows.Controls.RadioButton;

namespace EyeGalary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public int index { get; set; }
        public string SPhoto;
        public string sPhoto { get=>SPhoto; set { SPhoto = value; OnPropertyChanged();}}
        public ObservableCollection<Photo> Photos { get; set; }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public MainWindow()
        {            
            InitializeComponent();            
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as RadioButton) != null)
            {
                if ((sender as RadioButton).Content.ToString() == "Tiles")
                {
                    tils.Navigate(new Tiles(this));
                }
                else if ((sender as RadioButton).Content.ToString() == "Details")
                {
                    tils.Navigate(new Details(this));
                }
                else if ((sender as RadioButton).Content.ToString() == "Small icons")
                {
                    tils.Navigate(new smallico(this));
                }
            }
        }

        public void showphoto(int index)
        {
            var t = new Show(this,index);
            sPhoto = Photos[index].path;
            tils.Navigate(t);

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            (tiles as RadioButton).IsChecked=true;            
            tils.Navigate(new Tiles(this)) ;
        }

        private void Open_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var t = new FolderBrowserDialog();
            if (t.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {               
                Photos = new ObservableCollection<Photo>();
                string supportedExtensions = "*.jpg,*.png,*.jpeg";               
                foreach (string imageFile in Directory.GetFiles(t.SelectedPath, "*.*", SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(System.IO.Path.GetExtension(s).ToLower())))
                {                    
                    Photos.Add(new Photo() { path = imageFile, title = imageFile.Split('\\').Last(), time = DateTime.Now });                    
                }                
            }
            index = 0;
            if ((bool)tiles.IsChecked)
            {
                
                tils.Navigate(new Tiles(this));
            }
            if ((bool)sm_ico.IsChecked)
            {
                tils.Navigate(new Details(this));
            }
            if ((bool)dtl.IsChecked)
            {
                tils.Navigate(new smallico(this));
            }
        }

        private void addf_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();            
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Photos.Add(new Photo() { path = op.FileName, title = op.FileName.Split('\\').Last(), time = DateTime.Now });
            }
        }

        private void adf_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var t = new FolderBrowserDialog();
            if (t.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {                
                string supportedExtensions = "*.jpg,*.png,*.jpeg";
                foreach (string imageFile in Directory.GetFiles(t.SelectedPath, "*.*", SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(System.IO.Path.GetExtension(s).ToLower())))
                {
                    Photos.Add(new Photo() { path = imageFile, title = imageFile.Split('\\').Last(), time = DateTime.Now });
                }
            }
            index = 0;
            if ((bool)tiles.IsChecked)
            {

                tils.Navigate(new Tiles(this));
            }
            if ((bool)sm_ico.IsChecked)
            {
                tils.Navigate(new Details(this));
            }
            if ((bool)dtl.IsChecked)
            {
                tils.Navigate(new smallico(this));
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           
            Photos = new ObservableCollection<Photo>();            
            index = 0;
            if ((bool)tiles.IsChecked)
            {

                tils.Navigate(new Tiles(this));
            }
            if ((bool)sm_ico.IsChecked)
            {
                tils.Navigate(new Details(this));
            }
            if ((bool)dtl.IsChecked)
            {
                tils.Navigate(new smallico(this));
            }
        }
    }
}
