using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicGenerator
{
    public class NotesPerChannel
    {        
        public int ChannelNumber { get; private set; }
        public int Volume { get; private set; }
        public int InstrumentNumber { get; private set; }
        public IEnumerable<Note> NoteSequence;
        public NotesPerChannel(IEnumerable<Note> noteSequence)
        {
            NoteSequence = noteSequence;
            ChannelNumber = 1;
            Volume = 50;
            InstrumentNumber = 1;
        }

        public NotesPerChannel(IEnumerable<Note> noteSequence, int channelNumber, int instrumentNumber, int volume) : this(noteSequence)
        {
            ChannelNumber = channelNumber;
            InstrumentNumber = instrumentNumber;
            Volume = volume;
        }

    }
}
