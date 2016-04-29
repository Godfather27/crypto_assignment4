using System;
using System.Drawing;

namespace watermarking
{
	public class Watermarker
	{
		public Bitmap img;
		private string filename;
		private int seed;
		private int alpha;

		public Watermarker (string filename, int seed, int alpha)
		{
			this.filename = filename;
			this.img = new Bitmap (Image.FromFile(filename));
			this.seed = seed;
			this.alpha = alpha;
		}

		public void watermark(){
			Random rand = new Random (seed);
			int g;
			int r;
			int b;
			for (int x = 0; x < img.Width; x++) {
				for (int y = 0; y < img.Height; y++) {
					r = img.GetPixel (x, y).R;
					g = img.GetPixel (x, y).G + (rand.Next (-1,2) * alpha);
					if (g > 255) {
						g = 255;
					} else if (g < 0) {
						g = 0;
					}
					b = img.GetPixel (x, y).B;

					img.SetPixel(x,y,Color.FromArgb(r,g,b));
				}
			}

			img.Save (filename.Substring(0,filename.Length-4)+"_marked.png", System.Drawing.Imaging.ImageFormat.Png);
		}

		public bool isWatermarked(){
			Random rand = new Random (seed);
			double sum = 0;

			for (int x = 0; x < img.Width; x++) {
				for (int y = 0; y < img.Height; y++) {
					sum += img.GetPixel (x, y).G * (rand.Next (-1, 2) * alpha);
				}
			}

			double correlationskoeffizient = sum / (img.Height * img.Width);

			if(correlationskoeffizient > 12)
				return true;
			return false;
		}
	}
}

