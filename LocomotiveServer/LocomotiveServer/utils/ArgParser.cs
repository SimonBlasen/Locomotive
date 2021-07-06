using System.Collections.Generic;
using System;

namespace CubeRacer2Server.Utils
{

public class Option
{
    public Option(string[] _aliases, string _description = "")
    {
        aliases = _aliases;
        description = _description;
    }

    public string[] aliases;

    public string description;

    public bool used = false;

    public bool intArgument = false;

    public bool doubleArgument = false;

    public bool stringArgument = false;

    public int valueInt;

    public double valueDouble;

    public string valueString;
}

public class ArgParser
{
    private List<Option> options = new List<Option>();

    private bool parseError = false;

    private bool compatMode = false;

    private int compatPort;

    private bool compatTut = false;

    public ArgParser()
    {
    }

    public bool parse(string[] args)
    {
        List<string> arglist = new List<string>(args);

        checkCompatMode(args);
        if (compatMode)
        {
            return true;
        }

        while (arglist.Count > 0)
        {
            string arg = arglist[0];
            arglist.RemoveAt(0);

            bool found = false;
            foreach (Option o in options)
            {
                foreach (string a in o.aliases)
                {
                    if (a.CompareTo(arg) == 0)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    if (o.used)
                    {
                        Console.WriteLine("Duplicate option \"" + arg + "\"");
                        parseError = true;
                    }
                    o.used = true;

                    if (o.intArgument || o.doubleArgument || o.stringArgument)
                    {
                        try
                        {
                            string next = arglist[0];
                            arglist.RemoveAt(0);

                            if (o.intArgument)
                            {
                                o.valueInt = Int32.Parse(next);
                            }
                            else if (o.doubleArgument)
                            {
                                o.valueDouble = Double.Parse(next);
                            }
                            else
                            {
                                o.valueString = next;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid value for parameter \"" + arg + "\"");
                            parseError = true;
                        }
                    }

                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Unrecognized option \"" + arg + "\"");
                parseError = true;
            }
        }

        return !parseError;
    }

    private void checkCompatMode(string[] args)
    {
        if (args.Length > 0 && args.Length < 3)
        {
            try
            {
                compatPort = Int32.Parse(args[0]);
                compatMode = true;

                if (args.Length == 2 && args[1] == "1")
                {
                    compatTut = true;
                }
            }
            catch(Exception)
            {

            }
        }
    }

    public bool LegacyCompat(out int port, out bool tut)
    {
        port = compatPort;
        tut = compatTut;
        return compatMode;
    }

    public bool ParseError()
    {
        return parseError;
    }

    public void PrintUsage()
    {
        Console.WriteLine("Usage: CubeRacer2Server [options]");
        Console.WriteLine("       CubeRacer2Server <udpPort> <1:TutorialServer>");
        Console.WriteLine("Options:");

        string[] optionLines = new string[options.Count];

        int i = 0;
        int maxL = 0;
        foreach (Option o in options)
        {
            optionLines[i] = string.Join(", ", o.aliases);
            if (optionLines[i].Length > maxL)
            {
                maxL = optionLines[i].Length;
            }
            ++i;
        }

        maxL += 2;
        for (i = 0; i < optionLines.Length; ++i)
        {
            optionLines[i] += new string(' ', maxL - optionLines[i].Length);
            optionLines[i] += options[i].description;

            Console.WriteLine(optionLines[i]);
        }
    }

    public void AddOption(Option opt)
    {
        options.Add(opt);
    }
}

}