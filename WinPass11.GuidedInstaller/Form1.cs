using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
            switch (progress)
            {
                case 0:
                    if (File.Exists("C:\\Users\\Default\\AppData\\Local\\Microsoft\\Windows\\WSUS\\setupconfig.ini")) // clean up old setup
                        File.Delete("C:\\Users\\Default\\AppData\\Local\\Microsoft\\Windows\\WSUS\\setupconfig.ini");
                    break;
                case 1:
                    Process _process;
                    _process = Process.Start("regedit.exe", "/s files\\regtweaks.reg"); // Location of the modified registry file
                    _process.WaitForExit();
                    Console.WriteLine("Exit");
                    break;
                case 3:
                    if (File.Exists("C:\\$WINDOWS.~BT\\Sources\\AppraiserRes.dll"))
                    { // clean up old setup
                        File.Delete("C:\\$WINDOWS.~BT\\Sources\\AppraiserRes.dll");
                    } else
                    {
                        MessageBox.Show("Hey! You pressed the button to early, it seems as if the installer hasn't downloaded the file we need to replace yet... Try again after reading the directions");
                    }
                    try
                    {
                        WebClient downloader = new WebClient();
                        downloader.DownloadFile("https://github.com/CodeProf14/Fix-TPM/blob/main/Fix%20TPM/appraiserres.dll?raw=true", "C:\\$WINDOWS.~BT\\Sources\\AppraiserRes.dll");
                    } catch
                    {
                        MessageBox.Show("Failed to download file :(");
                    }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            loadNext();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            progress++;
            loadNext();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (progress >= 0)
            {
                progress--;
            }
            if (progress == 0)
            {
                button4.Enabled = false;
            }
            loadNext();
        }
        public void loadNext()
        {
            switch (progress)
            {
                case 0:
                    richTextBox1.Text = "If you have previously installed Windows 11 or attempted to, you should probably click this button, if not, it doesn't hurt to press it regardless.";
                    label1.Text = "Clean Previous Installations >";
                    button1.Text = "Clean";
                    button1.Enabled = true;
                    break;
                case 1:
                    label1.Text = "Apply registry tweaks >";
                    button1.Text = "Apply";
                    button1.Enabled = true;
                    richTextBox1.Text = "This stage will apply tweaks in the registry, the tweaks applied here will bypass the TPM 2.0 and Secure Boot checks.";
                    //pictureBox1.ImageLocation = "http://i3.ytimg.com/vi/tJWv-IZlFqw/hqdefault.jpg";
                    break;
                case 2:
                    button1.Enabled = false;
                    label1.Text = "Refer to image and box for directions ^";
                    richTextBox1.Text = "Ah, now we are at the stage to update the system, this stage is simple,\n First go to Settings -> Update and security -> Windows Insider Program,\nand ensure you are in the Dev Channel.\nScroll up and click windows update in the left bar and click check now, if everything went well you should see downloading Windows 11 Insider Preview, but dont leave just yet, we still need to bypass the requirements!";
                    break;
                case 3:
                    button1.Enabled = true;
                    button1.Text = "Replace";
                    label1.Text = "Replace appraiserres.dll >";
                    richTextBox1.Text = "Oh, how much longer must the agony conti-\nI mean hi there! so next you have to wait for the install to fail, sounds cruel right? Once the window that says install failed due to TPM 2.0, close that out and press this button.";
                    button3.Text = "Next >";
                    break;
                case 4:
                    button1.Enabled = false;
                    label1.Text = "Refer to image and box for directions ^";
                    richTextBox1.Text = "This is the last step! All that needs to be done is for you to go back to the update screen and Click \"Check for Updates\" or \"Fix now\" or whatever there is in place of the button. After this is should work and it is safe to close this application!";
                    button3.Text = "Finish";
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
