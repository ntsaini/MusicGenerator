using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Midi;
using System.Threading;

namespace MusicGenerator
{
    public class NotePlayer
    {
        private MidiOut midiOut;
        public NotePlayer()
        {
            midiOut = new MidiOut(0);
        } 

        public void PlayNotes(IEnumerable<Note> noteSequence, int instrumentNumber, int channelNumber, int volume,  bool playUntilKeyHit = false)
        {   
            midiOut.Send(MidiMessage.ChangePatch(instrumentNumber, channelNumber).RawData);
            bool breakWhileLoop = false;
            do
            {   
                foreach (var note in noteSequence)
                {
                    midiOut.Send(MidiMessage.StartNote(note.Number, volume, channelNumber).RawData);
                    Thread.Sleep(note.DurationInMs);
                    midiOut.Send(MidiMessage.StopNote(note.Number, volume, channelNumber).RawData);
                    if (Console.KeyAvailable)
                    {
                        breakWhileLoop = true;                        
                        break;
                    }
                }
            } while (playUntilKeyHit && !(breakWhileLoop));
            
            return;
        }

        public void PlayNotesOnMultipleChannels(IEnumerable<NotesPerChannel> notesPerChannelList)
        {
            var allTasks = new List<Task>();
            foreach (var notesPerChannel in notesPerChannelList)
            {
                var channelTask = new Task(() => PlayNotes(notesPerChannel.NoteSequence, 
                    notesPerChannel.InstrumentNumber,
                    notesPerChannel.ChannelNumber,
                    notesPerChannel.Volume,
                    true));
                channelTask.Start();
                allTasks.Add(channelTask);
            }
            Task.WaitAll(allTasks.ToArray());
            Console.ReadKey();
            return;
        }
        
    }
}
