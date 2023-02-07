using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Project1
{
    public partial class FormWindow : Form
    {
        private Form formChild;
        private string key = "<RSAKeyValue><Modulus>vz9MkMIjrKUm+rJi7j7iv5RvLljf+svVXvlcCtYDCjtJ2rMesjaWh8lUx0wcXcjSau7cVr2B4qdoLjPJCSQctrvbxr2B13bk8MLY80eP2PFjO5baQyYqrCYVUcUPWc1/GpE4IHz+Vvp8TAPQN0VVu2Rda/wlOBx0p9gHcTNcvvE=</Modulus><Exponent>AQAB</Exponent><P>x08GVT9OkiNiEn9uWrFwXtoJlCcDOU+0mxUi4c1QECuDNtIhE4FWS4MckxKCJfE8FpTwsAEkTGrz8jJmOZGQkw==</P><Q>9aVEzuzEoQ5So+ojMcCmy/oHcd//3bSvkkOixiATcDi7pJZR3DI92GcWvMiviXGf9ruWu8KQ/oNchoAjmdvY6w==</Q><DP>shJ+/AdV8ee/JfvI4ysJ1RVF3aKFlN0L5kuaINjJocjesUpI1x6FtW3tR9IPikrgfuSPrxE2FzivwEMbZnASFQ==</DP><DQ>D55lhJ6rVe46NO/jMvuj315TcNskQq2FaFBiniRV+BGzZKCmLdEH+6V6XaCJAL03xZFh4Sha3cPucyLcoKDI5w==</DQ><InverseQ>Wuj88z643ga3eKQGqcTjC5fyx0FwiwNOOjENhpN4QOZ/NtxUa2wdAow20Ycm4m0y3q4O2CNG1AK4sdIKSJDx/A==</InverseQ><D>vnfWU11mli0tMwSyjsDGpzK3wBr3hxm2eY4zYv9dq7T8ivlVmvvO05FqA8sDfUvidGlLvH+keg1sLoeYsqfqh0BPXsOJrZwXR7jCvTzUGAce0q/GFMiBwbAyaAEjr99+3k6mdRyA1qdIfZ3MazG530EdMA2zb8wo1Z+2OXFMNXk=</D></RSAKeyValue>";
        public Diary diary = new Diary();

        public FormWindow()
        {
            OpenApplicationData();
            InitializeComponent();
            EnableFormMain();
        }

        public void addDate(string header, string date, string text)
        {
            DiaryEntry entery = new DiaryEntry(header,date,text);
            diary.AddEntry(entery);
        }

        public void EnableFormWrite(int index)
        {
            
            if(formChild != null)
            {
                formChild.Close();
            }
            formChild = new FormWrite(this, index);
            formChild.TopLevel = false;
            formChild.FormBorderStyle = FormBorderStyle.None;
            this.panelWindow.Controls.Add(formChild);
            formChild.Dock = DockStyle.Fill;
            formChild.Show();
        }

        public void EnableFormMain()
        {
            if (formChild != null)
            {
                formChild.Close();
            }
            formChild = new FormMain(this);
            formChild.TopLevel = false;
            formChild.FormBorderStyle = FormBorderStyle.None;
            this.panelWindow.Controls.Add(formChild);
            formChild.Dock = DockStyle.Fill;
            formChild.Show();
        }

        private void FormWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(@"F:\Visual Studio\OP\Project1\Data\Data.txt",false))
            {
                for (int i = 0; i < diary.GetCount(); i++)
                {
                    var result = diary.GetValues(i);
                    sw.WriteLine(Encrypt(result.header));
                    sw.WriteLine(Encrypt(result.data));
                    sw.WriteLine(Encrypt(result.text));
                }
            }
        }

        private void OpenApplicationData()
        {

            string[] lines = File.ReadAllLines(@"F:\Visual Studio\OP\Project1\Data\Data.txt");
            for (int i = 0; i < lines.Length; i+=3)
            {
                    addDate(Decrypt(lines[i]), Decrypt(lines[i + 1]), Decrypt(lines[i + 2]));
            }
        }

        private string Encrypt(string text)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(key);
                return Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(text), true));
            }
        }

        private string Decrypt(string text)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(key);
                return Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(text), true));
            }

        }

       
    }
}
