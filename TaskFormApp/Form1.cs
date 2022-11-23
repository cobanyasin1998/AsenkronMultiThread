using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskFormApp
{
    public partial class Form1 : Form
    {
        public int counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnReadFile_Click(object sender, EventArgs e)
        {
            string data = await ReadFileAsync2();
            richTextBox1.Text = data;
        }

        private void btnSayacArtar_Click(object sender, EventArgs e)
        {
            textBoxCounter.Text = counter++.ToString();
        }
        private string ReadFile()
        {
            string data = string.Empty;

            using (StreamReader s = new StreamReader("dosya.txt"))
            {
                //Thread.Sleep(5000);
                data = s.ReadToEnd();
            }
            return data;
        }

        private async Task<string> ReadFileAsync()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("dosya.txt"))
            {
                Task<string> myTask = s.ReadToEndAsync();

                await Task.Delay(5000);

                return data = await myTask;
            }
        }

        private Task<string> ReadFileAsync2()
        {
            StreamReader s = new StreamReader("dosya.txt");
            
                return s.ReadToEndAsync();
           
        }
    }
}
