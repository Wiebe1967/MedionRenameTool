using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedionRenameTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MedionRenameTool.Tests
{
	[TestClass()]
	public class MedionRenameTests
	{
		[TestMethod()]
		public void PerformRename1Test()
		{
			Directory.SetCurrentDirectory("H:\\");
			new MedionRename(Directory.GetCurrentDirectory(), false).PerformRename();
		}

		[TestMethod()]
		public void PerformRename2Test()
		{
			Directory.SetCurrentDirectory("H:\\PVR");
			new MedionRename(Directory.GetCurrentDirectory(), true).PerformRename();
		}

		[TestMethod()]
		public void PerformRename3Test()
		{
			Directory.SetCurrentDirectory("H:\\PVR\\REC_0008");
			new MedionRename(Directory.GetCurrentDirectory(), true).PerformRename();
		}
	}
}