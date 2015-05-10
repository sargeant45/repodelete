using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Octokit;

namespace repodelete
{
    public partial class re : Form
    {
        public re()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Are you damn sure?",
            "Confirmation 1",
            MessageBoxButtons.YesNo);
            if(result1 == DialogResult.Yes)
            {
                DialogResult result2 = MessageBox.Show("Did you click 'No' in the last dialog?",
                "Confirmation 2",
                MessageBoxButtons.YesNo);
                if (result2 == DialogResult.Yes)
                {
                    var gh_client = new GitHubClient(new ProductHeaderValue("repodelete"));
                    var auth = new Credentials(textBox2.Text);
                    gh_client.Credentials = auth;
                    var repo = gh_client.Repository;
                    repo.Delete(textBox1.Text, textBox3.Text);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/settings/tokens/new");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/sargeant45/repodelete");
        }
    }
}
