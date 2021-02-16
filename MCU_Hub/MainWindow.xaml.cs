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
            #region Creating Objects
            //Phase One
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
            //Phase Two
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
            //Phase Three
            Film film12 = new Film("Captain America: Civil War", new DateTime(2016, 4, 29), 149, "12+", "Anthony Russo, Joe Russo",
                "Chris Evans, Robert Downey Jr., Scarlett Johansson, Sebastian Stan, Anthony Mackie, Chadwick Boseman", Project.PhaseType.Three);
            Film film13 = new Film("Doctor Strange", new DateTime(2016, 10, 25), 116, "12+", "Scott Derrickson",
                "Benedict Cumberbatch, Chiwetel Ejiofor, Rachel McAdams, Tilda Swinton, Mads Mikkelsen, Benedict Wong", Project.PhaseType.Three);
            Film film14 = new Film("Guardians of the Galaxy Vol. 2", new DateTime(2017, 4, 28), 137, "12+", "James Gunn",
                "Chris Pratt, Zoe Saldana, Dave Bautista, Bradley Cooper, Michael Rooker, Karen Gillan", Project.PhaseType.Three);
            Film film15 = new Film("Spider-Man: Homecoming", new DateTime(2017, 7, 7), 133, "12+", "Jon Watts",
                "Tom Holland, Michael Keaton, Zendaya, Jacob Batalon, Jon Favreau, Marisa Tomei", Project.PhaseType.Three);
            Film film16 = new Film("Thor: Ragnorok", new DateTime(2017, 10, 24), 131, "12+", "Taika Waititi",
                "Chris Hemsworth, Tom Hiddleston, Cate Blanchett, Idris Elba, Jeff Goldblum, Tessa Thompson", Project.PhaseType.Three);
            Film film17 = new Film("Black Panther", new DateTime(2018, 2, 13), 136, "12+", "Ryan Coogler",
                "Chadwick Boseman, Michael B. Jordan, Lupita Nyong'o, Danai Gurira, Letitia Wright, Martin Freeman", Project.PhaseType.Three);
            Film film18 = new Film("Avengers: Infinity War", new DateTime(2018, 4, 26), 151, "12+", "Anthony Russo, Joe Russo",
                "Robert Downey Jr., Chris Evans, Chris Hemsworth, Mark Ruffalo, Scarlett Johansson, Josh Brolin", Project.PhaseType.Three);
            Film film19 = new Film("Ant-Man and the Wasp", new DateTime(2018, 8, 2), 120, "12+", "Peyton Reed",
                "Paul Rudd, Evangeline Lilly, Michael Douglas, Hannah John-Kamen, Michael Pena, Michelle Pfeiffer", Project.PhaseType.Three);
            Film film20 = new Film("Captain Marvel", new DateTime(2019, 3, 8), 127, "12+", "Anna Boden, Ryan Fleck",
                "Brie Larson, Samuel L. Jackson, Ben Mendelsohn, Jude Law, Annette Bening, Lashana Lynch", Project.PhaseType.Three);
            Film film21 = new Film("Avengers: Endgame", new DateTime(2019, 4, 25), 183, "12+", "Anthony Russo, Joe Russo",
                "Robert Downey Jr., Chris Evans, Chris Hemsworth, Mark Ruffalo, Scarlett Johansson, Jeremy Renner", Project.PhaseType.Three);
            Film film22 = new Film("Spider-Man: Far From Home", new DateTime(2019, 7, 2), 129, "12+", "Jon Watts",
                "Tom Holland, Jake Gyllenhaal, Samuel L. Jackson, Zendaya, Cobie Smulders, Jon Favreau", Project.PhaseType.Three);
            //Phase Four
            Show show1 = new Show("WandaVision", new DateTime(2021, 1, 15), 360, 9, "9+", "Jac Schaeffer, Matt Shakman",
                "Elizabeth Olsen, Paul Bettany, Teyonah Paris, Kathryn Hahn, Randall Park, Kat Dennings", Project.PhaseType.Four);
            //Unreleased
            Show show2 = new Show("The Falcon and the Winter Soldier", new DateTime(2021, 3, 19), 360, 9, "9+", "Malcolm Spellman",
                "Anthony Mackie, Sebastian Stan, Daniel Bruhl, Emily VanCamp, Wyatt Russell", Project.PhaseType.Four);
            Film film23 = new Film("Black Widow", new DateTime(2021, 5, 7), 133, "12+", "Cate Shortland",
                "Scarlett Johansson, Florence Pugh, David Harbour, Rachel Weisz, William Hurt, O-T Fagbenle", Project.PhaseType.Four);
            Show show3 = new Show("Loki", new DateTime(2021, 5, 28), 360, 9, "9+", "Michael Waldron",
                "Tom Hiddleston, Owen Wilson", Project.PhaseType.Four);
            #endregion
            //Adding All Projects to Collection
            #region Adding To Collection
            allProjects.Add(film1);
            allProjects.Add(film2);
            allProjects.Add(film3);
            allProjects.Add(film4);
            allProjects.Add(film5);
            allProjects.Add(film6);
            allProjects.Add(film7);
            allProjects.Add(film8);
            allProjects.Add(film9);
            allProjects.Add(film10);
            allProjects.Add(film11);
            allProjects.Add(film12);
            allProjects.Add(film13);
            allProjects.Add(film14);
            allProjects.Add(film15);
            allProjects.Add(film16);
            allProjects.Add(film17);
            allProjects.Add(film18);
            allProjects.Add(film19);
            allProjects.Add(film20);
            allProjects.Add(film21);
            allProjects.Add(film22);
            allProjects.Add(show1);
            allProjects.Add(show2);
            allProjects.Add(film23);
            allProjects.Add(show3);
            #endregion

            //Display in Listbox
            lbxProjects.ItemsSource = allProjects;
        }
        #endregion
    }
}
