using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class FormWrite : Form
    {
        readonly FormWindow form;
        List<DiaryEntry> entiers;
        bool saveOrChange = true;
        int indexData = 0;
        public FormWrite(FormWindow owner, int index)
        {
            indexData = index;
            form = owner;
            InitializeComponent();
            enterData(index);
            if (!saveOrChange)
            {
                buttonRemove.Enabled = true;
            }
        }

        private void enterData(int index)
        {
            if (form.diary.GetCount() != 0)
            {
                entiers = form.diary.GetEntries();
            }

            if (index >= 0)
            {
                try
                {
                    textBoxHeader.Text = entiers[index].header;
                    textBox.Text = entiers[index].text;
                    dateTimePicker.Text = entiers[index].date;
                    saveOrChange = false;
                }
                catch { }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            saveOrChange = true;
            form.EnableFormMain();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveOrChange)
            {
                form.addDate(textBoxHeader.Text, dateTimePicker.Value.ToShortDateString(), textBox.Text);
            }
            else
            {
                form.diary.ChangeData(indexData, dateTimePicker.Value.ToShortDateString(), textBoxHeader.Text, textBox.Text);
            }
            saveOrChange = true;
            form.EnableFormMain();
        }

        private void buttonPaint_Click(object sender, EventArgs e)
        {
           
            form.diary.RemoveEntry(indexData);
            saveOrChange = true;
            form.EnableFormMain();
        }

       
    }
}
