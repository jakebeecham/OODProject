using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCU_Hub
{
    public class Film : Project
    {
        #region Properties

        public string Director { get; set; }

        #endregion

        #region Constructors

        public Film(string title, DateTime releaseDate, int duration, string rating, string director, string cast, PhaseType phase) :
            base(title, releaseDate, duration, rating, cast, phase)
        {
            Director = director;
        }

        public Film(string title, DateTime releaseDate, int duration) :
            this(title, releaseDate, duration, "0", "Unknown", "Unknown", PhaseType.Zero) { }

        public Film() : this("Unknown", new DateTime(2000, 1, 1), 0) { }

        #endregion

        #region Methods

        public override string ToString()
        {
            return base.ToString() + " | Film";
        }

        #endregion
    }
}
