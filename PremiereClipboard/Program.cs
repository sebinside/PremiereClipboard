using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PremiereClipboard
{
    class Program
    {
        const string TrackFormat = "PProAE/Exchange/TrackItem";
        static bool overwriteProtection = true;

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            Console.WriteLine("PremiereClipboard Utility by sebinside");
            Console.WriteLine("Working with Adobe Premiere Clip(board)s. Without bullshit.");

            if(args.Length == 3 && args[2] == "--overwrite")
            {
                overwriteProtection = false;
            }

            if (args.Length >= 2 && args[0] == "--save")
            {
                SaveClipboard(args[1]);
            }
            else if (args.Length == 2 && args[0] == "--load")
            {
                LoadClipboard(args[1]);
            }
            else
            {
                Console.WriteLine("This tool is designed to work specifically with Premiere track item clipboards.");
                Console.WriteLine("Usage: PremiereClipboard.exe <command> <filePath> <--overwrite>");
                Console.WriteLine("Use command --save to store the copied track items to a specified file. By adding --overwrite as third parameter you disable the overwrite protection.");
                Console.WriteLine("Use command --load to load previously stored track items from a specified file.");

                pressEnterToExit();
            }
        }

        static void LoadClipboard(string fileName)
        {
            Console.WriteLine("Started with --load command.");

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"The file \"{fileName}\" was not found.");
                pressEnterToExit();
            }
            else
            {
                try
                {
                    byte[] buffer = File.ReadAllBytes(fileName);
                    Console.WriteLine("Loaded file successfully.");
                    var trackItem = new MemoryStream(buffer);
                    Clipboard.SetData(TrackFormat, trackItem);
                    Console.WriteLine("Set clipboard successfully.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                    pressEnterToExit();
                }
            }
        }

        static void SaveClipboard(string fileName)
        {
            Console.WriteLine("Started with --save command.");

            if (File.Exists(fileName) && overwriteProtection)
            {
                Console.WriteLine($"The file \"{fileName}\" already exists. Not overwriting it for safety!");
                pressEnterToExit();
            }
            else
            {
                try
                {
                    MemoryStream trackItem = (MemoryStream)Clipboard.GetData(TrackFormat);
                    if (trackItem == null)
                    {
                        Console.WriteLine("Unable to find Premiere track items in clipboard.");
                        pressEnterToExit();
                    }
                    else
                    {
                        Console.WriteLine("Retrieved clipboard successfully.");
                        byte[] buffer = trackItem.ToArray();
                        File.WriteAllBytes(fileName, buffer);
                        Console.WriteLine("Saved file successfully.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                    pressEnterToExit();
                }
            }
        }

        static void pressEnterToExit()
        {
            Console.WriteLine("Press enter to exit.");
            Console.Read();
        }
    }
}
