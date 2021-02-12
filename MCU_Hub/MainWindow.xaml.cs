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
            Film film1 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "Robert Downey Jr., Gwyneth Paltrow", Project.PhaseType.One);
            //Film film2 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film3 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film4 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film5 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film6 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film7 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film8 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film9 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film10 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film11 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film12 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film13 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film14 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film15 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film16 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film17 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film18 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film19 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film20 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film21 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);
            //Film film22 = new Film("Iron Man", new DateTime(2008, 5, 2), 127, "12+", "Jon Favreau", "", Project.PhaseType.One);

        }

        #endregion
    }
}
