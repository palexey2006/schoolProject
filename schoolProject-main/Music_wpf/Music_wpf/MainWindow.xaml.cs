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
                if(ArtistNameBox.Text.Length > 0 && SongNameBox.Text.Length > 0)
                {
                    Releases.Add(DateTime.Parse(ReleaseDateBox.Text));
                    Names.Add(ArtistNameBox.Text);
                    Songs.Add(SongNameBox.Text);
                   
                    MessageBox.Show("You successefully added that song to your playlist");
                }
            } catch
            {
                MessageBox.Show("Wrong data,Try format dd/mm/yyyy");
            }
            ArtistNameBox.Clear();
            SongNameBox.Clear();
            ReleaseDateBox.Clear();
        }

        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            currentSong++;
            if (currentSong == Names.Count)
                currentSong--;
            else
                DisplayInfo();
        }
        private void DisplayInfo()
        {
            NameBox.Text = Names[currentSong];
            SongBox.Text = Songs[currentSong];
            ReleaseBox.Text = Releases[currentSong].ToString("MM/dd/yyyy");
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            currentSong--;
            if (currentSong < 0)
                currentSong = 0;
            else
                DisplayInfo();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (Songs.Contains(SearchBox.Text))
            {
                currentSong = Songs.IndexOf(SearchBox.Text);
                DisplayInfo();
            }
            else
                MessageBox.Show($"The song {SearchBox.Text} not found");
            SearchBox.Clear();
        }
    }
}
