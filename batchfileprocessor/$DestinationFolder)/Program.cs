using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatchFileFramework;
namespace batchFileProcessor
{
	class Program
	{
		static long totalFilesLen = 0;

		static void testNotify(String msg)
		{
			Console.WriteLine(msg);
		}

		static void findTotalFilesLength(IFileAccessLogic lo, System.IO.FileInfo fi)
		{
			totalFilesLen += fi.Length;
		}

		static void Main(string[] args)
		{
			if(args.Length < 1)
			{
				Console.WriteLine("Missing file or folder path: \nUsage: batchFileProcessor filepath(folderpath)");
				return;
			}

			FileAccessLogic accessor = new FileAccessLogic();
			accessor.OnNotify += testNotify;
			accessor.OnProcess += findTotalFilesLength;

			accessor.Recursive = true;
			accessor.Execute(args[0]);

			Console.WriteLine("Total Files length in directory {0} is {1}", args[0], totalFilesLen);
			// Keep the console window open in debug mode.
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();

		}		       

	}
}
