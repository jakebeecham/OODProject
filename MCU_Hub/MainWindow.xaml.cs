using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MCU_Hub.Classes;
using System.IO;
using Newtonsoft.Json;

namespace MCU_Hub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Setup
        List<Project> allProjects = new List<Project>();
        List<Project> chronologicalOrder = new List<Project>();
        List<ComboBox> customListCBBoxes = new List<ComboBox>();
        List<Project> myCustomList = new List<Project>();
        string listName;
        string data;
        Dictionary<string, Project> projectDictionary = new Dictionary<string, Project>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region Project Window
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
            Show show1 = new Show("WandaVision", new DateTime(2021, 1, 15), 360, 9, "12+", "Matt Shakman, Jac Schaeffer",
                "Elizabeth Olsen, Paul Bettany, Teyonah Paris, Kathryn Hahn, Randall Park, Kat Dennings", Project.PhaseType.Four);
            Show show2 = new Show("The Falcon and the Winter Soldier", new DateTime(2021, 3, 19), 360, 6, "12+", "Kari Skogland, Malcolm Spellman",
                "Anthony Mackie, Sebastian Stan, Daniel Bruhl, Emily VanCamp, Wyatt Russell", Project.PhaseType.Four);
            //Unreleased
            Show show3 = new Show("Loki", new DateTime(2021, 6, 11), 360, 6, "12+", "Kate Herron, Michael Waldron",
                "Tom Hiddleston, Owen Wilson", Project.PhaseType.Four);
            Film film23 = new Film("Black Widow", new DateTime(2021, 7, 9), 133, "12+", "Cate Shortland",
                "Scarlett Johansson, Florence Pugh, David Harbour, Rachel Weisz, William Hurt, O-T Fagbenle", Project.PhaseType.Four);
            #endregion
            //Adding All Projects to Collection
            #region Adding To Collections
            #region AllProjects
            allProjects.Add(film4);
            allProjects.Add(film20);
            allProjects.Add(film1);
            allProjects.Add(film2);
            allProjects.Add(film3);
            allProjects.Add(film5);
            allProjects.Add(film6);
            allProjects.Add(film7);
            allProjects.Add(film8);
            allProjects.Add(film9);
            allProjects.Add(film14);
            allProjects.Add(film10);
            allProjects.Add(film11);
            allProjects.Add(film12);
            allProjects.Add(film15);
            allProjects.Add(film13);
            allProjects.Add(film17);
            allProjects.Add(film16);
            allProjects.Add(film19);
            allProjects.Add(film23);
            allProjects.Add(film18);
            allProjects.Add(film21);
            allProjects.Add(show1);
            allProjects.Add(film22);
            allProjects.Add(show2);
            allProjects.Add(show3);
            #endregion
            #region Chronological
            chronologicalOrder.Add(film4);
            chronologicalOrder.Add(film20);
            chronologicalOrder.Add(film1);
            chronologicalOrder.Add(film2);
            chronologicalOrder.Add(film3);
            chronologicalOrder.Add(film5);
            chronologicalOrder.Add(film6);
            chronologicalOrder.Add(film7);
            chronologicalOrder.Add(film8);
            chronologicalOrder.Add(film9);
            chronologicalOrder.Add(film14);
            chronologicalOrder.Add(film10);
            chronologicalOrder.Add(film11);
            chronologicalOrder.Add(film12);
            chronologicalOrder.Add(film15);
            chronologicalOrder.Add(film13);
            chronologicalOrder.Add(film17);
            chronologicalOrder.Add(film16);
            chronologicalOrder.Add(film19);
            chronologicalOrder.Add(film23);
            chronologicalOrder.Add(film18);
            chronologicalOrder.Add(film21);
            chronologicalOrder.Add(show1);
            chronologicalOrder.Add(film22);
            chronologicalOrder.Add(show2);
            chronologicalOrder.Add(show3);
            #endregion
            #region Dictionary
            //Add to Dictionary - To Control Images
            projectDictionary.Add("film1", film1);
            projectDictionary.Add("film2", film2);
            projectDictionary.Add("film3", film3);
            projectDictionary.Add("film4", film4);
            projectDictionary.Add("film5", film5);
            projectDictionary.Add("film6", film6);
            projectDictionary.Add("film7", film7);
            projectDictionary.Add("film8", film8);
            projectDictionary.Add("film9", film9);
            projectDictionary.Add("film10", film10);
            projectDictionary.Add("film11", film11);
            projectDictionary.Add("film12", film12);
            projectDictionary.Add("film13", film13);
            projectDictionary.Add("film14", film14);
            projectDictionary.Add("film15", film15);
            projectDictionary.Add("film16", film16);
            projectDictionary.Add("film17", film17);
            projectDictionary.Add("film18", film18);
            projectDictionary.Add("film19", film19);
            projectDictionary.Add("film20", film20);
            projectDictionary.Add("film21", film21);
            projectDictionary.Add("film22", film22);
            projectDictionary.Add("film23", film23);
            projectDictionary.Add("show1", show1);
            projectDictionary.Add("show2", show2);
            projectDictionary.Add("show3", show3);
            #endregion
            #endregion

            //Sorting in Release Order
            allProjects.Sort();

            //Display in Listbox
            lbxProjects.ItemsSource = allProjects;
            #endregion

            #region CustomList Window
            #region Adding to CB List
            customListCBBoxes.Add(cbBoxCustomNum1);
            customListCBBoxes.Add(cbBoxCustomNum2);
            customListCBBoxes.Add(cbBoxCustomNum3);
            customListCBBoxes.Add(cbBoxCustomNum4);
            customListCBBoxes.Add(cbBoxCustomNum5);
            customListCBBoxes.Add(cbBoxCustomNum6);
            customListCBBoxes.Add(cbBoxCustomNum7);
            customListCBBoxes.Add(cbBoxCustomNum8);
            customListCBBoxes.Add(cbBoxCustomNum9);
            customListCBBoxes.Add(cbBoxCustomNum10);
            #endregion
            foreach (ComboBox comboBox in customListCBBoxes)
                comboBox.ItemsSource = allProjects;
            #endregion
        }
        #endregion

        #region Home Page Interactions
        //Open Project Tab
        private void btnOpenProjects_Click(object sender, RoutedEventArgs e)
        {
            Projects.IsSelected = true;
            Reset();
        }

        //Open Custom List Tab
        private void btnCreateList_Click(object sender, RoutedEventArgs e)
        {
            CustomList.IsSelected = true;
        }

        //Exit Application
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion

        #region Projects Page Interactions
        #region Projects_Filtering
        //Filter Based on Combo Box
        private void cbBoxFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Determine what is selected
            string selectedFilter = cbBoxFilter.SelectedItem as string;

            //Setup Filter List
            List<Project> filteredProjects = new List<Project>();

            //Check
            switch (selectedFilter)
            {
                case "Release Order":
                    lbxProjects.ItemsSource = null;
                    lbxProjects.ItemsSource = allProjects;
                    Reset();
                    break;

                case "Chronological Order":
                    lbxProjects.ItemsSource = null;
                    lbxProjects.ItemsSource = chronologicalOrder;
                    Reset();
                    break;

                case "Phase One":
                    foreach (Project project in allProjects)
                    {
                        if (project.Phase is Project.PhaseType.One)
                            filteredProjects.Add(project);
                    }
                    lbxProjects.ItemsSource = filteredProjects;
                    Reset();
                    break;

                case "Phase Two":
                    foreach (Project project in allProjects)
                    {
                        if (project.Phase is Project.PhaseType.Two)
                            filteredProjects.Add(project);
                    }
                    lbxProjects.ItemsSource = filteredProjects;
                    Reset();
                    break;

                case "Phase Three":
                    foreach (Project project in allProjects)
                    {
                        if (project.Phase is Project.PhaseType.Three)
                            filteredProjects.Add(project);
                    }
                    lbxProjects.ItemsSource = filteredProjects;
                    Reset();
                    break;

                case "Phase Four":
                    foreach (Project project in allProjects)
                    {
                        if (project.Phase is Project.PhaseType.Four)
                            filteredProjects.Add(project);
                    }
                    lbxProjects.ItemsSource = filteredProjects;
                    Reset();
                    break;
            }
        }
        #endregion

        #region Projects_Selection
        private void lbxProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Project selectedProject = lbxProjects.SelectedItem as Project;

            if (selectedProject != null)
            {   
                if (selectedProject is Film)
                {
                    SetFilmImages(selectedProject);
                    Film tempFilm = selectedProject as Film;
                    tblkDescription.Text = string.Format($"Title : {tempFilm.Title}" +
                    $"\nRelease Date : {tempFilm.ReleaseDate.Date.ToString("d")}" +
                    $"\nDuration : {tempFilm.Duration} minutes" +
                    $"\nRating : {tempFilm.Rating}" +
                    $"\nCast : {tempFilm.Cast}" +
                    $"\nDirector : {tempFilm.Director}" +
                    $"\nPhase : Phase {tempFilm.Phase}");
                }
                if(selectedProject is Show)
                {
                    SetShowImages(selectedProject);
                    Show tempShow = selectedProject as Show;
                    tblkDescription.Text = string.Format($"Title : {tempShow.Title}" +
                    $"\nRelease Date : {tempShow.ReleaseDate.Date.ToString("d")}" +
                    $"\nDuration : {tempShow.Duration} minutes" +
                    $"\nRating : {tempShow.Rating}" +
                    $"\nCast : {tempShow.Cast}" +
                    $"\nCreator(s) : {tempShow.Creator}" +
                    $"\nEpisodes : {tempShow.NumberOfEpisodes} Episodes" +
                    $"\nPhase : Phase {tempShow.Phase}");
                }
            }
        }

        private void SetFilmImages(Project selectedProject)
        {
            for (int i = 0; i < projectDictionary.Count - 3; i++)
            {
                if (selectedProject == projectDictionary["film" + (i + 1)])
                {
                    if (i + 1 == 1)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film1.jpg", UriKind.Relative));
                    if (i + 1 == 2)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film2.jpg", UriKind.Relative));
                    if (i + 1 == 3)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film3.jpg", UriKind.Relative));
                    if (i + 1 == 4)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film4.jpg", UriKind.Relative));
                    if (i + 1 == 5)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film5.jpg", UriKind.Relative));
                    if (i + 1 == 6)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film6.jpg", UriKind.Relative));
                    if (i + 1 == 7)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film7.jpg", UriKind.Relative));
                    if (i + 1 == 8)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film8.jpg", UriKind.Relative));
                    if (i + 1 == 9)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film9.jpg", UriKind.Relative));
                    if (i + 1 == 10)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film10.jpg", UriKind.Relative));
                    if (i + 1 == 11)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film11.jpg", UriKind.Relative));
                    if (i + 1 == 12)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film12.jpg", UriKind.Relative));
                    if (i + 1 == 13)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film13.jpg", UriKind.Relative));
                    if (i + 1 == 14)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film14.jpg", UriKind.Relative));
                    if (i + 1 == 15)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film15.jpg", UriKind.Relative));
                    if (i + 1 == 16)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film16.jpg", UriKind.Relative));
                    if (i + 1 == 17)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film17.jpg", UriKind.Relative));
                    if (i + 1 == 18)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film18.jpg", UriKind.Relative));
                    if (i + 1 == 19)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film19.jpg", UriKind.Relative));
                    if (i + 1 == 20)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film20.jpg", UriKind.Relative));
                    if (i + 1 == 21)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film21.jpg", UriKind.Relative));
                    if (i + 1 == 22)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film22.jpg", UriKind.Relative));
                    if (i + 1 == 23)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/film23.jpg", UriKind.Relative));
                }
            }
        }

        private void SetShowImages(Project selectedProject)
        {
            for (int i = 0; i < projectDictionary.Count - 23; i++)
            {
                if (selectedProject == projectDictionary["show" + (i + 1)])
                {
                    if (i + 1 == 1)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/show1.jpg", UriKind.Relative));
                    if (i + 1 == 2)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/show2.jpg", UriKind.Relative));
                    if (i + 1 == 3)
                        imgProject.Source = new BitmapImage(new Uri(@"/Images/show3.jpg", UriKind.Relative));
                }
            }
        }
        #endregion

        private void Reset()
        {
            lbxProjects.SelectedItem = null;
            imgProject.Source = new BitmapImage(new Uri(@"/Images/MarvelStudios.png", UriKind.Relative));
            tblkDescription.Text = "Select a Project to View Description!";
        }
        #endregion

        #region CustomList Page Interactions
        private void tbxListName_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxListName.Text = "";
        }

        #region CustomList_Save
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(tbxListName.Text != "" && 
                tbxListName.Text != "Enter the Name of your New List Here...")
            {
                GetCustomListInfo();

                if (myCustomList.Count > 0)
                {
                    data = JsonConvert.SerializeObject(myCustomList, Formatting.Indented);

                    using (StreamWriter sw = new StreamWriter("../CustomLists/myCustomLists.json"))
                    {
                        sw.Write(listName + ":");
                        sw.Write(data);
                        sw.Close();
                    }

                    MessageBox.Show($"{listName} has been saved successfully!" +
                        $"\nYour List can be found in the bin folder of the Project under CustomLists.", "Success!");
                    Clear();
                }
                else
                {
                    MessageBox.Show("To Save a List you must Enter at least 1 Entry!");
                    Clear();
                }
            }
            else
            {
                MessageBox.Show("To Save a List you must have a List Name!");
                Clear();
            }
        }

        private void GetCustomListInfo()
        {
            foreach (ComboBox comboBox in customListCBBoxes)
            {
                if (comboBox.SelectedItem != null && comboBox.SelectedItem is Project)
                    myCustomList.Add(comboBox.SelectedItem as Project);
            }

            listName = tbxListName.Text;
        }
        #endregion

        #region CustomList_Clear
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            foreach (ComboBox comboBox in customListCBBoxes)
                comboBox.SelectedItem = null;

            myCustomList.Clear();
            tbxListName.Text = "Enter the Name of your New List Here...";
        }
        #endregion
        #endregion
    }
}
