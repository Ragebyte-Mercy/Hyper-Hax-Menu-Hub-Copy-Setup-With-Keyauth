using KeyAuth;
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

namespace Hyper_Hub
{
    public partial class LoginForm : Form
    {

        WebClient web1 = new WebClient();
        string filePath = @"C:\Users\Default\Desktop\login.txt";


        public static api KeyAuthApp = new api(
            name: "Test",
            ownerid: "jR6kdDI71J",
            secret: "9fbde9e884d856e10656ede3f96541921e778396c8f65387f61b769193c7c182",
            version: "1.0"
        );

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            KeyAuthApp.login(Username.Text, Password.Text);

            if (KeyAuthApp.response.success)
            {
                string username = Username.Text;
                string password = Password.Text;

                if (!File.Exists(filePath))
                {
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        sw.WriteLine($"{username}:{password}");
                    }
                }
                else 
                {

                }

                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
        }

        private void AppExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Spoofing with our tool\n\n" +
            "Note: Your spoofer must be soft and resets when you restart your pc otherwise this doesnt work\n\n" +
            "1.Restart PC to get original hwid.\n" +
            "2.Launch Loader. (sticks to your original hwid)\n" +
            "3.Launch Tool(waiting for game)(sticks to your original HWID)\n" +
            "4.)Spoof(hwid is now scrambled.)\n" +
            "5.Open Game.\n\n" +
            "IMPORTANT DISCLAIMER : if you close the game or the tool you will need to restart your pc back to your original hwid so you can launch our loader and tool which you originally opened with.",
            "The correct way to spoof!",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://drive.google.com/file/d/1xFFyRDcaYBv867N4raZYZjywdZ-5xPsS/view");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string discord = web1.DownloadString("https://pastebin.com/raw/xxxxxxxx"); // Put Your Own Pastebin With Discord Link Or Your Website Discord Redirect.
            Process.Start(discord);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Want To Rebrand This To Your Colors + Logos Use Download Links Below For PSD Files.

            // Login Screen : https://cdn.discordapp.com/attachments/995890179493605376/1099588466481840189/Login.psd
            // Menu Selection Screen : https://cdn.discordapp.com/attachments/995890179493605376/1099588466838360084/Select_Menu.psd


            KeyAuthApp.init();

            if (KeyAuthApp.response.message == "invalidver")
            {
                if (!string.IsNullOrEmpty(KeyAuthApp.app_data.downloadLink))
                {
                    DialogResult dialogResult = MessageBox.Show("Yes to open file in browser\nNo to download file automatically", "Auto update", MessageBoxButtons.YesNo);
                    switch (dialogResult)
                    {
                        case DialogResult.Yes:
                            Process.Start(KeyAuthApp.app_data.downloadLink);
                            Environment.Exit(0);
                            break;
                        case DialogResult.No:
                            WebClient webClient = new WebClient();
                            string destFile = Application.ExecutablePath;

                            string rand = random_string();

                            destFile = destFile.Replace(".exe", $"-{rand}.exe");
                            webClient.DownloadFile(KeyAuthApp.app_data.downloadLink, destFile);

                            Process.Start(destFile);
                            Process.Start(new ProcessStartInfo()
                            {
                                Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
                                WindowStyle = ProcessWindowStyle.Hidden,
                                CreateNoWindow = true,
                                FileName = "cmd.exe"
                            });
                            Environment.Exit(0);

                            break;
                        default:
                            MessageBox.Show("Invalid option");
                            Environment.Exit(0);
                            break;
                    }
                }
                MessageBox.Show("Version of this program does not match the one online. Furthermore, the download link online isn't set. You will need to manually obtain the download link from the developer");
                Environment.Exit(0);
            }

            if (!KeyAuthApp.response.success)
            {
                MessageBox.Show(KeyAuthApp.response.message);
                Environment.Exit(0);
            }
            if(KeyAuthApp.checkblack())
            {
                 MessageBox.Show("user is blacklisted");
            }
            else
            {
                 MessageBox.Show("user is not blacklisted");
            }

            /* check if subscription exists
            if(SubExist("default", 10))
            {
                 MessageBox.Show("default subscription exists");
            }
            */
            KeyAuthApp.check();


            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read the login information from the file
                string[] loginInfo = File.ReadAllText(filePath).Split(':');

                // Set the username and password text boxes to the values from the file
                Username.Text = loginInfo[0];
                Password.Text = loginInfo[1];
            }
        }

        static string random_string()
        {
            string str = null;

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                str += Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))).ToString();
            }
            return str;

        }
    }
}
