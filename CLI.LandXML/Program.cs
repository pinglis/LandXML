using System;
using System.IO;
using Lib.LandXML;

namespace CLI.LandXML
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length!=1)
                throw new ArgumentException("Expected single directory for LandXML loading");

            string[] files = Directory.GetFiles(@args[0], "*.xml", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                try
                {
                    Loader load = new Loader();
                    Xml2CSharp.LandXML result = load.Load(file);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{file}-{exception.InnerException.Message}");
                }

            }

        }
    }
}
