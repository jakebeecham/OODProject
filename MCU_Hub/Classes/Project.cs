using System;

namespace MCU_Hub.Classes
{
    public abstract class Project : IComparable//Using IComparable Interface for Sorting
    {
        public enum PhaseType { Zero, One, Two, Three, Four }
        
        //Setting Properties
        #region Properties
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public string Rating { get; set; }
        public string Cast { get; set; }
        public decimal Sales { get; set; }
        public string ProjectImage { get; set; }
        public string Type { get; set; }
        public PhaseType Phase { get; set; }
        #endregion

        //Setting Constuctors
        #region Constructors
        public Project(string title, DateTime releaseDate, int duration, string rating, string cast, decimal sales, PhaseType phase)
        {
            //Setting Values
            Title = title;
            ReleaseDate = releaseDate;
            Duration = duration;
            Rating = rating;
            Cast = cast;
            Sales = sales;
            Phase = phase;
        }

        public Project(string title, DateTime releaseDate, int duration) : 
            this(title, releaseDate, duration, "0", "Unknown", 0, PhaseType.Zero) { }

        public Project() : this("Unknown", new DateTime(2000, 1, 1), 0) { }
        #endregion

        //Setting Methods
        #region Methods
        //Overriding ToString
        public override string ToString()
        {
            return Title + " | Phase " + Phase + " | " + Type;
        }

        //Using CompareTo to Sort in order of Release, Implementing Interface
        public int CompareTo(object obj)
        {
            Project otherProject = obj as Project;

            return this.ReleaseDate.CompareTo(otherProject.ReleaseDate);
        }
        #endregion
    }
}
