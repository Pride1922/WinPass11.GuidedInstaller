using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winPass11_guided_install
{
    public partial class Form1 : Form
    {
        int progress = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            progress++;
            loadNext();
        }
        public void loadNext()
        { 
            switch (progress)
            {
                case 1:
                    label1.Text = "Apply registry tweaks";
                    button1.Text = "Apply";
                    richTextBox1.Text = "This stage will apply tweaks in the registry, the tweaks applied here will help you bypass the TPM checks";
                    break;
                case 2:
                    button1.Enabled = false;
                    label1.Text = "Refer to image and box for directions";
                    richTextBox1.Text = "Ah, now we are at the stage to update the system, this stage is simple,\n First go to Settings -> Update and security -> Windows insider program\nAnd ensure you are in the Dev Channel\nThen scroll up and click windows update in the left bar and click check now, if everything went well you should see downloading windows 11 insider preview, but dont leave just yet, we still need to bypass the requirements!";
                    richTextBox1.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
                    break;
                case 3:
                    button1.Enabled = true;
                    button1.Text = "Replace";
                    label1.Text = "Replace appraiserres.dll";
                    richTextBox1.Text = "How much longer must the agony go o-\nI mean hi there! so now you have to wait for the install to fail, sounds cruel right? well once the window that says install failed due to tpm 2.0 comes up, close that out and press this button";
                    button3.Text = "Next -->";
                    break;
                case 4:
                    button1.Enabled = false;
                    label1.Text = "Refer to image and box for directions";
                    richTextBox1.Text = "This is the last step! All that needs to be done is for you to go back to the update screen and Click \"Check for Updates\" or \"Fix now\" or whatever there is in place of that button now. After this is should work and it is safe to close this application";
                    button3.Text = "Close app";
                    break;
                case 5:
                    Application.Exit();
                    break;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
