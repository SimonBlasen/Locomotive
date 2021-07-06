using CubeRacer2Server.Games;
using CubeRacer2Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UDPServer.UDPServer;

namespace CubeRacer2Server
{
    class Program
    {
        private const string serverVersion = "v0.001";

        private static int udpPort = 38000;

        private static Server server;

        static void Main(string[] args)
        {
            ArgParser parser = new ArgParser();

            Option optPort = new Option(new string[]{"-p", "--port"}, "Set UDP Port");
            optPort.intArgument = true;

            Option optVersion = new Option(new string[]{"-v", "--version"}, "Print version number");
            Option optCheat = new Option(new string[]{"-c", "--cheat"}, "Set Server to cheat mode");
            Option optTut = new Option(new string[]{"-t", "--tutorial"}, "Set Server to tutorial mode");
            Option optHelp = new Option(new string[]{"-h", "--help"}, "Display Help");
            
            parser.AddOption(optPort);
            parser.AddOption(optVersion);
            parser.AddOption(optCheat);
            parser.AddOption(optTut);
            parser.AddOption(optHelp);

            if (!parser.parse(args) || optHelp.used)
            {
                parser.PrintUsage();
                return;
            }

            if (optVersion.used)
            {
                Console.WriteLine(serverVersion);
                return;
            }

            Console.WriteLine("Version " + serverVersion);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Starting server...");

            int compatPort; bool compatTut;
            if (parser.LegacyCompat(out compatPort, out compatTut))
            {
                udpPort = compatPort;
            }

            if (optPort.used)
            {
                udpPort = optPort.valueInt;
            }

            

            server = new Server(udpPort);

            Write("Started on port " + udpPort.ToString(), ConsoleColor.Green);


            while (true)
            {
                //Console.Write("> ");
                string input = Console.ReadLine();
                if (input.Length > 0)
                {
                    string[] inputArgs = new string[input.Split(' ').Length];
                    string[] inputArgsCaps = new string[input.Split(' ').Length];
                    for (int i = 0; i < inputArgs.Length; i++)
                    {
                        inputArgs[i] = input.Split(' ')[i].ToLower();
                        inputArgsCaps[i] = input.Split(' ')[i];
                    }
                    CommandExecute(inputArgs, inputArgsCaps);
                }
            }
        }



        public static void Write(string text)
        {
            Write(text, ConsoleColor.White);
        }

        public static void Write(string text, ConsoleColor color)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = oldColor;
        }

        private static async void CommandExecute(string[] commands, string[] commandsCaps)
        {
            if (commands[0] == "help")
            {
                Write("Available commands:\n"
                                + " info                       Shows all parameters the server is running on\n"
                                + " initteamvote               Initiates a teams mode vote\n"
                                + " map [map]                  Changes the map\n"
                                + " maxplayers [amount]        Sets the max players amount\n"
                                + " playerlist                 Lists all players on server\n"
                                + " reset                      Resets the server\n"
                                + " roundcredits [amount]      Sets the amount of building credits per round\n"
                                + " stop                       Stops the server properly\n"
                                + " teams [amount]             Sets the amount of teams\n"
                                + " version                    Shows the current server version\n"
                                + " visiblebuilding [0,1]      Enables or disables visible building");
            }
        }
    }
}
