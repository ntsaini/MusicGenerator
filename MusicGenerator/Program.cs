using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //string noteName = "";
            //int noteNumber = 0;
            int instrumentNumber = 1;
            int sequenceLength = 7;
            int channel = 0;
            int volume = 50;
            var notesPerChannelList = new List<NotesPerChannel>();
            var nPlayer = new NotePlayer();

            DisplayAllInstruments();

            do
            {
                do
                {
                    channel = channel + 1;                    
                    instrumentNumber = GetInstrumentNumberInput();
                    sequenceLength = GetSequenceLengthInput();
                    volume = GetVolumeInput();
                    var noteSequence = GenerateRandomNoteSequence(sequenceLength);
                    notesPerChannelList.Add(new NotesPerChannel(noteSequence, channel, instrumentNumber, volume));

                    Console.WriteLine("Add another instrument? (y/n) :");                   
                } while (Console.ReadLine().ToLower() == "y");
                
                Console.WriteLine("Playing random sequence. Press any key to stop.");
                //nPlayer.PlayNotes(noteSequence, instrumentNumber, 1, 50, true);
                nPlayer.PlayNotesOnMultipleChannels(notesPerChannelList);
                Console.WriteLine("Continue? (y/n) :");
                         
            } while (Console.ReadLine().ToLower() == "y");
        }

        static void DisplayAllInstruments()
        {
            var instruments = Helper.GetAllInstruments();
            foreach(var instrument in instruments)
            {
                Console.WriteLine(instrument.Number.ToString() + " : " + instrument.Name);
            }
        }

        static void DisplayNoteSequences()
        {
            string sequence = "a3,c4,e4,a4,b4,e4,c4,b4";
            Console.WriteLine(sequence);
        }

        static IEnumerable<Note> GenerateRandomNoteSequence(int sequenceLength)
        {
            var notes = new List<Note>();
            var inputNoteSet = new List<string>() { "a4", "b4", "c4", "d4", "e4", "f4", "g4" };
            var inputDurationSet = new List<int>() { 250, 500, 1000 };

            var outputNoteSet = RandomSequenceGenerator.GetRandomSequence(inputNoteSet, sequenceLength);
            var outputDurationSet = RandomSequenceGenerator.GetRandomSequence(inputDurationSet, sequenceLength);

            for (int i=0; i< sequenceLength; i++)
            {
                notes.Add(new Note(outputNoteSet[i], outputDurationSet[i]));
            }

            return notes;
        }

        static int GetInstrumentNumberInput()
        {
            bool inputComplete = false;
            int instrumentNumber = 1;
            while (!inputComplete)
            {
                Console.WriteLine("Choose the instrument");
                string sInstrumentNumber = Console.ReadLine();

                try
                {
                    instrumentNumber = Convert.ToInt32(sInstrumentNumber);
                    if (instrumentNumber < 0 || instrumentNumber > 128)
                        throw new ArgumentOutOfRangeException("The instrument number is not in range");
                    inputComplete = true;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            return instrumentNumber;
        }

        static int GetSequenceLengthInput()
        {
            bool inputComplete = false;
            int sequenceLength = 1;
            while (!inputComplete)
            {
                Console.WriteLine("Enter sequence length");
                string sSequenceLength = Console.ReadLine();

                try
                {
                    sequenceLength = Convert.ToInt32(sSequenceLength);
                    if (sequenceLength < 0)
                        throw new ArgumentOutOfRangeException("The sequence length cannot be less than zero");
                    inputComplete = true;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            return sequenceLength;
        }

        static int GetVolumeInput()
        {
            bool inputComplete = false;
            int volume = 1;
            while (!inputComplete)
            {
                Console.WriteLine("Enter volume");
                string sVolume = Console.ReadLine();

                try
                {
                    volume = Convert.ToInt32(sVolume);
                    if (volume < 0 || volume > 100)
                        throw new ArgumentOutOfRangeException("The volume should be between 0 and 100");
                    inputComplete = true;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            return volume;
        }

        //string sequence = "a3,c4,e4,a4,b4,e4,c4,b4";
        //var sNoteSequence = new List<Note>();
        //foreach (var nName in sequence.Split(','))
        //{
        //    sNoteSequence.Add(new Note(nName,500));
        //}
        //while (true)
        //{
        //    Console.Write("Enter a note name (E.g. C4# or D4b - Note|Octave|Sharp/Flat) : ");
        //    noteName= Console.ReadLine();
        //    noteNumber = Helper.GetNoteNumber(noteName);
        //    if (noteNumber == 0)
        //        Console.WriteLine("Invalid Note");
        //    else
        //    {
        //        Console.WriteLine("Note Number : " + noteNumber.ToString());
        //        var note = new Note(noteName);
        //        List<Note> noteSequence = new List<Note>();
        //        noteSequence.Add(note);                    
        //        var notePlayer = new NotePlayer();
        //        notePlayer.PlayNotes(noteSequence, instrumentNumber);
        //    }                    
        //}

    }
}
