using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedionRenameTool
{
	class Program
	{
		static void Main(string[] args)
		{
			if (!args.Any())
				Console.WriteLine("No arguments given. One possible argument: 'ToOld' or 'ToNew'");
			else if (args.Count() >= 2)
				Console.WriteLine("Too many arguments.");
			else if (args[0] == "ToOld")
				RenameTSFiles(false);
			else if (args[0] == "ToNew")
				RenameTSFiles(true);
			else
				Console.WriteLine("Argument not recognized. Possible arguments: 'ToOld', 'ToNew'");
			Console.ReadKey();
		}

		private static void RenameTSFiles(bool toNewFormat)
		{
			new MedionRename(Directory.GetCurrentDirectory(), toNewFormat).PerformRename();
		}
	}
}