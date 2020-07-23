using System;
using OCR.Properties;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using System.Resources;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace OCR
{
    class ImageProcessor
    {
        public static bool PrepareImageFromFile(string filepath, int targetWidth, int targetHeight, string ext)
        {
            var img = new Bitmap(filepath);
            var scaledImage = GetScaledImage(img, FindImageBbox(img));
            var centeredImage = GetCenteredImage(scaledImage, CenterOfMass(scaledImage));
            var outputImage = new Bitmap(centeredImage, targetWidth, targetHeight);
            var tmpPath = Path.Combine(Directory.GetCurrentDirectory(), "temp");
            if (!Directory.Exists(tmpPath))
                Directory.CreateDirectory(tmpPath);
            var setFolder = Directory.GetParent(Directory.GetParent(filepath).FullName).Name;
            var labelFolder = Directory.GetParent(filepath).Name;
            if (!Directory.Exists(Path.Combine(tmpPath, setFolder)))
                Directory.CreateDirectory(Path.Combine(tmpPath, setFolder));
            if (!Directory.Exists(Path.Combine(tmpPath, setFolder, labelFolder)))
                Directory.CreateDirectory(Path.Combine(tmpPath, setFolder, labelFolder));
            var filename = filepath.Substring(filepath.LastIndexOf('\\') + 2);
            outputImage.Save(Path.Combine(tmpPath, setFolder, labelFolder, filename));
            return true;
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

        private static Point CenterOfMass(Bitmap img)
        {
            int sumX = 0;
            int sumY = 0;
            int num = 0;
            for (int j = 0; j < img.Height; j++)
                for (int i = 0; i < img.Width; i++)
                {
                    if (img.GetPixel(i, j) == Color.FromArgb(255, 0, 0, 0))
                    {
                        sumX += i;
                        sumY += j;
                        num++;
                    }
                }
            return num > 0 ? new Point(sumX / num, sumY / num) : new Point(img.Width / 2 - 1, img.Height / 2 - 1);
        }

        private static Bitmap GetCenteredImage(Bitmap img, Point com)
        {
            var centerX = img.Width / 2 - 1;
            var centerY = img.Height / 2 - 1;
            var offsetX = centerX - com.X;
            var offsetY = centerY - com.Y;
            var bmp = new Bitmap(img.Width, img.Height);
            using var g = Graphics.FromImage(bmp);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TranslateTransform(offsetX, offsetY);
            g.Clear(Color.White);
            g.DrawImage(img, 0, 0);
            return bmp;
        }

        public static Rectangle FindImageBbox(Bitmap img)
        {
            int top = 0;
            int down = 0;
            int left = 0;
            int right = 0;
            for (int j = 0; j < img.Height; j++)
            {
                for (int i = 0; i < img.Width; i++)
                {
                    if (img.GetPixel(i, j) == Color.FromArgb(255, 0, 0, 0))
                    {
                        top = j;
                        break;
                    }
                }
                if (top != 0)
                    break;
            }
            for (int j = img.Height - 1; j >= 0; j--)
            {
                for (int i = img.Width - 1; i >= 0; i--)
                {
                    if (img.GetPixel(i, j) == Color.FromArgb(255, 0, 0, 0))
                    {
                        down = j;
                        break;
                    }
                }
                if (down != 0)
                    break;
            }
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    if (img.GetPixel(i, j) == Color.FromArgb(255, 0, 0, 0))
                    {
                        left = i;
                        break;
                    }
                }
                if (left != 0)
                    break;
            }
            for (int i = img.Width - 1; i >= 0; i--)
            {
                for (int j = img.Height - 1; j >= 0; j--)
                {
                    if (img.GetPixel(i, j) == Color.FromArgb(255, 0, 0, 0))
                    {
                        right = i;
                        break;
                    }
                }
                if (right != 0)
                    break;
            }
            return new Rectangle(left, top, right - left, down - top);
        }

        public static Bitmap GetScaledImage(Bitmap img, Rectangle bbox)
        {
            try
            {
                float widthScale = 0, heightScale = 0;
                if (img.Width != 0)
                    widthScale = (float)img.Width / (float)bbox.Width;
                if (img.Height != 0)
                    heightScale = (float)img.Height / (float)bbox.Height;
                var scale = Math.Min(widthScale, heightScale);
                var bmp = new Bitmap(img.Width, img.Height);
                using var g = Graphics.FromImage(bmp);
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);
                g.ScaleTransform(scale, scale);
                g.DrawImage(img, 0, 0, bbox, GraphicsUnit.Pixel);
                return bmp;
            }
            catch (Exception ex) { Debug.WriteLine(ex.StackTrace); }
            return img;
        }

        public static Bitmap PrepareImage(Bitmap img)
        {
            var scaledImage = GetScaledImage(img, FindImageBbox(img));
            var centeredImage = GetCenteredImage(scaledImage, CenterOfMass(scaledImage));           
            return centeredImage;
        }

        public static string ProcessSelector(Bitmap dest)
        {
            var width = dest.Width;
            var height = dest.Height;
            var count = CountBlackPixels(dest, 0, 0, width, height);
            if (count < width * height * 0.03)
                return "false";
            else
                return "true";
        }

        public static void ReplacePrediction(string value, Bitmap dest, Rectangle replacementArea, bool cleanArea = false)
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
                case "true":
                    img = new Bitmap((Bitmap)rm.GetObject("letter_x"), replacementArea.Size);
                    break;
                default:
                    img = null;
                    break;
            }
            using var g = Graphics.FromImage(dest);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (cleanArea)
                g.FillRectangle(Brushes.White, replacementArea);
            if (img != null)
                g.DrawImage(img, new Point(replacementArea.X, replacementArea.Y));
        }
    }
}
