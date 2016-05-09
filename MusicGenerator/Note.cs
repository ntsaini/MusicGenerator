using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicGenerator
{
    public class Note
    {        
        public string Name { get; private set; }
        public int Number { get; private set; }
        public int DurationInMs { get; set; }

        public Note(string noteName)
        {
            Name = noteName;
            Number = Helper.GetNoteNumber(noteName);
            DurationInMs = 1000;
        }

        public Note(string noteName, int durationInMs) : this(noteName)
        {   
            DurationInMs = durationInMs;
        }

    }
}
