using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;

namespace MusicGenerator
{
    public static class Helper
    {
        
        static IEnumerable<NoteInfo> notes;
        static IEnumerable<InstrumentInfo> instruments;

        public static int GetNoteNumber(string noteName)
        {
            if (notes == null)
                InitNoteInfo();

            var noteInfo = notes.Where(x => x.Name.Equals(noteName,StringComparison.CurrentCultureIgnoreCase)
              || x.AlternateName.Equals(noteName,StringComparison.CurrentCultureIgnoreCase))
              .FirstOrDefault();

            return (noteInfo != null) ? noteInfo.Number : 0;            
        }

        public static IEnumerable<InstrumentInfo> GetAllInstruments()
        {
            if (instruments == null)
                InitInstrumentInfo();

            return instruments;
        }
               
        static void InitInstrumentInfo()
        {
            var reader = new StreamReader(Path.GetFullPath(@".\Data\InstrumentLookup.csv"));
            var csv = new CsvReader(reader);
            instruments = csv.GetRecords<InstrumentInfo>().ToList();
        }

        static void InitNoteInfo()
        {
            var reader = new StreamReader(Path.GetFullPath(@".\Data\NoteLookup.csv"));
            var csv = new CsvReader(reader);            
            notes = csv.GetRecords<NoteInfo>().ToList();
        }


    }

    public class NoteInfo
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string AlternateName { get; set; }
        public double Frequency { get; set; }
    }

    public class InstrumentInfo
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }
}
