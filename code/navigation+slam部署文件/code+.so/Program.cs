using System;
using System.Runtime.InteropServices;
namespace new_try
{
	class MainClass
	{
		[DllImport("libnavi.so",EntryPoint="selfnavigation")]
		extern static int selfnavigation ();
		[DllImport("libslamg.so",EntryPoint="slamStart")]
		extern static int slamStart ();
		public static void Main (string[] args)
		{
			slamStart ();
			Console.WriteLine ("Hello World!");
		}
	}
}
