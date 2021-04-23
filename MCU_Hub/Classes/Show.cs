using System;

namespace MCU_Hub.Classes
{
    public class Show : Project//Inheriting from Project Class
    {
        //Setting Properties
        #region Properties
        public string Creator { get; set; }
        public int NumberOfEpisodes { get; set; }
        #endregion

        //Setting Constuctors
        #region Constructors
        public Show(string title, DateTime releaseDate, int duration, int numOfEpisodes, 
            string rating, string creator, string cast, decimal sales, PhaseType phase) :
            base(title, releaseDate, duration, rating, cast, sales, phase)
        {
            //Setting Values
            Creator = creator;
            NumberOfEpisodes = numOfEpisodes;
            Type = "Show";
        }

        public Show(string title, DateTime releaseDate, int duration) :
            this(title, releaseDate, duration, 0, "0", "Unknown", "Unknown", 0, PhaseType.Zero) { }

        public Show() : this("Unknown", new DateTime(2000, 1, 1), 0) { }
        #endregion
    }
}
