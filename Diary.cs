using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Diary
    {

        private List<DiaryEntry> entries = new List<DiaryEntry>();


        public void AddEntry(DiaryEntry entry)
        {
            entries.Add(entry);
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public int GetCount()
        {
           return entries.Count;   
        }

        public List<DiaryEntry> GetEntries()
        {
            return entries;
        }

        public (string text, string header, string data) GetValues(int index)
        {
            return (entries[index].text, entries[index].header, entries[index].date);
        }

        public void ChangeData(int index, string data, string header, string text)
        {
            entries[index].date = data;
            entries[index].header = header;
            entries[index].text = text;
        }

    }
}
