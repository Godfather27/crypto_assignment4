using System;
using System.Drawing;

namespace watermarking {
	class MainClass {
		static void Main (string[] args) {
			Console.Write("Enter watermark strength: ");
			int alpha = getValue ();

			Console.Write ("Enter a seed value: ");
			int seed = getValue ();

			Console.Write ("Enter filename: ");
			string filename = Console.ReadLine ();

			Console.Write ("Enter \"mark\" to watermark image, or \"check\" to check for watermark: ");
			string option = Console.ReadLine ();

			Watermarker wm = new Watermarker (filename, seed, alpha);

			if (option == "mark") {
				wm.watermark ();
			} else if (option == "check") {
				Console.WriteLine("File is watermarked: {0}", wm.isWatermarked ());
			}
		}

		public static int getValue(){
			int value;
			bool success = int.TryParse(Console.ReadLine(), out value);

			while (!success) {
				Console.Write ("Enter a valid Value: ");
				success = int.TryParse(Console.ReadLine(), out value);
			}

			return value;
		}
	}
}