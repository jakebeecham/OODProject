﻿using System;
using System.Linq;
using System.Collections.Generic;
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
    /// 
    /// DATABASE FILE - MCUHub.mdf - Is stored in OOD_Project Folder, Solution Folder.
    /// GITHUB LINK - https://github.com/S00197638/OODProject
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Setup
        List<Project> allProjects = new List<Project>();//List of all Projects
        List<Project> chronologicalOrder = new List<Project>();//List of all Projects in chronological order
        List<ComboBox> customListCBBoxes = new List<ComboBox>();//List of ComboBoxes for the Custom List
        List<Project> myCustomList = new List<Project>();//List of projects for Custom List
        string listName, data;//string for Custom List name, string for custom list data to be saved to file
        Random rng = new Random();//Random for Sales figures
        MCUHubModelContainer db;//Reference to Database

        public MainWindow()
        {
            InitializeComponent();
        }

        //Window Loaded Event
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Database Setup
            db = new MCUHubModelContainer();

            //Project Window Setup
            #region Project Window
            //Populate Combo Box
            string[] filterTypes = { "Release Order", "Chronological Order", "Phase One", "Phase Two", "Phase Three", "Phase Four" };
            cbBoxFilter.ItemsSource = filterTypes;
            cbBoxFilter.SelectedItem = "Release Order";

            //Creating All Projects
            #region Creating Objects
            //Phase One
            Film film1 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau",
                "Robert Downey Jr., Gwyneth Paltrow, Jeff Bridges, Terrence Howard, Jon Favreau, Paul Bettany", 
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.One);
            Film film2 = new Film("Iron Man 2", new DateTime(2010, 4, 30), 125, "12+", "Jon Favreau", 
                "Robert Downey Jr., Gwyneth Paltrow, Don Cheadle, Scarlett Johansson, Sam Rockwell, Clark Gregg", 
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.One);
            Film film3 = new Film("Thor", new DateTime(2011, 4, 27), 116, "12+", "Kenneth Branagh",
                "Chris Hemsworth, Natalie Portman, Tom Hiddleston, Anthony Hopkins, Stellan Skarsgard, Idris Elba", 
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.One);
            Film film4 = new Film("Captain America: The First Avenger", new DateTime(2011, 7, 29), 126, "12+", "Joe Johnston",
                "Chris Evans, Hayley Atwell, Hugo Weaving, Sebastian Stan, Tommy Lee Jones, Dominic Cooper", 
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.One);
            Film film5 = new Film("The Avengers", new DateTime(2012, 5, 4), 145, "12+", "Joss Whedon", 
                "Robert Downey Jr., Chris Evans, Chris Hemsworth, Mark Ruffalo, Scarlett Johansson, Jeremy Renner",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.One);
            //Phase Two
            Film film6 = new Film("Iron Man 3", new DateTime(2013, 4, 26), 132, "12+", "Shane Black", 
                "Robert Downey Jr., Gwyneth Paltrow, Don Cheadle, Guy Pearce, Paul Bettany, Ty Simpkins",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Two);
            Film film7 = new Film("Thor: The Dark World", new DateTime(2013, 11, 8), 114, "12+", "Alan Taylor",
                "Chris Hemsworth, Natalie Portman, Tom Hiddleston, Anthony Hopkins, Rene Russo, Stellan Skarsgard",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Two);
            Film film8 = new Film("Captain America: The Winter Soldier", new DateTime(2014, 3, 26), 137, "12+", "Anthony Russo, Joe Russo",
                "Chris Evans, Scarlett Johansson, Sebastian Stan, Anthony Mackie, Robert Redford, Cobie Smulders",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Two);
            Film film9 = new Film("Guardians of the Galaxy", new DateTime(2014, 7, 31), 122, "12+", "James Gunn",
                "Chris Pratt, Zoe Saldana, Dave Bautista, Bradley Cooper, Vin Diesel, Lee Pace",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Two);
            Film film10 = new Film("Avengers: Age of Ultron", new DateTime(2015, 4, 23), 143, "12+", "Joss Whedon",
                "Robert Downey Jr., Chris Evans, Chris Hemsworth, Mark Ruffalo, Scarlett Johansson, Jeremy Renner",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Two);
            Film film11 = new Film("Ant-Man", new DateTime(2015, 7, 17), 118, "12+", "Peyton Reed",
                "Paul Rudd, Evangeline Lilly, Michael Douglas, Corey Stoll, Michael Pena, Bobby Cannavale",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Two);
            //Phase Three
            Film film12 = new Film("Captain America: Civil War", new DateTime(2016, 4, 29), 149, "12+", "Anthony Russo, Joe Russo",
                "Chris Evans, Robert Downey Jr., Scarlett Johansson, Sebastian Stan, Anthony Mackie, Chadwick Boseman",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Three);
            Film film13 = new Film("Doctor Strange", new DateTime(2016, 10, 25), 116, "12+", "Scott Derrickson",
                "Benedict Cumberbatch, Chiwetel Ejiofor, Rachel McAdams, Tilda Swinton, Mads Mikkelsen, Benedict Wong",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Three);
            Film film14 = new Film("Guardians of the Galaxy Vol. 2", new DateTime(2017, 4, 28), 137, "12+", "James Gunn",
                "Chris Pratt, Zoe Saldana, Dave Bautista, Bradley Cooper, Michael Rooker, Karen Gillan",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Three);
            Film film15 = new Film("Spider-Man: Homecoming", new DateTime(2017, 7, 7), 133, "12+", "Jon Watts",
                "Tom Holland, Michael Keaton, Zendaya, Jacob Batalon, Jon Favreau, Marisa Tomei",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Three);
            Film film16 = new Film("Thor: Ragnorok", new DateTime(2017, 10, 24), 131, "12+", "Taika Waititi",
                "Chris Hemsworth, Tom Hiddleston, Cate Blanchett, Idris Elba, Jeff Goldblum, Tessa Thompson",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Three);
            Film film17 = new Film("Black Panther", new DateTime(2018, 2, 13), 136, "12+", "Ryan Coogler",
                "Chadwick Boseman, Michael B. Jordan, Lupita Nyong'o, Danai Gurira, Letitia Wright, Martin Freeman",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Three);
            Film film18 = new Film("Avengers: Infinity War", new DateTime(2018, 4, 26), 151, "12+", "Anthony Russo, Joe Russo",
                "Robert Downey Jr., Chris Evans, Chris Hemsworth, Mark Ruffalo, Scarlett Johansson, Josh Brolin",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Three);
            Film film19 = new Film("Ant-Man and the Wasp", new DateTime(2018, 8, 2), 120, "12+", "Peyton Reed",
                "Paul Rudd, Evangeline Lilly, Michael Douglas, Hannah John-Kamen, Michael Pena, Michelle Pfeiffer",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Three);
            Film film20 = new Film("Captain Marvel", new DateTime(2019, 3, 8), 127, "12+", "Anna Boden, Ryan Fleck",
                "Brie Larson, Samuel L. Jackson, Ben Mendelsohn, Jude Law, Annette Bening, Lashana Lynch",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Three);
            Film film21 = new Film("Avengers: Endgame", new DateTime(2019, 4, 25), 183, "12+", "Anthony Russo, Joe Russo",
                "Robert Downey Jr., Chris Evans, Chris Hemsworth, Mark Ruffalo, Scarlett Johansson, Jeremy Renner",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Three);
            Film film22 = new Film("Spider-Man: Far From Home", new DateTime(2019, 7, 2), 129, "12+", "Jon Watts",
                "Tom Holland, Jake Gyllenhaal, Samuel L. Jackson, Zendaya, Cobie Smulders, Jon Favreau",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Three);
            //Phase Four
            Show show1 = new Show("WandaVision", new DateTime(2021, 1, 15), 360, 9, "12+", "Matt Shakman, Jac Schaeffer",
                "Elizabeth Olsen, Paul Bettany, Teyonah Paris, Kathryn Hahn, Randall Park, Kat Dennings",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Four);
            Show show2 = new Show("The Falcon and the Winter Soldier", new DateTime(2021, 3, 19), 360, 6, "12+", "Kari Skogland, Malcolm Spellman",
                "Anthony Mackie, Sebastian Stan, Daniel Bruhl, Emily VanCamp, Wyatt Russell",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Four);
            //Unreleased
            Show show3 = new Show("Loki", new DateTime(2021, 6, 11), 360, 6, "12+", "Kate Herron, Michael Waldron",
                "Tom Hiddleston, Owen Wilson", LongRandom(100000000, 3000000000, rng), Project.PhaseType.Four);
            Film film23 = new Film("Black Widow", new DateTime(2021, 7, 9), 133, "12+", "Cate Shortland",
                "Scarlett Johansson, Florence Pugh, David Harbour, Rachel Weisz, William Hurt, O-T Fagbenle",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Four);
            Film film24 = new Film("Shang-Chi and the Legend of The Ten Rings", new DateTime(2021, 9, 3), 133, "12+", "Destin Daniel Cretton",
                "Simu Liu, Awkwafina, Tony Leung, Michelle Yeoh, Fala Chen, Florian Munteanu",
                LongRandom(100000000, 3000000000, rng), Project.PhaseType.Four);
            #endregion

            //Adding All Projects to Collections
            #region Adding To Collections
            //Adding to AllProjects list, does not matter what order they added
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
            allProjects.Add(show3);
            allProjects.Add(show1);
            allProjects.Add(show2);
            allProjects.Add(film22);
            allProjects.Add(film24);
            #endregion
            //Adding to Chronological List, adding them into the list in chronological order
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
            chronologicalOrder.Add(show3);
            chronologicalOrder.Add(show1);
            chronologicalOrder.Add(show2);
            chronologicalOrder.Add(film22);
            chronologicalOrder.Add(film24);
            #endregion
            #endregion

            //Setting Images for All Projects
            #region Setting Images
            //Go through each project and pull the correct image from the Database
            foreach (Project project in allProjects)
            {
                //Using query to call the database and search for image
                //Checking if the Name of the projects' match
                var query = db.Images
                    .Where(i => i.Name == project.Title)
                    .Select(i => i.Source);
                project.ProjectImage = query.First().ToString();
            }
            #endregion

            //Sorting in Release Order
            //Uses CompareTo Method to sort by ReleaseDate to get Release Order
            allProjects.Sort();

            //Display in Listbox
            //I want it to display in release Order by default
            lbxProjects.ItemsSource = allProjects;
            #endregion

            //CustomList Window Setup
            #region CustomList Window
            CustomListPageSetup();
            #endregion
        }

        //Item Researched from the Internet
        //Method to obtain a Random long number
        public long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }

        //Setup CustomList Page
        private void CustomListPageSetup()
        {
            //Adding all ComboBoxes to List
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
            //Sets all ComboBoxes Source to be allProjects so a project can be chosen
            foreach (ComboBox comboBox in customListCBBoxes)
                comboBox.ItemsSource = allProjects;
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
        //Filtering System on Projects Page
        #region Projects_Filtering
        //Filter Based on Combo Box
        private void cbBoxFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Determine what is selected
            string selectedFilter = cbBoxFilter.SelectedItem as string;
            //Setup Filter List
            List<Project> filteredProjects = new List<Project>();
            //Check Filters
            CheckFilters(selectedFilter, filteredProjects);
        }

        //Check Filters
        private void CheckFilters(string selectedFilter, List<Project> filteredProjects)
        {
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

        //Selection System on Projects Page
        #region Projects_Selection
        //Listbox Selection Changed Event
        private void lbxProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Clear Instruction
            lblInstruction.Content = "";
            
            //Get selected project
            Project selectedProject = lbxProjects.SelectedItem as Project;

            if (selectedProject != null)//Checking if a project is selected
            {
                if (selectedProject is Film)//Checking If a Film
                {
                    //Setting Image Display
                    SetImageDisplay(selectedProject);
                    //Casting Selected Project to Film as it is a Film
                    Film tempFilm = selectedProject as Film;
                    //Setting Film Output
                    SetFilmOutput(tempFilm);
                }
                if (selectedProject is Show)//Checking If a Show
                {
                    //Setting Image Display
                    SetImageDisplay(selectedProject);
                    //Casting to Show
                    Show tempShow = selectedProject as Show;
                    //Setting Show Output
                    SetShowOutput(tempShow);
                }
            }
        }

        //Set Image Display
        private void SetImageDisplay(Project selectedProject)
        {
            //Set the img source to the correct image and Display
            imgProject.Source = new BitmapImage(
                new Uri(selectedProject.ProjectImage, UriKind.Relative));
        }

        //Set Film Output
        private void SetFilmOutput(Film tempFilm)
        {
            //Setting Output
            tblkDescription.Text = string.Format($"Title : {tempFilm.Title}\n" +
            $"\nRelease Date : {tempFilm.ReleaseDate.Date.ToString("d")}" +
            $"\nDuration : {tempFilm.Duration} minutes" +
            $"\nRating : {tempFilm.Rating}\n" +
            $"\nCast : {tempFilm.Cast}\n" +
            $"\nDirector(s) : {tempFilm.Director}\n" +
            $"\nSales : {tempFilm.Sales:C}" +
            $"\nPhase : Phase {tempFilm.Phase}");
        }

        //Set Show Output
        private void SetShowOutput(Show tempShow)
        {
            //Setting Output
            tblkDescription.Text = string.Format($"Title : {tempShow.Title}\n" +
            $"\nRelease Date : {tempShow.ReleaseDate.Date.ToString("d")}" +
            $"\nDuration : {tempShow.Duration} minutes" +
            $"\nEpisodes : {tempShow.NumberOfEpisodes} Episodes" +
            $"\nRating : {tempShow.Rating}\n" +
            $"\nCast : {tempShow.Cast}\n" +
            $"\nCreator(s) : {tempShow.Creator}\n" +
            $"\nSales : {tempShow.Sales:C}" +
            $"\nPhase : Phase {tempShow.Phase}");
        }
        #endregion

        //Reset Projects Screen
        private void Reset()
        {
            lbxProjects.SelectedItem = null;
            //Using query to call database and retrieve default image
            var query = db.Images
                .Where(i => i.Name == "Marvel")
                .Select(i => i.Source);
            imgProject.Source = new BitmapImage(
                new Uri(query.First().ToString(), UriKind.Relative));
            tblkDescription.Text = "";
            lblInstruction.Content = "Select a Project to View Description!";
        }

        //Exit
        private void btnProjectsExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion

        #region CustomList Page Interactions
        //Listbox is in focus event
        private void txbxListName_GotFocus(object sender, RoutedEventArgs e)
        {
            //If the Listbox text is on default, clear text
            //Otherwise leave the text that is there
            if(txbxListName.Text == "Enter the Name of your New List Here...")
                txbxListName.Text = "";
        }

        //Listbox lose focus event
        private void txbxListName_LostFocus(object sender, RoutedEventArgs e)
        {
            //If listbox text is clear, set text to default
            //Otherwise leave the text what it is
            if (txbxListName.Text == "")
                txbxListName.Text = "Enter the Name of your New List Here...";
        }

        //Save Custom List To File Feature
        #region CustomList_Save
        //Save Button Click Event
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //If the name listbox is not empty or at default, as a name is needed to save
            if(txbxListName.Text != "" && 
                txbxListName.Text != "Enter the Name of your New List Here...")
            {
                //Get the Info Enter by User
                GetCustomListInfo();
                //Save Custom List to File
                SaveToFile();
            }
            else//Otherwise display Error Message
                MessageBox.Show("To Save a List you must have a List Name!");
        }

        //Get the Custom List Info
        private void GetCustomListInfo()
        {
            //Check all comboBoxes in the comboBox List
            foreach (ComboBox comboBox in customListCBBoxes)
            {
                //Check if the selected item in the combo box is not null, and that the selected item is a project
                if (comboBox.SelectedItem != null && comboBox.SelectedItem is Project)
                    myCustomList.Add(comboBox.SelectedItem as Project);//Add the project that the combo box selected to our Custom List
            }

            //Set the list name to the name entered by the user
            listName = txbxListName.Text;
        }

        //Save CustomList to File using JSON
        private void SaveToFile()
        {
            //Check if there are projects entered into our Custom List, are there must be at least 1 entry to save
            if (myCustomList.Count > 0)
            {
                //Get the names from the projects in the Custom List
                List<string> names = new List<string>();
                foreach (Project item in myCustomList)
                    names.Add(item.Title);

                //Using JSON, Get all our data we want to save
                data = JsonConvert.SerializeObject(names, Formatting.Indented);

                //Using JSON, write all our data out to file, therefore saving it
                using (StreamWriter sw = new StreamWriter("../CustomLists/myCustomList.json"))
                {
                    sw.WriteLine("Lists are Ordered Starting at 1!");
                    sw.WriteLine(listName + " :");
                    sw.Write(data);
                    sw.Close();
                }

                //Display Success Message to User
                MessageBox.Show($"{listName} has been saved successfully!" +
                    $"\nYour List can be found in the bin folder of the Project under CustomLists.", "Success!");

                //Refresh Screen
                Clear();
            }
            else//Otherwise display Error Message
                MessageBox.Show("To Save a List you must Enter at least 1 Entry!");
        }
        #endregion

        //Refresh Custom List Screen
        #region CustomList_Clear
        //Clear Button Click Event
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();//Refresh
        }

        //Refresh Screen
        private void Clear()
        {
            //Reset all ComboBox Selections
            foreach (ComboBox comboBox in customListCBBoxes)
                comboBox.SelectedItem = null;

            myCustomList.Clear();
            txbxListName.Text = "Enter the Name of your New List Here...";
        }
        #endregion
        
        //Exit
        private void btnCustomListExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion
    }
}
