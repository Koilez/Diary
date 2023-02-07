using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class FormMain : Form
    {
        readonly private FormWindow form;
        List<DiaryEntry> entiers;
        public FormMain(FormWindow owner)
        {
            form = owner;
            InitializeComponent();
            addButtons();      
        }

        private void addButtons()
        {
            entiers = form.diary.GetEntries();
            for (int i = 0; i < entiers.Count; i++)
            {
                comboBoxzSearch.Items.Add(entiers[i].header);
                Button newButton = new Button();
                newButton.Text = entiers[i].header;
                newButton.Size = new Size(this.Width - 125, 30);
                newButton.TabIndex = i;
                newButton.Click += new EventHandler(newButton_Click);
                flowLayoutPanel1.Controls.Add(newButton);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            form.EnableFormWrite(-1);
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int index = clickedButton.TabIndex;
            form.EnableFormWrite(index);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = 0;
            for(int i = 0; i < entiers.Count; i++)
            {
                if(comboBoxzSearch.Text == entiers[i].header)
                {
                    form.EnableFormWrite(index);
                    break;
                }
                index++;
            }
        }
    }
}
