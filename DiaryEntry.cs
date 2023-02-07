using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class DiaryEntry
    {
        public DiaryEntry() { }

        public string header { get; set; }
        public string date { get; set; }
        public string text { get; set; }

        public DiaryEntry(string header, string date, string text)
        {
            this.header = header;
            this.date = date;
            this.text = text;
        }
    }
}

