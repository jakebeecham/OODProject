using System;

namespace MCU_Hub.Classes
{
    public class Film : Project//Inheriting from Project Class
    {
        //Setting Properties
        #region Properties
        public string Director { get; set; }
        #endregion

        //Setting Constuctors
        #region Constructors
        public Film(string title, DateTime releaseDate, int duration, string rating, 
            string director, string cast, decimal sales, PhaseType phase) :
            base(title, releaseDate, duration, rating, cast, sales, phase)
        {
            //Setting Values
            Director = director;
        }

        public Film(string title, DateTime releaseDate, int duration) :
            this(title, releaseDate, duration, "0", "Unknown", "Unknown", 0, PhaseType.Zero) { }

        public Film() : this("Unknown", new DateTime(2000, 1, 1), 0) { }
        #endregion

        //Setting Methods
        #region Methods
        //Overriding ToString
        public override string ToString()
        {
            return base.ToString() + " | Film";
        }
        #endregion
    }
}
