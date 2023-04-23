using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hyper_Hub;
using KeyAuth;

namespace Hyper_Hub
{
    public partial class MainForm : Form
    {

        Methods m = new Methods();

        public MainForm()
        {
            InitializeComponent();
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Check if the user has a subscription called "Master Key"
            bool hasMasterKey = SubExist("Master Key", 10);

            // Clear the list box
            subscriptionListBox.Items.Clear();

            // Add the appropriate items to the list box based on the user's subscription Modify This To Your Subscriptions
            if (hasMasterKey)
            {
                subscriptionListBox.Items.AddRange(new object[] { "7D2D Creative Cheat", "WZ|MW|VG Unlock All Camo Swapper", "Coldwar Loadout Editor", "DA|DMU|XP Cycle", "Pavlov ESP+", "MW2|WZ 2.0|DMZ OG Mods" });
            }

            else
            {
                // The user doesn't have a valid subscription
                MessageBox.Show("You do not have a valid subscription.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Close the form
            }
        }

        public static bool SubExist(string name, int len)
        {
            for (var i = 0; i < len; i++)
            {
                if (LoginForm.KeyAuthApp.user_data.subscriptions[i].subscription == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void Spoof_Click(object sender, EventArgs e)
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

        private void AppExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Redeem_Click(object sender, EventArgs e)
        {
            LoginForm.KeyAuthApp.upgrade(LoginForm.KeyAuthApp.user_data.username, UpgradeKey.Text); // success is set to false so people can't press upgrade then press login and skip logging in. it doesn't matter, since you shouldn't take any action on succesfull upgrade anyways. the only thing that needs to be done is the user needs to see the message from upgrade function
            Console.WriteLine("Status: " + LoginForm.KeyAuthApp.response.message); // don't login, because they haven't authenticated. this is just to extend expiry of user with new key.
        }

        private void LoadSelectedOption_Click(object sender, EventArgs e)
        {
            string selectedText = subscriptionListBox.SelectedItem.ToString();

            if (selectedText == null)
            {

            }
            else
            {
                if (selectedText == "7D2D Creative Cheat")
                {
                    Methods.SevenDaysTwoDie();
                }

                if (selectedText == "WZ|MW|VG Unlock All Camo Swapper")
                {
                    Methods.WZVGUnlockAllCamoSwapper();
                }

                if (selectedText == "Coldwar Loadout Editor")
                {
                    Methods.CWLoadoutEditor();
                }

                if (selectedText == "DA|DMU|XP Cycle")
                {
                    Methods.CWZmTrainer();
                }

                if (selectedText == "Pavlov ESP+")
                {
                    Methods.Pavlov();
                }

                if (selectedText == "MW2|WZ 2.0|DMZ OG Mods")
                {
                    Methods.MW2OG();
                }
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LoginForm Login = new LoginForm();
            Login.Show();
            this.Hide();
        }
    }
}
