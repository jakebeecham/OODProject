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

namespace MCU_Hub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Setup

        List<Project> allProjects = new List<Project>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Populate Combo Box
            string[] filterTypes = { "Release Order", "Chronological Order", "Phase One", "Phase Two", "Phase Three", "Phase Four" };
            cbBoxFilter.ItemsSource = filterTypes;
            cbBoxFilter.SelectedItem = "Release Order";

            //Creating All Projects
            Film film1 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau",
                "Robert Downey Jr., Gwyneth Paltrow, Jeff Bridges, Terrence Howard, Jon Favreau, Paul Bettany", Project.PhaseType.One);
            Film film2 = new Film("Iron Man 2", new DateTime(2010, 4, 30), 125, "12+", "Jon Favreau", 
                "Robert Downey Jr., Gwyneth Paltrow, Don Cheadle, Scarlett Johansson, Sam Rockwell, Clark Gregg", Project.PhaseType.One);
            Film film3 = new Film("Thor", new DateTime(2011, 4, 27), 116, "12+", "Kenneth Branagh",
                "Chris Hemsworth, Natalie Portman, Tom Hiddleston, Anthony Hopkins, Stellan Skarsgard, Idris Elba", Project.PhaseType.One);
            Film film4 = new Film("Captain America: The First Avenger", new DateTime(2011, 7, 29), 126, "12+", "Joe Johnston",
                "Chris Evans, Hayley Atwell, Hugo Weaving, Sebastian Stan, Tommy Lee Jones, Dominic Cooper", Project.PhaseType.One);
            Film film5 = new Film("The Avengers", new DateTime(2012, 5, 4), 145, "12+", "Joss Whedon", 
                "Robert Downey Jr., Chris Evans, Chris Hemsworth, Mark Ruffalo, Scarlett Johansson, Jeremy Renner", Project.PhaseType.One);
            Film film6 = new Film("Iron Man 3", new DateTime(2013, 4, 26), 132, "12+", "Shane Black", 
                "Robert Downey Jr., Gwyneth Paltrow, Don Cheadle, Guy Pearce, Paul Bettany, Ty Simpkins", Project.PhaseType.Two);
            Film film7 = new Film("Thor: The Dark World", new DateTime(2013, 11, 8), 114, "12+", "Alan Taylor",
                "Chris Hemsworth, Natalie Portman, Tom Hiddleston, Anthony Hopkins, Rene Russo, Stellan Skarsgard", Project.PhaseType.Two);
            Film film8 = new Film("Captain America: The Winter Soldier", new DateTime(2014, 3, 26), 137, "12+", "Anthony Russo, Joe Russo",
                "Chris Evans, Scarlett Johansson, Sebastian Stan, Anthony Mackie, Robert Redford, Cobie Smulders", Project.PhaseType.Two);
            Film film9 = new Film("Guardians of the Galaxy", new DateTime(2014, 7, 31), 122, "12+", "James Gunn",
                "Chris Pratt, Zoe Saldana, Dave Bautista, Bradley Cooper, Vin Diesel, Lee Pace", Project.PhaseType.Two);
            Film film10 = new Film("Avengers: Age of Ultron", new DateTime(2015, 4, 23), 143, "12+", "Joss Whedon",
                "Robert Downey Jr., Chris Evans, Chris Hemsworth, Mark Ruffalo, Scarlett Johansson, Jeremy Renner", Project.PhaseType.Two);
            Film film11 = new Film("Ant-Man", new DateTime(2015, 7, 17), 118, "12+", "Peyton Reed",
                "Paul Rudd, Evangeline Lilly, Michael Douglas, Corey Stoll, Michael Pena, Bobby Cannavale", Project.PhaseType.Two);
            //Film film12 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.Three);
            //Film film13 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.Three);
            //Film film14 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.Three);
            //Film film15 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.Three);
            //Film film16 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.Three);
            //Film film17 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.Three);
            //Film film18 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.Three);
            //Film film19 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.Three);
            //Film film20 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.Three);
            //Film film21 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.Three);
            //Film film22 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.Three);
            //Show show1 = new Show();
            //Show show2 = new Show();
            //Show show3 = new Show();
            //Film film23 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.Four);
        }

        #endregion
    }
}
