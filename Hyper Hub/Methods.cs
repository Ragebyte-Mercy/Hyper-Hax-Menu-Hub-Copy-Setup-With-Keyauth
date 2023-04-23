using KeyAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hyper_Hub
{
    public class Methods
    {
        public static string filePath = @"C:\Users\Default\Desktop\login.txt";

        public static void SevenDaysTwoDie()
        {
            if (File.Exists(filePath))
            {
                string[] loginInfo = File.ReadAllText(filePath).Split(':');

                string Username = loginInfo[0];
                string Password = loginInfo[1];

                LoginForm.KeyAuthApp.login(Username, Password);

                if (LoginForm.KeyAuthApp.response.success)
                {
                    WebClient Web1 = new WebClient();

                    Console.WriteLine("Authentication Success");
                    Web1.DownloadFile("", @"C:\");
                }
                else
                {
                    if (!LoginForm.KeyAuthApp.response.success)
                    {
                        Console.WriteLine("Authentication Failed");
                    }
                }
            }
        }

        public static void WZVGUnlockAllCamoSwapper()
        {
            if (File.Exists(filePath))
            {
                string[] loginInfo = File.ReadAllText(filePath).Split(':');

                string Username = loginInfo[0];
                string Password = loginInfo[1];

                LoginForm.KeyAuthApp.login(Username, Password);

                if (LoginForm.KeyAuthApp.response.success)
                {
                    WebClient Web1 = new WebClient();

                    Console.WriteLine("Authentication Success");
                    Web1.DownloadFile("", @"C:\");
                }
                else
                {
                    if (!LoginForm.KeyAuthApp.response.success)
                    {
                        Console.WriteLine("Authentication Failed");
                    }
                }
            }
        }

        public static void CWLoadoutEditor()
        {
            if (File.Exists(filePath))
            {
                string[] loginInfo = File.ReadAllText(filePath).Split(':');

                string Username = loginInfo[0];
                string Password = loginInfo[1];

                LoginForm.KeyAuthApp.login(Username, Password);

                if (LoginForm.KeyAuthApp.response.success)
                {
                    WebClient Web1 = new WebClient();

                    Console.WriteLine("Authentication Success");
                    Web1.DownloadFile("", @"C:\");
                }
                else
                {
                    if (!LoginForm.KeyAuthApp.response.success)
                    {
                        Console.WriteLine("Authentication Failed");
                    }
                }
            }
        }

        public static void CWZmTrainer()
        {
            if (File.Exists(filePath))
            {
                string[] loginInfo = File.ReadAllText(filePath).Split(':');

                string Username = loginInfo[0];
                string Password = loginInfo[1];

                LoginForm.KeyAuthApp.login(Username, Password);

                if (LoginForm.KeyAuthApp.response.success)
                {
                    WebClient Web1 = new WebClient();

                    Console.WriteLine("Authentication Success");
                    Web1.DownloadFile("", @"C:\");
                }
                else
                {
                    if (!LoginForm.KeyAuthApp.response.success)
                    {
                        Console.WriteLine("Authentication Failed");
                    }
                }
            }
        }

        public static void Pavlov()
        {
            if (File.Exists(filePath))
            {
                string[] loginInfo = File.ReadAllText(filePath).Split(':');

                string Username = loginInfo[0];
                string Password = loginInfo[1];

                LoginForm.KeyAuthApp.login(Username, Password);

                if (LoginForm.KeyAuthApp.response.success)
                {
                    WebClient Web1 = new WebClient();

                    Console.WriteLine("Authentication Success");
                    Web1.DownloadFile("", @"C:\");
                }
                else
                {
                    if (!LoginForm.KeyAuthApp.response.success)
                    {
                        Console.WriteLine("Authentication Failed");
                    }
                }
            }
        }

        public static void MW2OG()
        {
            if (File.Exists(filePath))
            {
                string[] loginInfo = File.ReadAllText(filePath).Split(':');

                string Username = loginInfo[0];
                string Password = loginInfo[1];

                LoginForm.KeyAuthApp.login(Username, Password);

                if (LoginForm.KeyAuthApp.response.success)
                {
                    WebClient Web1 = new WebClient();

                    Console.WriteLine("Authentication Success");
                    Web1.DownloadFile("", @"C:\");
                }
                else
                {
                    if (!LoginForm.KeyAuthApp.response.success)
                    {
                        Console.WriteLine("Authentication Failed");
                    }
                }
            }
        }
    }
}
