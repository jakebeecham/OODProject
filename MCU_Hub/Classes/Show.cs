using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCU_Hub.Classes
{
    public class Show : Project
    {
        #region Properties
        public string Creator { get; set; }
        public int NumberOfEpisodes { get; set; }
        #endregion

        #region Constructors
        public Show(string title, DateTime releaseDate, int duration, int numOfEpisodes, 
            string rating, string creator, string cast, PhaseType phase) :
            base(title, releaseDate, duration, rating, cast, phase)
        {
            Creator = creator;
            NumberOfEpisodes = numOfEpisodes;
        }

        public Show(string title, DateTime releaseDate, int duration) :
            this(title, releaseDate, duration, 0, "0", "Unknown", "Unknown", PhaseType.Zero) { }

        public Show() : this("Unknown", new DateTime(2000, 1, 1), 0) { }
        #endregion

        #region Methods
        public override string ToString()
        {
            return base.ToString() + " | Show";
        }
        #endregion
    }
}
