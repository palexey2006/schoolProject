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

namespace Music_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BrushConverter brushConverter = new BrushConverter();
        private List<string> Names = new List<string>();
        private List<string> Songs = new List<string>();
        private List<DateTime> Releases = new List<DateTime> ();
        private int currentSong;

        public MainWindow()
        {
            currentSong = 0;
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ArtistNameBox.Text != "" && SongNameBox.Text != "")
                {
                    Releases.Add(DateTime.Parse(ReleaseDateBox.Text));
                    Names.Add(ArtistNameBox.Text);
                    Songs.Add(SongNameBox.Text);
                    ArtistNameBox.Clear();
                    SongNameBox.Clear();
                    ReleaseDateBox.Clear();
                }
            } catch
            {
                MessageBox.Show("Wrong data,Try again");
            }
        }

        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
