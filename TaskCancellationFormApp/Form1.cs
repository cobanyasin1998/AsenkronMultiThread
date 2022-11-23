using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskCancellationFormApp
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cT = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                Task<HttpResponseMessage> myTask;
                myTask = new HttpClient().GetAsync("https://localhost:44341/api/Home", cT.Token);
                await myTask;
                var content = myTask.Result.Content.ReadAsStringAsync();

                richTextBox1.Text = content.Result;
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnDurdur_Click(object sender, EventArgs e)
        {
            cT.Cancel();
        }
    }
}
