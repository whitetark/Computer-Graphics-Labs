using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs
{
    public static class Starter
    {
        public static string[] StarterProg(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Enter needed files: ");
                Console.WriteLine("GraphicLabs.exe --source=cow.obj --output=output.ppm");
            }

            var inputArgs = new Dictionary<string, string>();
            foreach (var arg in args)
            {
                var filesSplit = arg.Split("=");
                inputArgs[filesSplit[0]] = filesSplit[1];
            }

            if (!inputArgs.ContainsKey("--source")&&!inputArgs.ContainsKey("--output"))
            {
                return null;
            }

            string source = inputArgs["--source"];
            string output= inputArgs["--output"];

            string[] files = {source, output};
            return files;
            
        }
    }
}
