using System;
using OCR.Properties;
using System.Resources;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace OCR
{
    class ImageProcessor
    {
        public static bool CutImage(string filepath, int targetWidth, int targetHeight)
        {
            var jpgInfo = ImageCodecInfo.GetImageEncoders().Where(codecInfo => codecInfo.MimeType == "image/jpeg").First();
            var image = new Bitmap(filepath);
            var x = image.Width / 2 - targetWidth;
            var y = image.Height / 2 - targetHeight;
            var cropArea = new Rectangle(x, y, 2 * targetWidth, 2 * targetHeight);
            try
            {
                using (EncoderParameters encParams = new EncoderParameters(1))
                {
                    var croppedImage = image.Clone(cropArea, image.PixelFormat);
                    image.Dispose();
                    encParams.Param[0] = new EncoderParameter(Encoder.Quality, (long)100);
                    //quality should be in the range [0..100] .. 100 for max, 0 for min (0 best compression)
                    croppedImage = new Bitmap(croppedImage, new Size(targetWidth, targetHeight));
                    File.Delete(filepath);
                    croppedImage.Save(filepath, jpgInfo, encParams);
                    return true;
                }
            }
            catch { }
            return false;
        }

        public static int CountBlackPixels(Bitmap b, int startX, int startY, int toX, int toY)
        {
            var matches = 0;
            for (int y = startY; y < toY; y++)
            {
                for (int x = startX; x < toX; x++)
                {
                    if (b.GetPixel(x, y) == Color.FromArgb(255, 0, 0, 0)) 
                        matches++;
                }
            }
            return matches;
        }

        public static float[] ConvertImageToData(Bitmap image)
        {
            var width = image.Width;
            var height = image.Height;
            var count = CountBlackPixels(image, 0, 0, width, height);
            if (count < image.Width * image.Height * 0.03)
                return null;
            var partWidth = width / int.Parse(Resources.PARTITION);
            var partHeight = height / int.Parse(Resources.PARTITION);
            var PixelValues = new float[int.Parse(Resources.PARTITION)*int.Parse(Resources.PARTITION)];
            var k = 0;
            try
            {
                for (int j = 0; j < int.Parse(Resources.PARTITION); j++)
                {
                    for (int i = 0; i < int.Parse(Resources.PARTITION); i++)
                    {
                        PixelValues[k++] = CountBlackPixels(image, i * partWidth, j * partHeight, (i + 1) * partWidth - 1, (j + 1) * partHeight - 1);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                return null;
            }
            finally
            {
                if (image != null)
                    image.Dispose();
            }
            return PixelValues;
        }

        public static Bitmap PrepareImage(Bitmap image)
        {
            var width = image.Width;
            var height = image.Height;
            var img = new Bitmap(Resources.cell, width, height);
            using var g = Graphics.FromImage(img);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = width / 12;
            int h = height / 12;
            g.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(w, h, width - 2 * w, height - 2 * h), GraphicsUnit.Pixel);
            return img;
        }

        public static void ReplaceSelector(Bitmap dest, Rectangle replacementArea)
        {
            Bitmap img = null;
            var width = dest.Width;
            var height = dest.Height;
            var count = CountBlackPixels(dest, 0, 0, width, height);
            if (count > dest.Width * dest.Height * 0.05)
            {            
                ResourceManager rm = Resources.ResourceManager;
                img = new Bitmap((Bitmap)rm.GetObject("letter_x"), replacementArea.Size);
            }
            if (img != null)
            {
                using var g = Graphics.FromImage(dest);
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawImage(img, new Point(replacementArea.X, replacementArea.Y));
            }
        }

        public static void ReplacePrediction(string value, Bitmap dest, Rectangle replacementArea)
        {
            Bitmap img;
            ResourceManager rm = Resources.ResourceManager;
            switch (value)
            {
                case "0":
                    img = new Bitmap((Bitmap)rm.GetObject("digit_0"), replacementArea.Size);
                    break;
                case "1":
                    img = new Bitmap((Bitmap)rm.GetObject("digit_1"), replacementArea.Size);
                    break;
                case "2":
                    img = new Bitmap((Bitmap)rm.GetObject("digit_2"), replacementArea.Size);
                    break;
                case "3":
                    img = new Bitmap((Bitmap)rm.GetObject("digit_3"), replacementArea.Size);
                    break;
                case "4":
                    img = new Bitmap((Bitmap)rm.GetObject("digit_4"), replacementArea.Size);
                    break;
                case "5":
                    img = new Bitmap((Bitmap)rm.GetObject("digit_5"), replacementArea.Size);
                    break;
                case "6":
                    img = new Bitmap((Bitmap)rm.GetObject("digit_6"), replacementArea.Size);
                    break;
                case "7":
                    img = new Bitmap((Bitmap)rm.GetObject("digit_7"), replacementArea.Size);
                    break;
                case "8":
                    img = new Bitmap((Bitmap)rm.GetObject("digit_8"), replacementArea.Size);
                    break;
                case "9":
                    img = new Bitmap((Bitmap)rm.GetObject("digit_9"), replacementArea.Size);
                    break;
                case "a":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_a"), replacementArea.Size);
                    break;
                case "b":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_b"), replacementArea.Size);
                    break;
                case "c":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_c"), replacementArea.Size);
                    break;
                case "d":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_d"), replacementArea.Size);
                    break;
                case "e":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_e"), replacementArea.Size);
                    break;
                case "f":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_f"), replacementArea.Size);
                    break;
                case "g":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_g"), replacementArea.Size);
                    break;
                case "h":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_h"), replacementArea.Size);
                    break;
                case "i":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_i"), replacementArea.Size);
                    break;
                case "j":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_j"), replacementArea.Size);
                    break;
                case "k":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_k"), replacementArea.Size);
                    break;
                case "l":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_l"), replacementArea.Size);
                    break;
                case "m":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_m"), replacementArea.Size);
                    break;
                case "n":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_n"), replacementArea.Size);
                    break;
                case "o":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_o"), replacementArea.Size);
                    break;
                case "p":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_p"), replacementArea.Size);
                    break;
                case "q":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_q"), replacementArea.Size);
                    break;
                case "r":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_r"), replacementArea.Size);
                    break;
                case "s":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_s"), replacementArea.Size);
                    break;
                case "t":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_t"), replacementArea.Size);
                    break;
                case "u":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_u"), replacementArea.Size);
                    break;
                case "v":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_v"), replacementArea.Size);
                    break;
                case "w":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_w"), replacementArea.Size);
                    break;
                case "x":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_x"), replacementArea.Size);
                    break;
                case "y":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_y"), replacementArea.Size);
                    break;
                case "z":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_z"), replacementArea.Size);
                    break;
                default:
                    img = null;
                    break;
            }
            if (img != null)
            {
                using var g = Graphics.FromImage(dest);
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawImage(img, new Point(replacementArea.X, replacementArea.Y));
            }
        }
    }
}
