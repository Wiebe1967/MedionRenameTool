using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedionRenameTool
{
	public class MedionRename
	{
		private string _currentDir;
		private bool _toNew;

		public MedionRename(string dir, bool toNew)
		{
			_currentDir = dir;
			_toNew = toNew;
		}

		public void PerformRename()
		{
			DirectoryInfo di = new DirectoryInfo(_currentDir);
			if (di.Name == "PVR")
				foreach (string recDir in Directory.GetDirectories(_currentDir, "REC_*"))
					PerformFileRename(recDir);
			else if (di.Name.StartsWith("REC_"))
				PerformFileRename(_currentDir);
			else
			{
				string[] subDirs = Directory.GetDirectories(_currentDir, "PVR");
				if (!subDirs.Any())
					Console.WriteLine("Cannot find PVR folder.");
				else
				{
					foreach (string recDir in Directory.GetDirectories(subDirs[0], "REC_*"))
						PerformFileRename(recDir);
				}
			}
		}

		public void PerformFileRename(string recDir)
		{
			string pattern = _toNew ? "rec.*" : "rec*.ts";
			foreach (string file in Directory.GetFiles(recDir, pattern).Where(file => Path.GetFileName(file).ToLower() != "rec.ts"))
			{
				string number = _toNew ? Path.GetExtension(file).Substring(1) : Path.GetFileNameWithoutExtension(file).Substring(3);
				if (!number.IsOnlyDigits())
				{
					Console.WriteLine($"Skipping {file}");
					continue;
				}
				string newFilename = _toNew ? $"rec{number}.ts" : $"rec.{number}";				
				File.Move(file, $"{Path.Combine(recDir, newFilename)}");
				Console.WriteLine($"{file} renamed to {newFilename}");
			}
		}

	}

	public static class Extensions
	{
		public static bool IsOnlyDigits(this string s)
		{
			foreach (char c in s)
				if (!char.IsDigit(c))
					return false;
			return true;
		}
	}
}