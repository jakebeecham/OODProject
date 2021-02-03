using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCU_Hub
{
    public abstract class Project : IComparable
    {
        public enum PhaseType { Zero, One, Two, Three, Four }
        
        #region Properties

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public byte Duration { get; set; }

        public string Rating { get; set; }

        public string Cast { get; set; }

        public PhaseType Phase { get; set; }

        #endregion

        #region Constructors

        public Project(string title, DateTime releaseDate, byte duration, string rating, string cast, PhaseType phase)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Duration = duration;
            Rating = rating;
            Cast = cast;
            Phase = phase;
        }

        public Project(string title, DateTime releaseDate, byte duration) : 
            this(title, releaseDate, duration, "0", "Unknown", PhaseType.Zero) { }

        public Project() : this("Unknown", new DateTime(2000, 1, 1), 0) { }

        #endregion

        #region Methods

        public override string ToString()
        {
            return Title;
        }

        public int CompareTo(object obj)
        {
            Project otherProject = obj as Project;

            return this.ReleaseDate.CompareTo(otherProject.ReleaseDate);
        }

        #endregion
    }
}
