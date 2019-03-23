using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace LoyalistAutoNetworkMapper
{
    class Program
    {
        static void Main(string[] args)
        {








            Console.WriteLine("/////////////////////////////////////////////////////");
            Console.WriteLine("/////Loyalist Network Mapper by William Macleod///////");
            Console.WriteLine("/////////williammacleod@loyalistcollege.com////////////");
            Console.WriteLine("Step 1: Enter the name of the folder you would like mapped");
            Console.WriteLine("(You can leave this blank and map the entire M drive)");
            string mapfolder = Console.ReadLine();
           
            //    Console.WriteLine("Folder to be mapped: " + mapfolder);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Step 2: Choose the drive letter to create for this mapped folder, eg X or Z, something not in use in my computer!");
            Console.WriteLine("(Leaving this blank will set it to X)");
            string mapletter = Console.ReadLine();
            if (mapletter == "")
            {
                mapletter = "X";
            }
            //  Console.WriteLine(mapletter);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Step 3: Enter your Loyalist login, eg williammacleod");
            bool needinput = true;
            string username = "";
            while (needinput)
            {
                username = Console.ReadLine();
                if (username != "")
                {
                    needinput = false;
                }
                else
                {
                    Console.WriteLine("Username cant be blank");
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Step 4: Enter your Loyalist password");
            bool needpswd = true;
            string pswd = "";
            while (needpswd)
            {
                pswd = Console.ReadLine();
                if (pswd != "")
                {
                    needpswd = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Password cant be blank");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            if(mapfolder =="")
            {
                Console.WriteLine("Mapping entire Loyalist M drive to local drive letter " + mapletter + " with username " + username + " and password " + pswd);
            }
            else{
                Console.WriteLine("Mapping Loyalist folder " + mapfolder + " to local drive letter " + mapletter + " with username " + username + " and password " + pswd);
            }
            

            Console.WriteLine("Does that look correct? Press any key to continue, or input N to go back");
            string confirm = Console.ReadLine();
            if (confirm == "N" || confirm == "n")
            { Main(args); }
            Console.WriteLine();
           


            

            // Map Network drive
            System.Diagnostics.Process process = new System.Diagnostics.Process();
              System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();

            // Notes:
            //      Use /C To carry out the command specified by string and then terminates
            //      You can omit the passord or username and password
            //      Use /PERSISTENT:YES to keep the mapping when the machine is restarted
               psi.FileName = "cmd.exe";
            if (mapfolder != "")
            {
                psi.Arguments = @"/C net use " + mapletter + ": https://files.myloyalist.com/dav2/home." + username + "/" + mapfolder + "/" + " /USER:" + username + " " + pswd + " /PERSISTENT:YES";
            }
            else
            {
                psi.Arguments = @"/C net use " + mapletter + ": https://files.myloyalist.com/dav2/home." + username + "/" + " /USER:" + username + " " + pswd + " /PERSISTENT:YES";
            }
          //  Console.Write(psi.Arguments);
          //  Console.ReadLine();
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
          process.StartInfo = psi;

            process.Start();
            Console.WriteLine("Attemping mapping...");
            int milliseconds = 10000;
            Thread.Sleep(milliseconds);
            if (Directory.Exists(mapletter + @":\"))
            {
                System.Diagnostics.Process.Start("explorer.exe", mapletter + @":\");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine("Done! If everything went OK your mapped drive should pop up in a moment!");
                Console.WriteLine("You can close me now!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Still mapping...");
                Thread.Sleep(milliseconds);
                if (Directory.Exists(mapletter + @":\"))
                {
                    System.Diagnostics.Process.Start("explorer.exe", mapletter + @":\");
                    Console.WriteLine();

                    Console.WriteLine();
                    Console.WriteLine("Done! If everything went OK your mapped drive should pop up in a moment!");
                    Console.WriteLine("You can close me now!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Taking a while...");
                    Thread.Sleep(milliseconds);
                    if (Directory.Exists(mapletter + @":\"))
                    {
                        System.Diagnostics.Process.Start("explorer.exe", mapletter + @":\");
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.WriteLine("Done! If everything went OK your mapped drive should pop up in a moment!");
                        Console.WriteLine("You can close me now!");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Something might have gone wrong, check your drive list to see if the mapping worked, if not check your credentials and drive letter choice");
                        Console.WriteLine("Restarting...");
                        Main(args);
                    }
                }
            }
            
           
        }
    }
}
